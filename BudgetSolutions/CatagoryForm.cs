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
    
    public partial class CatagoryForm : UserControl
    {
        string stringConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cynth\Documents\expense.mdf;Integrated Security=True;Connect Timeout=30";
        public CatagoryForm()
        {
            InitializeComponent();
        }

        private void category_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (category_category.SelectedIndex == 0)
            {
                category_typeLabel.Visible = true;
                category_type.Visible = true;
                category_type2.Visible = false;
                category_namelabel.Visible = false;
                category_name.Visible = false;
                category_amountlabel.Visible = false;
                category_amount.Visible = false;
                category_duedatelabel.Visible = false;
                category_datepicker.Visible = false;
                category_datepicker.Enabled = false;
                category_gracelabel.Visible = false;
                category_grace.Visible = false;
                category_latefeelabel.Visible = false;
                category_latefee.Visible = false;
                category_passedlabel.Visible = false;
                category_passeddue.Visible = false;
                category_howmuchlabel.Visible = false;
                category_howmuch.Visible = false;
                category_30latelabel.Visible = false;
                category_30late.Visible = false;

            }
            else
            {
                category_typeLabel.Visible = true;
                category_type2.Visible = true;
                category_type.Visible = false;
            }
        }

        private void category_addUpdate_Click(object sender, EventArgs e)
        {
            decimal userInputAmount;
            decimal userInputLate;
            decimal userInputDue;


            if (category_category.SelectedIndex < 0 || category_type2.SelectedIndex < 0 || category_name.Text == "" || category_amount.Text == "" || category_datepicker.Checked == false || category_grace.SelectedIndex < 0 || category_latefee.Text == "" || category_passeddue.SelectedIndex < 0)
            {
                MessageBox.Show("Please fill out all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (category_passeddue.SelectedIndex == 0 && category_howmuch.Text == "" || category_passeddue.SelectedIndex == 0 && category_30late.SelectedIndex < 0)
            {
                MessageBox.Show("Please fill out all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!decimal.TryParse(category_amount.Text, out userInputAmount))
            {
                MessageBox.Show("Please enter amount in decimal format ex: 90.00", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(!decimal.TryParse(category_latefee.Text, out userInputLate))
            {
                MessageBox.Show("Please enter amount in decimal format ex: 90.00", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            else
            {
                if (MessageBox.Show("Are your sure you want to add this item?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                     == DialogResult.Yes)
                {
                    if (category_passeddue.SelectedIndex == 0)
                    {
                        using (SqlConnection conn = new SqlConnection(stringConnection))
                        {
                            conn.Open();

                            string insertExpenseData = "INSERT INTO expenses (type, name, date, amount, grace, lateFee, passed, passedAmount, creditIssue)" +
                                "VALUES(@category_type2, @category_name, @category_datepicker, @category_amount, @category_grace, @category_latefee, @category_passeddue, @category_howmuch, @category_30late)";

                            using (SqlCommand cmd = new SqlCommand(insertExpenseData, conn))
                            {
                                cmd.Parameters.AddWithValue("@category_type2", category_type2.SelectedItem);
                                cmd.Parameters.AddWithValue("@category_name", category_name.Text.Trim());

                                cmd.Parameters.AddWithValue("@category_datepicker", category_datepicker.Value.Date);
                                cmd.Parameters.AddWithValue("category_amount", userInputAmount);

                                cmd.Parameters.AddWithValue("@category_grace", category_grace.SelectedItem);

                                cmd.Parameters.AddWithValue("@category_latefee", userInputLate);
                                cmd.Parameters.AddWithValue("@category_passeddue", category_passeddue.SelectedItem);

                                if (!decimal.TryParse(category_howmuch.Text, out userInputDue))
                                {
                                    MessageBox.Show("Please enter amount in decimal format ex: 90.00", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                cmd.Parameters.AddWithValue("@category_howmuch", userInputDue);
                                cmd.Parameters.AddWithValue("@category_30late", category_30late.SelectedItem);

                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Expense Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                conn.Close();


                            }
                        }

                    }
                    else
                    {
                        using (SqlConnection conn = new SqlConnection(stringConnection))
                        {
                            conn.Open();

                            string insertExpenseData = "INSERT INTO expenses (type, name, date, amount, grace, lateFee, passed)" +
                                "VALUES(@category_type2, @category_name, @category_datepicker, @category_amount, @category_grace, @category_latefee, @category_passeddue)";

                            using (SqlCommand cmd = new SqlCommand(insertExpenseData, conn))
                            {
                                cmd.Parameters.AddWithValue("@category_type2", category_type2.SelectedItem);
                                cmd.Parameters.AddWithValue("@category_name", category_name.Text.Trim());

                                cmd.Parameters.AddWithValue("@category_datepicker", category_datepicker.Value.Date);
                                cmd.Parameters.AddWithValue("category_amount", userInputAmount);

                                cmd.Parameters.AddWithValue("@category_grace", category_grace.SelectedItem);

                                cmd.Parameters.AddWithValue("@category_latefee", userInputLate);
                                cmd.Parameters.AddWithValue("@category_passeddue", category_passeddue.SelectedItem);

                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Expense Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                conn.Close();


                            }
                        }
                    }
                }
            }
        }

        private void category_type2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if( category_type2.SelectedIndex <= 11) 
            {
                category_namelabel.Visible = true;
                category_name.Visible = true;
                category_amountlabel.Visible = true;
                category_amount.Visible = true;
                category_duedatelabel.Visible = true;
                category_datepicker.Visible = true;
                category_datepicker.Enabled = true;
                category_gracelabel.Visible = true;
                category_grace.Visible = true;
                category_latefeelabel.Visible = true;
                category_latefee.Visible = true;
                category_passedlabel.Visible = true;
                category_passeddue.Visible = true;
                category_howmuchlabel.Visible = false;
                category_howmuch.Visible = false;
                category_30latelabel.Visible = false;
                category_30late.Visible = false;
                

            }
            else if(category_type2.SelectedIndex > 11)
            {
                category_namelabel.Visible = true;
                category_name.Visible = true;
                category_amountlabel.Visible = true;
                category_amount.Visible = true;
                category_duedatelabel.Visible = false;
                category_datepicker.Visible = false;
                category_gracelabel.Visible = false;
                category_grace.Visible = false;
                category_latefeelabel.Visible = false;
                category_latefee.Visible = false;
                category_passedlabel.Visible = false;
                category_passeddue.Visible = false;
                category_howmuchlabel.Visible = false;
                category_howmuch.Visible = false;
                category_30latelabel.Visible = false;
                category_30late.Visible = false;
                category_passeddue.SelectedIndex = 1;
                category_grace.SelectedIndex = 0;
                category_datepicker.Enabled = false;
            }


        }

        private void category_passeddue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(category_passeddue.SelectedIndex == 0) 
            {
                category_howmuchlabel.Visible = true;
                category_howmuch.Visible = true;
                category_30latelabel.Visible = true;
                category_30late.Visible = true;
            }
            else
            {
                category_howmuchlabel.Visible = false;
                category_howmuch.Visible = false;
                category_30latelabel.Visible = false;
                category_30late.Visible = false;
            }
        }
    }
}
