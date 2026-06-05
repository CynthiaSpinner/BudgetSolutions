using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace BudgetSolutions
{
    public class CashFlowEvent
    {
        public DateTime Date           { get; set; }  // recommended PAY date (calendar position)
        public DateTime DueDate        { get; set; }  // original due date from DB
        public string   EventType      { get; set; }  // "Income" | "Expense" | "DueReminder"
        public string   Name           { get; set; }
        public string   Type           { get; set; }
        public decimal  Amount         { get; set; }
        public decimal  PassedAmount   { get; set; }
        public bool     IsPastDue      { get; set; }
        public int      Priority       { get; set; }
        public string   PriorityLabel  { get; set; }
        public decimal  RunningBalance { get; set; }
        public string   Status         { get; set; }
        public int      GraceDays      { get; set; }
        public decimal  LateFee        { get; set; }
        public bool     IsDeferred     { get; set; }  // paid after due date, within grace
        public bool     CannotPay      { get; set; }  // cannot cover even within grace
    }

    public class BudgetSummary
    {
        public decimal             TotalMonthlyIncome    { get; set; }
        public decimal             TotalMonthlyExpenses  { get; set; }
        public decimal             NetAfterBills         { get; set; }
        public decimal             SuggestedWeeklyFood   { get; set; }
        public decimal             SuggestedWeeklySavings{ get; set; }
        public List<CashFlowEvent> CashFlow              { get; set; } = new List<CashFlowEvent>();
    }

    static class BudgetCalculator
    {
        // ── Priority tiers ────────────────────────────────────────────────────
        // Processed in order: highest priority bills get first claim on income
        private static int GetPriority(string type, out string label)
        {
            string t = (type ?? "").ToLower();

            // 1 — Housing (keep the roof)
            if (t.Contains("mortgage") || t.Contains("rent") || t.Contains("housing") ||
                t.Contains("apartment") || t.Contains("lease"))
            { label = "1 · Housing"; return 1; }

            // 2 — Food (survival)
            if (t.Contains("food") || t.Contains("groceries") || t.Contains("grocery") ||
                t.Contains("market") || t.Contains("supermarket") || t.Contains("meals") ||
                t.Contains("wic") || t.Contains("stamps"))
            { label = "2 · Food"; return 2; }

            // 3 — Utilities + phone/internet (survive + stay reachable)
            if (t.Contains("water") || t.Contains("electric") || t.Contains("gas") ||
                t.Contains("utility") || t.Contains("utilities") || t.Contains("sewer") ||
                t.Contains("trash") || t.Contains("phone") || t.Contains("cell") ||
                t.Contains("internet") || t.Contains("wifi") || t.Contains("cable") ||
                t.Contains("broadband"))
            { label = "3 · Utilities"; return 3; }

            // 4 — Car payment (transportation for food/childcare)
            // Check insurance separately (lower priority) before generic "car"
            if (!t.Contains("insurance") &&
                (t.Contains("car payment") || t.Contains("auto payment") ||
                 t.Contains("vehicle payment") || t.Contains("car note") ||
                 t.Contains("car loan")))
            { label = "4 · Car Payment"; return 4; }

            // 5 — Car insurance (has grace, can defer a few days)
            if (t.Contains("insurance"))
            { label = "5 · Insurance"; return 5; }

            // 6 — Home/personal security
            if (t.Contains("security") || t.Contains("alarm") || t.Contains("adt") ||
                t.Contains("protection plan"))
            { label = "6 · Security"; return 6; }

            // 7 — Loans / credit / medical debt
            if (t.Contains("loan") || t.Contains("credit") || t.Contains("debt") ||
                t.Contains("medical") || t.Contains("student"))
            { label = "7 · Loans/Debt"; return 7; }

            // 8 — Subscriptions and everything else
            label = "8 · Subscriptions";
            return 8;
        }

        // ── Grace period parser ────────────────────────────────────────────────
        // Handles "none", "1 day", "5 days", "10 days"
        private static int ParseGraceDays(string grace)
        {
            if (string.IsNullOrWhiteSpace(grace)) return 0;
            string digits = "";
            foreach (char c in grace)
            {
                if (char.IsDigit(c)) digits += c;
                else if (digits.Length > 0) break;
            }
            return digits.Length > 0 ? int.Parse(digits) : 0;
        }

        // ── Frequency / pay-date helpers ──────────────────────────────────────
        private enum Frequency { Weekly, BiWeekly, Monthly, OneTime }

        private static Frequency GetFrequency(string type)
        {
            string t = (type ?? "").ToLower();
            if (t.Contains("bi-weekly") || t.Contains("biweekly")) return Frequency.BiWeekly;
            if (t.Contains("weekly"))                               return Frequency.Weekly;
            if (t.Contains("one time") || t.Contains("settlement")) return Frequency.OneTime;
            return Frequency.Monthly;
        }

        // Government benefits that always land on the 1st of the month
        private static readonly HashSet<string> AlwaysFirstOfMonth = new HashSet<string>(
            StringComparer.OrdinalIgnoreCase)
        {
            "VA Benefits", "BAH"
        };

        public static List<DateTime> GetPayDates(string type, DateTime baseDate, int year, int month)
        {
            var dates = new List<DateTime>();
            DateTime monthStart = new DateTime(year, month, 1);
            DateTime monthEnd   = monthStart.AddMonths(1).AddDays(-1);
            Frequency freq      = GetFrequency(type);

            // VA Benefits, BAH — always the 1st regardless of stored date
            if (AlwaysFirstOfMonth.Contains((type ?? "").Trim()))
            {
                dates.Add(new DateTime(year, month, 1));
                return dates;
            }

            switch (freq)
            {
                case Frequency.Weekly:
                case Frequency.BiWeekly:
                {
                    int interval = freq == Frequency.Weekly ? 7 : 14;
                    DateTime cur = baseDate;
                    if (cur < monthStart)
                    {
                        int gap     = (int)(monthStart - cur).TotalDays;
                        int periods = (gap + interval - 1) / interval;
                        cur = cur.AddDays(periods * interval);
                    }
                    while (cur <= monthEnd) { dates.Add(cur); cur = cur.AddDays(interval); }
                    break;
                }
                case Frequency.OneTime:
                    if (baseDate >= monthStart && baseDate <= monthEnd) dates.Add(baseDate);
                    break;

                default: // Monthly — same day each month, clamped to days in target month
                {
                    int day = Math.Min(baseDate.Day, DateTime.DaysInMonth(year, month));
                    dates.Add(new DateTime(year, month, day));
                    break;
                }
            }
            return dates;
        }

        public static (int occurrences, decimal monthlyAmount) GetMonthlyContribution(
            string type, DateTime baseDate, decimal perCheck, int year, int month)
        {
            var dates = GetPayDates(type, baseDate, year, month);
            return (dates.Count, dates.Count * perCheck);
        }

        // ── Core allocation engine ────────────────────────────────────────────
        /// <summary>
        /// Builds a chronological cash flow for the target month.
        /// Bills are paid in PRIORITY ORDER. If a bill can't be covered on its due
        /// date the engine looks forward within its grace period for a paycheck that
        /// covers it. Balance never goes below zero — uncoverable bills are flagged.
        /// asOfDate: the date your bank balance is current. Events before this date
        /// are shown as Historical (already happened, already in your balance).
        /// </summary>
        public static List<CashFlowEvent> GetCashFlow(int year, int month,
            decimal startingBalance = 0m, DateTime? asOfDate = null,
            decimal weeklyFoodBudget = 150m)
        {
            DateTime monthStart = new DateTime(year, month, 1);
            DateTime monthEnd   = monthStart.AddMonths(1).AddDays(-1);

            var incomeEvents  = new List<CashFlowEvent>();
            var rawExpenses   = new List<CashFlowEvent>();

            using (var conn = new SqlConnection(Program.ConnectionString))
            {
                conn.Open();

                // Income — generate one event per actual pay date this month
                using (var cmd = new SqlCommand(
                    "SELECT type, name, date, ISNULL(amount,0) AS amount FROM income", conn))
                {
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            string   iType    = r["type"].ToString();
                            decimal  perCheck = (decimal)r["amount"];
                            DateTime baseDate = r["date"] == DBNull.Value
                                ? monthStart : (DateTime)r["date"];

                            foreach (var pd in GetPayDates(iType, baseDate, year, month))
                            {
                                incomeEvents.Add(new CashFlowEvent
                                {
                                    Date      = pd,
                                    DueDate   = pd,
                                    EventType = "Income",
                                    Name      = r["name"].ToString(),
                                    Type      = iType,
                                    Amount    = perCheck,
                                    Priority  = 0,
                                    PriorityLabel = "Income",
                                    Status    = "Deposit"
                                });
                            }
                        }
                    }
                }

                // Expenses — all records, projected monthly.
                // Bills with no past-due flag recur every month on the same day-of-month.
                // Bills marked passed='Yes' are outstanding from a previous cycle and
                // are shown based on their grace-period deadline.
                using (var cmd = new SqlCommand(
                    @"SELECT name, type, date, ISNULL(amount,0) AS amount,
                             ISNULL(passedAmount,0) AS passedAmt, ISNULL(passed,'No') AS passed,
                             ISNULL(grace,'none') AS grace, ISNULL(lateFee,0) AS lateFee
                      FROM expenses", conn))
                {
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            bool    isPastDue  = r["passed"].ToString().Trim().ToLower() == "yes";
                            decimal amt        = (decimal)r["amount"];
                            decimal pastAmt    = (decimal)r["passedAmt"];
                            DateTime stored    = r["date"] == DBNull.Value
                                ? monthStart : (DateTime)r["date"];
                            int graceDays      = ParseGraceDays(r["grace"].ToString());
                            decimal lateFee    = (decimal)r["lateFee"];
                            int pri            = GetPriority(r["type"].ToString(), out string label);
                            string name        = r["name"].ToString();
                            string type        = r["type"].ToString();

                            // ── Recurring monthly instance ─────────────────────────
                            // Every bill recurs on the same day each month regardless of
                            // whether a previous cycle was paid.
                            // Exception: if this is a past-due record AND the original due
                            // date is already in the target month, skip the recurring instance
                            // (the past-due event below IS this month's bill).
                            bool fromThisMonth = (stored.Year == year && stored.Month == month);

                            if (!isPastDue || !fromThisMonth)
                            {
                                int dueDay   = Math.Min(stored.Day, DateTime.DaysInMonth(year, month));
                                DateTime due = new DateTime(year, month, dueDay);

                                rawExpenses.Add(new CashFlowEvent
                                {
                                    Date          = due,
                                    DueDate       = due,
                                    EventType     = "Expense",
                                    Name          = name,
                                    Type          = type,
                                    Amount        = amt,
                                    PassedAmount  = 0m,
                                    IsPastDue     = false,
                                    Priority      = pri,
                                    PriorityLabel = label,
                                    GraceDays     = graceDays,
                                    LateFee       = lateFee,
                                    Status        = "Pending"
                                });
                            }

                            // ── Past-due carry-over event ──────────────────────────
                            // If a previous cycle's bill went unpaid, show it separately
                            // so both the arrears AND this month's bill get allocated.
                            if (isPastDue)
                            {
                                DateTime graceEnd = stored.AddDays(graceDays);
                                DateTime today    = DateTime.Today;
                                // Expired grace → anchor to today so it's immediately visible.
                                DateTime displayDate =
                                    graceEnd < today    ? (today >= monthStart && today <= monthEnd ? today : monthStart) :
                                    graceEnd > monthEnd ? monthEnd   : graceEnd;

                                int daysLeft = (graceEnd.Date - today).Days;
                                string urgency =
                                    daysLeft <= 0 ? "GraceExpired" :
                                    daysLeft <= 3 ? "AtRisk"       : "PastDue";

                                rawExpenses.Add(new CashFlowEvent
                                {
                                    Date          = displayDate,
                                    DueDate       = stored,
                                    EventType     = "Expense",
                                    Name          = name + " (PAST DUE)",
                                    Type          = type,
                                    Amount        = pastAmt > 0 ? pastAmt + lateFee : amt + lateFee,
                                    PassedAmount  = pastAmt,
                                    IsPastDue     = true,
                                    Priority      = pri,
                                    PriorityLabel = label,
                                    GraceDays     = graceDays,
                                    LateFee       = lateFee,
                                    Status        = urgency
                                });
                            }
                        }
                    }
                }
            }

            // ── Split historical (paid) vs. active ───────────────────────────
            // "Historical" means already settled — shown dimmed on the calendar.
            //   • Income before asOfDate  → already deposited (in starting balance)
            //   • Regular expenses (IsPastDue=false) before asOfDate → assumed paid
            // "Active" means still needs money allocated:
            //   • All income on/after asOfDate
            //   • All regular expenses on/after asOfDate
            //   • ALL past-due expenses (IsPastDue=true) — always active, never historical,
            //     because they represent money still owed regardless of original due date.
            DateTime cutoff = asOfDate?.Date ?? new DateTime(year, month, 1);

            var historicalIncome   = incomeEvents.Where(e => e.Date.Date < cutoff).ToList();
            var futureIncome       = incomeEvents.Where(e => e.Date.Date >= cutoff).ToList();

            var historicalExpenses = rawExpenses
                .Where(e => !e.IsPastDue && e.Date.Date < cutoff).ToList();
            var futureExpenses = rawExpenses
                .Where(e => e.IsPastDue || e.Date.Date >= cutoff).ToList();

            foreach (var ev in historicalIncome)   { ev.Status = "Historical"; ev.EventType = "HistoricalIncome"; }
            foreach (var ev in historicalExpenses) { ev.Status = "Historical"; ev.EventType = "HistoricalExpense"; }

            // Replace working lists with future-only items for allocation
            incomeEvents = futureIncome;
            rawExpenses  = futureExpenses;

            // ── Weekly food budget reservations ───────────────────────────────
            // Food is Priority 2 (just below mortgage). We create one synthetic
            // "Food Budget" event per remaining week of the month starting from
            // the cutoff date. These get first claim on income after mortgage,
            // so lower-priority bills (security, loans, subscriptions) can only
            // be paid from whatever is left AFTER food is locked in.
            if (weeklyFoodBudget > 0)
            {
                // Start from the Monday of the current week (or the cutoff itself)
                // and step weekly through the end of the month.
                DateTime firstFoodDay = cutoff.Date;
                for (int weekNum = 0; ; weekNum++)
                {
                    DateTime fd = firstFoodDay.AddDays(weekNum * 7);
                    if (fd.Month != month || fd > monthEnd) break;

                    rawExpenses.Add(new CashFlowEvent
                    {
                        Date          = fd,
                        DueDate       = fd,
                        EventType     = "Expense",
                        Name          = weekNum == 0 ? "Food Budget" : $"Food Budget (wk {weekNum + 1})",
                        Type          = "Food",
                        Amount        = weeklyFoodBudget,
                        Priority      = 2,   // after mortgage, before ALL other bills
                        PriorityLabel = "2 · Food",
                        GraceDays     = 0,   // food cannot be deferred
                        LateFee       = 0m,
                        Status        = "Pending"
                    });
                }
            }

            // ── Allocation pass ───────────────────────────────────────────────
            // Build income by date: date → total income on that date
            var incomeByDate = new SortedDictionary<DateTime, decimal>();
            foreach (var ie in incomeEvents)
            {
                if (!incomeByDate.ContainsKey(ie.Date)) incomeByDate[ie.Date] = 0m;
                incomeByDate[ie.Date] += ie.Amount;
            }

            // Tracks scheduled expense payments: date → total committed
            var scheduledByDate = new SortedDictionary<DateTime, decimal>();

            // Running helper: balance available at a given date
            decimal BalanceAt(DateTime d)
            {
                decimal bal = startingBalance;
                foreach (var kv in incomeByDate)
                {
                    if (kv.Key > d) break;
                    bal += kv.Value;
                }
                foreach (var kv in scheduledByDate)
                {
                    if (kv.Key > d) break;
                    bal -= kv.Value;
                }
                return bal;
            }

            // Process expenses in priority order, then by due date
            var sortedExpenses = rawExpenses
                .OrderBy(e => e.Priority)
                .ThenBy(e => e.DueDate)
                .ToList();

            var deferredReminders = new List<CashFlowEvent>(); // dim calendar notes on original due dates

            foreach (var exp in sortedExpenses)
            {
                decimal balOnDue = BalanceAt(exp.DueDate);

                if (balOnDue >= exp.Amount)
                {
                    // Pay on due date — no problem
                    exp.Date   = exp.DueDate;
                    exp.Status = exp.IsPastDue ? "PAST DUE"
                               : balOnDue - exp.Amount < 100m ? "Tight"
                               : "Covered";
                }
                else if (exp.IsPastDue)
                {
                    // Past due bills take priority — schedule on due date even if tight
                    exp.Date   = exp.DueDate;
                    exp.Status = "PAST DUE";
                }
                else
                {
                    // Look forward within grace period for a day we can pay
                    DateTime graceEnd   = exp.DueDate.AddDays(exp.GraceDays);
                    DateTime? payDate   = null;

                    for (int g = 1; g <= exp.GraceDays; g++)
                    {
                        DateTime check = exp.DueDate.AddDays(g);
                        if (check > monthEnd) break;           // don't schedule outside month
                        if (BalanceAt(check) >= exp.Amount)
                        {
                            payDate = check;
                            break;
                        }
                    }

                    if (payDate.HasValue)
                    {
                        // Add a dim "due today, deferring" reminder on the original due date
                        deferredReminders.Add(new CashFlowEvent
                        {
                            Date          = exp.DueDate,
                            DueDate       = exp.DueDate,
                            EventType     = "DueReminder",
                            Name          = exp.Name,
                            Type          = exp.Type,
                            Amount        = exp.Amount,
                            Priority      = exp.Priority,
                            PriorityLabel = exp.PriorityLabel,
                            Status        = $"→ Paying {payDate.Value:MM/dd}"
                        });

                        exp.Date       = payDate.Value;
                        exp.IsDeferred = true;
                        exp.Status     = $"Deferred (due {exp.DueDate:MM/dd})";
                    }
                    else
                    {
                        // Cannot cover within grace — mark but don't subtract from balance
                        exp.Date      = exp.DueDate;
                        exp.CannotPay = true;
                        exp.Status    = "Cannot Cover";
                    }
                }

                // Commit scheduled payment to timeline (so later priorities see correct balance)
                if (!exp.CannotPay)
                {
                    if (!scheduledByDate.ContainsKey(exp.Date)) scheduledByDate[exp.Date] = 0m;
                    scheduledByDate[exp.Date] += exp.Amount;
                }
            }

            // ── Assemble final chronological list ─────────────────────────────
            var all = new List<CashFlowEvent>();
            all.AddRange(historicalIncome);    // past events shown dimmed
            all.AddRange(historicalExpenses);
            all.AddRange(incomeEvents);        // future events with allocation
            all.AddRange(sortedExpenses);
            all.AddRange(deferredReminders);

            var ordered = all
                .OrderBy(e => e.Date)
                .ThenBy(e => e.EventType == "Income" ? 0 : e.EventType == "DueReminder" ? 2 : 1)
                .ThenBy(e => e.Priority)
                .ToList();

            // Rolling balance — historical events are already in startingBalance, skip them
            decimal balance = startingBalance;
            foreach (var ev in ordered)
            {
                if (ev.Status == "Historical")
                {
                    ev.RunningBalance = balance; // show current balance, don't change it
                    continue;
                }

                if (ev.EventType == "Income")
                    balance += ev.Amount;
                else if (ev.EventType == "Expense" && !ev.CannotPay)
                    balance -= ev.Amount;
                // DueReminder and CannotPay do not change balance

                ev.RunningBalance = balance;
            }

            return ordered;
        }

        // ── Summary wrapper ───────────────────────────────────────────────────
        public static BudgetSummary Calculate(int year, int month,
            decimal startingBalance = 0m, DateTime? asOfDate = null,
            decimal weeklyFoodBudget = 150m)
        {
            var flow = GetCashFlow(year, month, startingBalance, asOfDate, weeklyFoodBudget);

            decimal totalIncome   = flow.Where(e => e.EventType == "Income").Sum(e => e.Amount);
            // Food budget events are real Priority-2 allocations, not suggestions
            decimal foodAllocated = flow
                .Where(e => e.EventType == "Expense" && e.Type == "Food"
                         && e.Name.StartsWith("Food Budget") && !e.CannotPay)
                .Sum(e => e.Amount);
            decimal totalExpenses = flow.Where(e => e.EventType == "Expense" && !e.CannotPay).Sum(e => e.Amount);
            decimal net           = startingBalance + totalIncome - totalExpenses;

            // Savings = whatever remains after bills + food are all covered
            decimal savingsBudget = 0m;
            if (net > 0)
            {
                decimal weeks = 4.33m;
                savingsBudget = Math.Round(net / weeks, 2);
            }

            return new BudgetSummary
            {
                TotalMonthlyIncome     = totalIncome,
                TotalMonthlyExpenses   = totalExpenses,
                NetAfterBills          = net,
                SuggestedWeeklyFood    = weeklyFoodBudget,   // what user set as the target
                SuggestedWeeklySavings = savingsBudget,
                CashFlow               = flow
            };
        }
    }
}
