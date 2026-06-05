using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BudgetSolutions
{
    public partial class MainForm : Form
    {
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        private Dashboard1 dashboard1;
        private BillCalendarForm billCalendarForm1;

        public MainForm()
        {
            InitializeComponent();

            // Add Dashboard and Bill Calendar to the same content container as catagoryForm1
            var contentParent = catagoryForm1.Parent;

            dashboard1 = new Dashboard1
            {
                Visible  = false,
                Dock     = catagoryForm1.Dock,
                Anchor   = catagoryForm1.Anchor,
                Bounds   = catagoryForm1.Bounds
            };
            contentParent.Controls.Add(dashboard1);

            billCalendarForm1 = new BillCalendarForm
            {
                Visible  = false,
                Dock     = catagoryForm1.Dock,
                Anchor   = catagoryForm1.Anchor,
                Bounds   = catagoryForm1.Bounds
            };
            contentParent.Controls.Add(billCalendarForm1);

            // Drag-to-move on header and side panel
            panel2.MouseDown += Panel_MouseDown;
            panel1.MouseDown += Panel_MouseDown;

            // Navigation
            button1.Click          += (s, e) => ShowPanel(dashboard1);
            addCatagory_btn.Click  += (s, e) => ShowPanel(catagoryForm1);
            income_btn.Click       += (s, e) => ShowPanel(incomeForm1);
            expense_btn.Click      += (s, e) => ShowPanel(catagoryForm1);
            billCalender_btn.Click += (s, e) => ShowPanel(billCalendarForm1);

            ShowPanel(catagoryForm1);
        }

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, (IntPtr)0x2, IntPtr.Zero);
            }
        }

        private void ShowPanel(Control panel)
        {
            catagoryForm1.Visible     = false;
            incomeForm1.Visible       = false;
            dashboard1.Visible        = false;
            billCalendarForm1.Visible = false;

            if (panel != null)
                panel.Visible = true;
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You sure you want to log out?", "Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();
                this.Hide();
            }
        }
    }
}
