using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BudgetSolutions
{
    public partial class RegisterForm : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cynth\Documents\expense.mdf;Integrated Security=True;Connect Timeout=30");
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void register_loginbutton_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();

            this.Hide();
        }

        public bool checkConnection()
        {
            return (connect.State == ConnectionState.Closed) ? true : false;
        }
        private void register_showpass_CheckedChanged(object sender, EventArgs e)
        {
            register_password.PasswordChar = register_showpass.Checked ? '\0' : '*';
            register_confirmpass.PasswordChar = register_showpass.Checked ? '\0' : '*';
        }

        private void register_button_Click(object sender, EventArgs e)
        {
            if(register_username.Text == "" || register_password.Text == "" || register_confirmpass.Text == "")
            {
                MessageBox.Show("Please fill in all blank fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (checkConnection())
                {
                    try
                    {
                        connect.Open();
                        //checking if the usernae already exists
                        string selectUsername = "SELECT * FROM users WHERE username = @username";

                        using(SqlCommand checkUser = new SqlCommand(selectUsername, connect)) 
                        {
                            checkUser.Parameters.AddWithValue("@username", register_username.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(checkUser);
                            DataTable table = new DataTable();

                            adapter.Fill(table);

                            if(table.Rows.Count != 0)
                            {
                                //making the first letter capitol
                                string tempUsername = register_username.Text.Substring(0, 1).ToUpper() + register_username.Text.Substring(1);
                                MessageBox.Show(tempUsername + "This username already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }else if(register_password.Text.Length < 8)
                            {
                                MessageBox.Show("Your password must contain more then 8 characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }else if(register_password.Text != register_confirmpass.Text)
                            {
                                MessageBox.Show("Make sure your passwords match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string insertInfo = "INSERT INTO users (username, password, date_create) VALUES(@username, @password, @date_create)";

                                using(SqlCommand insertUser = new SqlCommand(insertInfo, connect))
                                {
                                    insertUser.Parameters.AddWithValue("@username", register_username.Text.Trim());
                                    insertUser.Parameters.AddWithValue("@password", register_password.Text.Trim());

                                    DateTime today = DateTime.Today; // immediate time and date
                                    insertUser.Parameters.AddWithValue("@date_create", today);

                                    insertUser.ExecuteNonQuery();

                                    MessageBox.Show("Account created successfully", "Response", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    Form1 loginForm = new Form1();
                                    loginForm.Show();

                                    this.Hide();

                                }
                            }
                            
                        }

                    }catch(Exception ex)
                    {
                        MessageBox.Show("Connection failed: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }
    }
}
