using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace BudgetSolutions
{
    public partial class IncomeForm : UserControl
    {
        private Label lblMonthName;
        private Label lblTotalValue;

        public IncomeForm()
        {
            InitializeComponent();

            // Add month name and running total to panel2 (which already shows "Monthly Income" label)
            lblMonthName = new Label
            {
                AutoSize  = false, Width = 600, Height = 30,
                Location  = new Point(26, 76),
                ForeColor = Color.FromArgb(106, 124, 128),
                Font      = new Font("Segoe UI", 10, FontStyle.Italic),
                Text      = DateTime.Now.ToString("MMMM yyyy")
            };

            lblTotalValue = new Label
            {
                AutoSize  = false, Width = 600, Height = 52,
                Location  = new Point(26, 112),
                ForeColor = Color.LimeGreen,
                Font      = new Font("Mongolian Baiti", 22, FontStyle.Bold),
                Text      = "$0.00"
            };

            panel2.Controls.Add(lblMonthName);
            panel2.Controls.Add(lblTotalValue);

            StyleGrid(dataGridView1);
        }

        // Reload every time the panel is shown so data stays current
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible && !DesignMode && Program.ConnectionString != null)
                LoadMonthlyIncome(DateTime.Now.Year, DateTime.Now.Month);
        }

        private void StyleGrid(DataGridView dgv)
        {
            dgv.AutoGenerateColumns  = false;
            dgv.BackgroundColor      = Color.FromArgb(46, 46, 46);
            dgv.ForeColor            = Color.White;
            dgv.GridColor            = Color.FromArgb(60, 60, 60);
            dgv.BorderStyle          = BorderStyle.None;
            dgv.ReadOnly             = true;
            dgv.AllowUserToAddRows   = false;
            dgv.RowHeadersVisible    = false;
            dgv.SelectionMode        = DataGridViewSelectionMode.FullRowSelect;
            dgv.EnableHeadersVisualStyles = false;
            dgv.AutoSizeColumnsMode  = DataGridViewAutoSizeColumnsMode.Fill;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(22, 22, 22);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(51, 139, 213);
            dgv.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 9, FontStyle.Bold);
            dgv.DefaultCellStyle.BackColor              = Color.FromArgb(50, 50, 50);
            dgv.DefaultCellStyle.ForeColor              = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor     = Color.FromArgb(51, 100, 160);
            dgv.DefaultCellStyle.SelectionForeColor     = Color.White;
        }

        private void LoadMonthlyIncome(int year, int month)
        {
            try
            {
                dataGridView1.Columns.Clear();
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Category",   HeaderText = "Category",        FillWeight = 70  });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Type",        HeaderText = "Frequency",       FillWeight = 130 });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Source",      HeaderText = "Source / Name",   FillWeight = 150 });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "BaseDate",    HeaderText = "Start / Pay Date",FillWeight = 90  });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "PerCheck",    HeaderText = "Per Check",       FillWeight = 80  });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Times",       HeaderText = "× This Month",    FillWeight = 60  });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "MonthlyTotal",HeaderText = "Monthly Total",   FillWeight = 90  });

                dataGridView1.Rows.Clear();
                decimal total = 0m;

                using (var conn = new SqlConnection(Program.ConnectionString))
                {
                    conn.Open();
                    // Fetch all income — frequency determines how many times it hits this month
                    using (var cmd = new SqlCommand(
                        @"SELECT category, type, name, date, ISNULL(amount, 0) AS amount
                          FROM income
                          ORDER BY date", conn))
                    {
                        using (var r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                string iType = r["type"].ToString();
                                decimal perCheck = (decimal)r["amount"];
                                DateTime baseDate = r["date"] == DBNull.Value
                                    ? new DateTime(year, month, 1)
                                    : (DateTime)r["date"];

                                var (occurrences, monthlyAmt) = BudgetCalculator.GetMonthlyContribution(
                                    iType, baseDate, perCheck, year, month);

                                // Skip one-time / settlement entries that don't land this month
                                if (occurrences == 0) continue;

                                total += monthlyAmt;

                                int idx = dataGridView1.Rows.Add(
                                    r["category"].ToString(),
                                    iType,
                                    r["name"].ToString(),
                                    baseDate.ToString("MM/dd/yyyy"),
                                    $"${perCheck:N2}",
                                    occurrences == 1 ? "1×" : $"{occurrences}×",
                                    $"${monthlyAmt:N2}"
                                );

                                // Highlight bi-weekly/weekly rows that hit more than twice
                                if (occurrences >= 3)
                                {
                                    dataGridView1.Rows[idx].DefaultCellStyle.ForeColor = System.Drawing.Color.LimeGreen;
                                    dataGridView1.Rows[idx].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(22, 55, 30);
                                }
                            }
                        }
                    }
                }

                if (dataGridView1.Rows.Count == 0)
                    dataGridView1.Rows.Add("", "", "No income recorded for this month.", "", "", "", "");

                lblTotalValue.Text = $"${total:N2}";
                lblMonthName.Text  = new DateTime(year, month, 1).ToString("MMMM yyyy");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading income: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
