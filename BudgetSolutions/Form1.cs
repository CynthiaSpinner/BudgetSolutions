using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace BudgetSolutions
{
    public partial class Form1 : Form
    {
        string stringConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cynth\Documents\expense.mdf;Integrated Security=True;Connect Timeout=30";
        public Form1()
        {
            InitializeComponent();
        }

       

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_createAcc_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();

            this.Hide();
        }

        private void login_showpass_CheckedChanged(object sender, EventArgs e)
        {
            login_password.PasswordChar = (login_showpass.Checked) ? '\0' : '*';
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            using(SqlConnection conn = new SqlConnection(stringConnection))
            {
                conn.Open();

                string selectInfo = "SELECT * FROM users WHERE username = @username AND password = @password";

                using(SqlCommand cmd = new SqlCommand(selectInfo, conn))
                {
                    cmd.Parameters.AddWithValue(@"username", login_username.Text.Trim());
                    cmd.Parameters.AddWithValue(@"Password", login_password.Text.Trim());

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    if (table.Rows.Count > 0)
                    {
                        MessageBox.Show("Login successful!", "Response", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Invalid username and/ password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }
    }
}
