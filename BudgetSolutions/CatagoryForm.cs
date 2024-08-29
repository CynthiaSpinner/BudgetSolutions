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

            displayExpenseData();

            displayIncomeData();
        }

        public void displayExpenseData()
        {
            ExpenseData eData  = new ExpenseData();
            List<ExpenseData> listExpense = eData.ExpenseListData();

            dataGridView1.DataSource = listExpense;
        }

        public void displayIncomeData()
        {
            IncomeData iData = new IncomeData();
            List<IncomeData> listIncome = iData.IncomeListData();

            dataGridView2.DataSource = listIncome;
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
            else if (category_category.SelectedIndex == 1)
            {
                category_typeLabel.Visible = true;
                category_type2.Visible = true;
                category_type.Visible = false;
                category_depositLabel.Visible = false;
                category_datepicker.Visible=false;
                category_duedatelabel.Visible=false;
                category_amountlabel.Visible=false;
                category_amount.Visible = false;   
                category_namelabel.Visible = false;
                category_name.Visible = false;
            }
        }

        private void category_addUpdate_Click(object sender, EventArgs e)
        {
            decimal userInputAmount;
            decimal userInputLate;
            decimal userInputDue;
           


            if (category_category.SelectedIndex < 0 && category_type2.SelectedIndex < 0 || category_category.SelectedIndex < 0 && category_name.Text == "" ||
                category_category.SelectedIndex < 0 && category_amount.Text == "" || category_category.SelectedIndex < 0 && category_datepicker.Checked == false ||
                category_category.SelectedIndex < 0 && category_grace.SelectedIndex < 0 || category_category.SelectedIndex < 0 && category_latefee.Text == "" ||
                category_category.SelectedIndex < 0 && category_passeddue.SelectedIndex < 0)
            {
                MessageBox.Show("Please fill out all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (category_category.SelectedIndex == 1 && category_type2.SelectedIndex < 0 || category_category.SelectedIndex == 1 && category_name.Text == "" ||
                category_category.SelectedIndex == 1 && category_amount.Text == "" || category_category.SelectedIndex == 1 && category_datepicker.Checked == false ||
                category_category.SelectedIndex == 1 && category_grace.SelectedIndex < 0 || category_category.SelectedIndex == 1 && category_latefee.Text == "" ||
                category_category.SelectedIndex == 1 && category_passeddue.SelectedIndex < 0)
            {
                MessageBox.Show("Please fill out all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (category_passeddue.SelectedIndex == 0 && category_howmuch.Text == "" || category_passeddue.SelectedIndex == 0 && category_30late.SelectedIndex < 0)
            {
                MessageBox.Show("Please fill out all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (category_category.SelectedIndex == 0 && category_type.SelectedIndex < 0 || category_category.SelectedIndex == 0 && category_name.Text == "" ||
                category_category.SelectedIndex == 0 && category_datepicker.Checked == false || category_category.SelectedIndex == 0 && category_amount.Text == "")
            {
                MessageBox.Show("Please fill out all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
  
            if(category_category.SelectedIndex == 0)
            {
                using (SqlConnection conn  = new SqlConnection(stringConnection))
                {
                    decimal userIncomeInput;
                    if (!decimal.TryParse(category_amount.Text, out userIncomeInput))
                    {
                        MessageBox.Show("Please enter amount in decimal format ex: 90.00", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        conn.Open();
                        string insertIncomeData = "INSERT INTO income (type, name, date, amount)" +
                            "VALUES(@category_type, @category_name, @category_datepicker, @category_amount)";

                        using (SqlCommand cmd = new SqlCommand(insertIncomeData, conn))
                        {

                            cmd.Parameters.AddWithValue("@category_type", category_type.SelectedItem);
                            cmd.Parameters.AddWithValue("@category_name", category_name.Text.Trim());
                            cmd.Parameters.AddWithValue("@category_datepicker", category_datepicker.Value.Date);
                            cmd.Parameters.AddWithValue("@category_amount", userIncomeInput);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Income added successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            conn.Close();
                        }
                    }
                }
            }

            if (category_category.SelectedIndex == 1)
            {
                if (!decimal.TryParse(category_amount.Text, out userInputAmount))
                {
                    MessageBox.Show("Please enter amount in decimal format ex: 90.00", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (!decimal.TryParse(category_latefee.Text, out userInputLate))
                {
                    MessageBox.Show("Please enter amount in decimal format ex: 90.00", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!decimal.TryParse(category_howmuch.Text, out userInputDue))
                {
                    MessageBox.Show("Please enter amount in decimal format ex: 90.00", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(MessageBox.Show("Are you sure you want to add this item?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                     == DialogResult.Yes)
                {
                    if (category_passeddue.SelectedIndex == 0)
                    {
                        using (SqlConnection conn = new SqlConnection(stringConnection))
                        {
                            conn.Open();

                            //string updateExpenseData = "UPDATE expenses SET category = @category_category, type = @category_type2, name = @category_name WHERE id = @id";
                            // add stored procedure for add an update.
                            
                            string insertExpenseData = "INSERT INTO expenses (category, type, name, date, amount, grace, lateFee, passed, passedAmount, creditIssue)" +
                                "VALUES(@category_category, @category_type2, @category_name, @category_datepicker, @category_amount, @category_grace, @category_latefee, @category_passeddue, @category_howmuch, @category_30late)";
                            
                            using (SqlCommand cmd = new SqlCommand(insertExpenseData, conn))
                            {
                                cmd.Parameters.AddWithValue("@category_category", category_category.SelectedItem);
                                cmd.Parameters.AddWithValue("@category_type2", category_type2.SelectedItem);
                                cmd.Parameters.AddWithValue("@category_name", category_name.Text.Trim());

                                cmd.Parameters.AddWithValue("@category_datepicker", category_datepicker.Value.Date);

                                

                                cmd.Parameters.AddWithValue("category_amount", userInputAmount);

                                cmd.Parameters.AddWithValue("@category_grace", category_grace.SelectedItem);

                                

                                cmd.Parameters.AddWithValue("@category_latefee", userInputLate);
                                cmd.Parameters.AddWithValue("@category_passeddue", category_passeddue.SelectedItem);


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
                        if (!decimal.TryParse(category_amount.Text, out userInputAmount))
                        {
                            MessageBox.Show("Please enter amount in decimal format ex: 90.00", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else if (!decimal.TryParse(category_latefee.Text, out userInputLate))
                        {
                            MessageBox.Show("Please enter amount in decimal format ex: 90.00", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            using (SqlConnection conn = new SqlConnection(stringConnection))
                            {
                                conn.Open();

                                string insertExpenseData = "INSERT INTO expenses (category, type, name, date, amount, grace, lateFee, passed)" +
                                    "VALUES(@category_category, @category_type2, @category_name, @category_datepicker, @category_amount, @category_grace, @category_latefee, @category_passeddue)";

                                using (SqlCommand cmd = new SqlCommand(insertExpenseData, conn))
                                {
                                    cmd.Parameters.AddWithValue("@category_category", category_category.SelectedItem);
                                    cmd.Parameters.AddWithValue("@category_type2", category_type2.SelectedItem);
                                    cmd.Parameters.AddWithValue("@category_name", category_name.Text.Trim());

                                    cmd.Parameters.AddWithValue("@category_datepicker", category_datepicker.Value.Date);
                                    cmd.Parameters.AddWithValue("@category_amount", userInputAmount);

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

        private void category_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (category_type.SelectedIndex >= 0)
            {
                category_namelabel.Visible = true;
                category_name.Visible = true;
                category_amountlabel.Visible = true;
                category_amount.Visible = true;
                category_depositLabel.Visible = true;
                category_datepicker.Visible = true;
                category_datepicker.Enabled = true;
                //amount
                //date 
            }
        }
        private int getID = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                getID = Convert.ToInt32(row.Cells[0].Value);
                category_category.SelectedItem = row.Cells[1].Value;
                category_type2.SelectedItem = row.Cells[2].Value.ToString();
                category_name.Text = row.Cells[3].Value.ToString();
                category_amount.Text = row.Cells[5].Value.ToString();
                category_grace.SelectedItem = row.Cells[6].Value.ToString();
                category_latefee.Text = row.Cells[7].Value.ToString();
                category_passeddue.SelectedItem = row.Cells[8].Value.ToString();
                category_howmuch.Text = row.Cells[9].Value.ToString();
                category_30late.SelectedItem = row.Cells[10].Value.ToString();

            }
        }
    }
}
