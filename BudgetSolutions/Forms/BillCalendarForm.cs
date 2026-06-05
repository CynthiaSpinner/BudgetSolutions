using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace BudgetSolutions
{
    // ── Custom GDI+ calendar canvas ───────────────────────────────────────────
    class CalendarCanvas : Panel
    {
        // Events grouped by day of month
        private Dictionary<int, List<CashFlowEvent>> _byDay;
        private int _year, _month;

        private static readonly Font FontHeader = new Font("Segoe UI", 8,  FontStyle.Bold);
        private static readonly Font FontDayNum = new Font("Segoe UI", 9,  FontStyle.Bold);
        private static readonly Font FontPill   = new Font("Segoe UI", 7.5f);
        private static readonly Font FontPillSm = new Font("Segoe UI", 6.8f);

        // Row heights
        private const int HeaderH = 30;   // day-name row
        private const int Rows    = 6;    // calendar rows

        public CalendarCanvas()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.UserPaint, true);
            BackColor = Color.FromArgb(35, 35, 35);
        }

        public void SetData(int year, int month, List<CashFlowEvent> events)
        {
            _year  = year;
            _month = month;
            _byDay = new Dictionary<int, List<CashFlowEvent>>();

            foreach (var ev in events)
                if (ev.Date.Year == year && ev.Date.Month == month)
                {
                    int d = ev.Date.Day;
                    if (!_byDay.ContainsKey(d)) _byDay[d] = new List<CashFlowEvent>();
                    _byDay[d].Add(ev);
                }

            // Sort events within each day: income first, then priority order
            foreach (var list in _byDay.Values)
                list.Sort((a, b) =>
                {
                    int et = EventOrder(a).CompareTo(EventOrder(b));
                    return et != 0 ? et : a.Priority.CompareTo(b.Priority);
                });

            Invalidate();
        }

        private static int EventOrder(CashFlowEvent e)
        {
            switch (e.EventType)
            {
                case "Income":      return 0;
                case "Expense":     return 1;
                case "DueReminder": return 2;
                default:            return 3;
            }
        }

        protected override void OnResize(EventArgs e) { base.OnResize(e); Invalidate(); }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g   = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int w      = Width;
            int h      = Height;
            int cellW  = w / 7;
            int cellH  = Math.Max(110, (h - HeaderH) / Rows);

            // ── Day-name header ───────────────────────────────────────────────
            string[] dayNames = { "SUN", "MON", "TUE", "WED", "THU", "FRI", "SAT" };
            for (int d = 0; d < 7; d++)
            {
                var r = new Rectangle(d * cellW, 0, cellW - 1, HeaderH);
                using (var b = new SolidBrush(Color.FromArgb(20, 20, 20)))
                    g.FillRectangle(b, r);
                using (var b = new SolidBrush(Color.FromArgb(85, 85, 85)))
                    g.DrawString(dayNames[d], FontHeader, b, r,
                        new StringFormat { Alignment = StringAlignment.Center,
                                           LineAlignment = StringAlignment.Center });
            }

            // ── Day cells ─────────────────────────────────────────────────────
            if (_year == 0) return;

            DateTime monthStart = new DateTime(_year, _month, 1);
            int startDow        = (int)monthStart.DayOfWeek;   // 0=Sun
            int daysInMonth     = DateTime.DaysInMonth(_year, _month);

            for (int cell = 0; cell < 42; cell++)
            {
                int dayNum = cell - startDow + 1;
                int col    = cell % 7;
                int row    = cell / 7;
                var cellRect = new Rectangle(col * cellW, HeaderH + row * cellH,
                                             cellW - 1, cellH - 1);

                bool inMonth = dayNum >= 1 && dayNum <= daysInMonth;
                bool isToday = inMonth
                    && new DateTime(_year, _month, dayNum) == DateTime.Today;

                // ── Cell background ───────────────────────────────────────────
                Color bg = !inMonth ? Color.FromArgb(28, 28, 28)
                          : isToday  ? Color.FromArgb(28, 48, 75)
                          :            Color.FromArgb(40, 40, 40);
                using (var b = new SolidBrush(bg))
                    g.FillRectangle(b, cellRect);

                // Grid border
                using (var p = new Pen(Color.FromArgb(50, 50, 50)))
                    g.DrawRectangle(p, cellRect);

                // Today highlight ring
                if (isToday)
                    using (var p = new Pen(Color.FromArgb(51, 139, 213), 1.5f))
                        g.DrawRectangle(p,
                            cellRect.Left + 1, cellRect.Top + 1,
                            cellRect.Width - 2, cellRect.Height - 2);

                if (!inMonth) continue;

                // ── Day number ────────────────────────────────────────────────
                using (var b = new SolidBrush(isToday
                    ? Color.White : Color.FromArgb(120, 120, 120)))
                {
                    g.DrawString(dayNum.ToString(), FontDayNum, b,
                        cellRect.Right - 22, cellRect.Top + 4);
                }

                // ── Event pills ───────────────────────────────────────────────
                if (_byDay == null || !_byDay.TryGetValue(dayNum, out var dayEvents))
                    continue;

                int pillH   = 18;
                int pillGap = 2;
                int pillX   = cellRect.Left + 3;
                int pillW   = cellRect.Width - 6;
                int pillY   = cellRect.Top + 24;
                int maxPills= Math.Max(1, (cellH - 28) / (pillH + pillGap));
                int shown   = 0;

                foreach (var ev in dayEvents)
                {
                    if (shown >= maxPills - 1 && dayEvents.Count > maxPills)
                    {
                        int left = dayEvents.Count - shown;
                        using (var b = new SolidBrush(Color.FromArgb(90, 90, 90)))
                            g.DrawString($"+{left} more", FontPillSm, b,
                                pillX + 2f, pillY + 2f);
                        break;
                    }

                    DrawPill(g, ev, new Rectangle(pillX, pillY, pillW, pillH));
                    pillY += pillH + pillGap;
                    shown++;
                }
            }
        }

        private static void DrawPill(Graphics g, CashFlowEvent ev, Rectangle r)
        {
            Color bg, fg;
            string prefix = "";

            // Historical events (already happened, baked into starting balance)
            if (ev.Status == "Historical")
            {
                bg = Color.FromArgb(30, 30, 30);
                fg = Color.FromArgb(65, 65, 65);
                prefix = ev.EventType == "HistoricalIncome" ? "↑ " : "";

                using (var b = new SolidBrush(bg))
                    g.FillRectangle(b, r);

                string amt = ev.Amount > 0 ? $" ${ev.Amount:N0}" : "";
                string txt = $"{prefix}{ev.Name}{amt}";
                var fmt2 = new StringFormat
                {
                    Trimming = StringTrimming.EllipsisCharacter,
                    FormatFlags = StringFormatFlags.NoWrap,
                    LineAlignment = StringAlignment.Center
                };
                using (var b = new SolidBrush(fg))
                    g.DrawString(txt, FontPill, b,
                        new RectangleF(r.Left + 4, r.Top, r.Width - 5, r.Height), fmt2);
                return;
            }

            switch (ev.EventType)
            {
                case "Income":
                    bg = Color.FromArgb(15, 78, 35);
                    fg = Color.FromArgb(85, 225, 115);
                    prefix = "↑ ";
                    break;

                case "DueReminder":
                    bg = Color.FromArgb(38, 38, 38);
                    fg = Color.FromArgb(90, 90, 90);
                    prefix = "↩ ";
                    break;

                default: // Expense
                    // Food budget reservations — always bright so you see them clearly
                    if (ev.Type == "Food" && ev.Name.StartsWith("Food Budget"))
                    {
                        bg = ev.CannotPay
                            ? Color.FromArgb(100, 18, 18)
                            : Color.FromArgb(10, 60, 25);
                        fg = ev.CannotPay
                            ? Color.FromArgb(255, 90, 90)
                            : Color.FromArgb(110, 240, 140);
                        prefix = "🛒 ";
                        break;
                    }

                    if (ev.CannotPay)
                    { bg = Color.FromArgb(100, 18, 18); fg = Color.FromArgb(255, 90, 90);  prefix = "⚠ "; }
                    else if (ev.Status == "GraceExpired")
                    { bg = Color.FromArgb(120, 10, 10); fg = Color.FromArgb(255, 60, 60);  prefix = "!! "; }
                    else if (ev.Status == "AtRisk")
                    { bg = Color.FromArgb(110, 55, 0);  fg = Color.FromArgb(255, 165, 40); prefix = "⚠ "; }
                    else if (ev.IsPastDue)
                    { bg = Color.FromArgb(88, 35, 0);   fg = Color.FromArgb(255, 140, 60); prefix = "↺ "; }
                    else if (ev.IsDeferred)
                    { bg = Color.FromArgb(20, 55, 85);  fg = Color.FromArgb(90, 185, 240); }
                    else switch (ev.Status)
                    {
                        case "Covered":  bg = Color.FromArgb(14, 58, 28); fg = Color.FromArgb(75, 205, 105); break;
                        case "Tight":    bg = Color.FromArgb(68, 62, 12); fg = Color.FromArgb(235, 208, 70);  break;
                        default:         bg = Color.FromArgb(14, 58, 28); fg = Color.FromArgb(75, 205, 105); break;
                    }
                    break;
            }

            using (var b = new SolidBrush(bg))
                g.FillRectangle(b, r);

            // Build pill text
            string amount = ev.Amount > 0 ? $" ${ev.Amount:N0}" : "";
            string text;

            if (ev.EventType == "DueReminder")
                text = $"{prefix}{ev.Name} {ev.Status}";
            else if (ev.IsDeferred)
                text = $"↗ {ev.Name}{amount}  (was {ev.DueDate:MM/dd})";
            else if (ev.IsPastDue)
                text = $"{prefix}{ev.Name}{amount}  (due {ev.DueDate:MM/dd})";
            else
                text = $"{prefix}{ev.Name}{amount}";

            var fmt  = new StringFormat
            {
                Trimming    = StringTrimming.EllipsisCharacter,
                FormatFlags = StringFormatFlags.NoWrap,
                LineAlignment = StringAlignment.Center
            };
            var textRect = new RectangleF(r.Left + 4, r.Top, r.Width - 5, r.Height);

            using (var b = new SolidBrush(fg))
                g.DrawString(text, FontPill, b, textRect, fmt);
        }
    }

    // ── Bill Calendar form ────────────────────────────────────────────────────
    public class BillCalendarForm : UserControl
    {
        private Label           lblMonthTitle;
        private Button          btnPrev, btnNext;
        private TextBox         txtStartBalance;
        private DateTimePicker  dtpAsOf;
        private TextBox         txtWeeklyFood;
        private Label           lblIncomeVal, lblBillsVal, lblRemainingVal,
                                lblFoodVal, lblSavingsVal, lblCannotVal;
        private CalendarCanvas  canvas;
        private int _year, _month;

        public BillCalendarForm()
        {
            _year  = DateTime.Now.Year;
            _month = DateTime.Now.Month;
            BackColor = Color.FromArgb(46, 46, 46);
            BuildUI();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible && Program.ConnectionString != null)
                LoadData();
        }

        private void BuildUI()
        {
            // ── Header ───────────────────────────────────────────────────────
            var header = new Panel
            {
                Dock = DockStyle.Top, Height = 60,
                BackColor = Color.FromArgb(22, 22, 22)
            };

            btnPrev = MakeNavBtn("◄", 15);
            btnPrev.Click += (s, e) => NavigateMonth(-1);

            lblMonthTitle = new Label
            {
                AutoSize = false, Width = 220, Height = 32,
                Location = new Point(63, 12),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.FromArgb(51, 139, 213),
                Font = new Font("Mongolian Baiti", 13, FontStyle.Bold),
                Text = new DateTime(_year, _month, 1).ToString("MMMM yyyy")
            };

            btnNext = MakeNavBtn("►", 291);
            btnNext.Click += (s, e) => NavigateMonth(1);

            var lblBal = new Label
            {
                AutoSize = true, Location = new Point(340, 7),
                ForeColor = Color.FromArgb(110, 110, 110),
                Font = new Font("Segoe UI", 7.5f),
                Text = "Balance $"
            };

            txtStartBalance = new TextBox
            {
                Location = new Point(410, 5), Width = 90,
                BackColor = Color.FromArgb(38, 38, 38),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 10),
                Text = "0.00"
            };

            var lblAsOf = new Label
            {
                AutoSize = true, Location = new Point(340, 32),
                ForeColor = Color.FromArgb(110, 110, 110),
                Font = new Font("Segoe UI", 7.5f),
                Text = "As of"
            };

            dtpAsOf = new DateTimePicker
            {
                Location = new Point(370, 29), Width = 130,
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Today,
                CalendarForeColor = Color.White,
                CalendarMonthBackground = Color.FromArgb(38, 38, 38),
                CalendarTitleBackColor = Color.FromArgb(51, 139, 213),
                CalendarTitleForeColor = Color.White
            };

            var lblFood = new Label
            {
                AutoSize = true, Location = new Point(510, 7),
                ForeColor = Color.FromArgb(110, 110, 110),
                Font = new Font("Segoe UI", 7.5f),
                Text = "Wkly Food $"
            };

            txtWeeklyFood = new TextBox
            {
                Location = new Point(578, 5), Width = 70,
                BackColor = Color.FromArgb(38, 38, 38),
                ForeColor = Color.FromArgb(85, 225, 115),
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 10),
                Text = "150.00"
            };

            var btnCalc = new Button
            {
                Text = "Recalculate", Location = new Point(658, 14),
                Width = 100, Height = 28,
                BackColor = Color.FromArgb(51, 139, 213),
                ForeColor = Color.White, FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8, FontStyle.Bold)
            };
            btnCalc.FlatAppearance.BorderSize = 0;
            btnCalc.Click += (s, e) => LoadData();

            header.Controls.AddRange(new Control[]
                { btnPrev, lblMonthTitle, btnNext,
                  lblBal, txtStartBalance, lblAsOf, dtpAsOf,
                  lblFood, txtWeeklyFood, btnCalc });

            // ── Summary strip (stats row + legend row) ────────────────────────
            var summary = new Panel
            {
                Dock = DockStyle.Top, Height = 82,
                BackColor = Color.FromArgb(28, 28, 28)
            };

            int x = 18;
            Label l1; (l1, lblIncomeVal)    = MakeStat("Income This Month",    Color.FromArgb(85,225,115),  x); x += 175;
            Label l2; (l2, lblBillsVal)     = MakeStat("Bills Scheduled",      Color.Tomato,                x); x += 175;
            Label l3; (l3, lblCannotVal)    = MakeStat("Cannot Cover",         Color.OrangeRed,             x); x += 175;
            Label l4; (l4, lblRemainingVal) = MakeStat("End-of-Month Balance", Color.White,                 x); x += 175;
            Label l5; (l5, lblFoodVal)      = MakeStat("Est. Weekly Food",     Color.FromArgb(51,139,213),  x); x += 175;
            Label l6; (l6, lblSavingsVal)   = MakeStat("Weekly Savings",       Color.FromArgb(130,210,130), x);

            summary.Controls.AddRange(new Control[]
                { l1, lblIncomeVal, l2, lblBillsVal, l3, lblCannotVal,
                  l4, lblRemainingVal, l5, lblFoodVal, l6, lblSavingsVal });

            // Legend row inside summary panel
            int lx = 12;
            summary.Controls.Add(MakeLegendDot(Color.FromArgb(15,78,35),   Color.FromArgb(85,225,115),  "Income",         ref lx, 58));
            summary.Controls.Add(MakeLegendDot(Color.FromArgb(14,58,28),   Color.FromArgb(75,205,105),  "Covered",        ref lx, 62));
            summary.Controls.Add(MakeLegendDot(Color.FromArgb(68,62,12),   Color.FromArgb(235,208,70),  "Tight",          ref lx, 52));
            summary.Controls.Add(MakeLegendDot(Color.FromArgb(20,55,85),   Color.FromArgb(90,185,240),  "Deferred",       ref lx, 65));
            summary.Controls.Add(MakeLegendDot(Color.FromArgb(88,35,0),    Color.FromArgb(255,140,60),  "Past Due",       ref lx, 63));
            summary.Controls.Add(MakeLegendDot(Color.FromArgb(110,55,0),   Color.FromArgb(255,165,40),  "Grace ≤3 days",  ref lx, 85));
            summary.Controls.Add(MakeLegendDot(Color.FromArgb(120,10,10),  Color.FromArgb(255,60,60),   "Grace Expired!", ref lx, 88));
            summary.Controls.Add(MakeLegendDot(Color.FromArgb(100,18,18),  Color.FromArgb(255,90,90),   "Cannot Cover",   ref lx, 82));
            summary.Controls.Add(MakeLegendDot(Color.FromArgb(30,30,30),   Color.FromArgb(65,65,65),    "Historical",     ref lx, 68));

            // ── Calendar canvas ───────────────────────────────────────────────
            canvas = new CalendarCanvas { Dock = DockStyle.Fill };

            Controls.Add(canvas);
            Controls.Add(summary);
            Controls.Add(header);
        }

        // ── UI helpers ────────────────────────────────────────────────────────
        private Button MakeNavBtn(string text, int x)
        {
            var b = new Button
            {
                Text = text, Width = 40, Height = 32, Location = new Point(x, 12),
                BackColor = Color.FromArgb(51, 139, 213),
                ForeColor = Color.White, FlatStyle = FlatStyle.Flat
            };
            b.FlatAppearance.BorderSize = 0;
            return b;
        }

        private Label MakeLegendDot(Color bg, Color fg, string txt, ref int x, int width = 80)
        {
            var l = new Label
            {
                AutoSize = false, Width = width, Height = 16,
                Location = new Point(x, 62),   // bottom row of summary panel
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = bg, ForeColor = fg,
                Font = new Font("Segoe UI", 6.5f),
                Text = "  " + txt,
                Padding = new Padding(2, 0, 0, 0)
            };
            x += width + 3;
            return l;
        }

        private (Label lbl, Label val) MakeStat(string caption, Color valColor, int x)
        {
            var lbl = new Label
            {
                AutoSize = true, Location = new Point(x, 8),
                ForeColor = Color.FromArgb(100, 100, 100),
                Font = new Font("Segoe UI", 7.5f), Text = caption
            };
            var val = new Label
            {
                AutoSize = true, Location = new Point(x, 26),
                ForeColor = valColor,
                Font = new Font("Segoe UI", 10, FontStyle.Bold), Text = "$0.00"
            };
            return (lbl, val);
        }

        // ── Navigation ────────────────────────────────────────────────────────
        private void NavigateMonth(int delta)
        {
            var d  = new DateTime(_year, _month, 1).AddMonths(delta);
            _year  = d.Year;
            _month = d.Month;
            lblMonthTitle.Text = d.ToString("MMMM yyyy");

            // Viewing a future month → start from the 1st; past month → 1st as well
            // Current month → keep today so "as of" defaults to right now
            bool isCurrentMonth = (_year == DateTime.Today.Year && _month == DateTime.Today.Month);
            dtpAsOf.Value = isCurrentMonth ? DateTime.Today : new DateTime(_year, _month, 1);

            LoadData();
        }

        private decimal GetStartingBalance()
        {
            if (decimal.TryParse(txtStartBalance.Text.Replace("$", "").Replace(",", ""),
                NumberStyles.Any, CultureInfo.InvariantCulture, out decimal v))
                return v;
            return 0m;
        }

        private decimal GetWeeklyFood()
        {
            if (decimal.TryParse(txtWeeklyFood.Text.Replace("$", "").Replace(",", ""),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out decimal v) && v >= 0)
                return v;
            return 150m;
        }

        // ── Data ─────────────────────────────────────────────────────────────
        private void LoadData()
        {
            try
            {
                decimal startBal   = GetStartingBalance();
                DateTime asOf      = dtpAsOf.Value.Date;
                decimal weeklyFood = GetWeeklyFood();
                var summary = BudgetCalculator.Calculate(_year, _month, startBal, asOf, weeklyFood);

                lblIncomeVal.Text    = $"${summary.TotalMonthlyIncome:N2}";
                lblBillsVal.Text     = $"${summary.TotalMonthlyExpenses:N2}";
                lblRemainingVal.Text = $"${summary.NetAfterBills:N2}";
                lblRemainingVal.ForeColor = summary.NetAfterBills >= 0
                    ? Color.FromArgb(85, 225, 115) : Color.OrangeRed;

                // Food: show reserved/week. Red if any food weeks couldn't be covered.
                bool foodShortfall = summary.CashFlow
                    .Any(e => e.CannotPay && e.Type == "Food" && e.Name.StartsWith("Food Budget"));
                lblFoodVal.Text      = $"${summary.SuggestedWeeklyFood:N2} / wk";
                lblFoodVal.ForeColor = foodShortfall
                    ? Color.OrangeRed : Color.FromArgb(85, 225, 115);

                lblSavingsVal.Text = $"${summary.SuggestedWeeklySavings:N2} / wk";

                decimal cannotCover = summary.CashFlow
                    .Where(e => e.CannotPay && e.Type != "Food")  // food shortfalls shown separately
                    .Sum(e => e.Amount);
                lblCannotVal.Text      = cannotCover > 0 ? $"${cannotCover:N2}" : "$0.00";
                lblCannotVal.ForeColor = cannotCover > 0 ? Color.OrangeRed : Color.FromArgb(85, 225, 115);

                canvas.SetData(_year, _month, summary.CashFlow);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading calendar: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
