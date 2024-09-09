using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace BudgetSolutions
{
    
    public partial class CatagoryForm : UserControl
    {

        //my connection to SQL formatted file for local database storage

        string stringConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cynth\Documents\expense.mdf;Integrated Security=True;Connect Timeout=30";

        //methods called and initializing form to run functionality for form page

        public CatagoryForm()
        {
            InitializeComponent();

            displayExpenseData();

            displayIncomeData();
        }

        //displaying data in grid view format by calling lists

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

        //functionality of drop down menus

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
                category_depositLabel.Visible = false;
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

        private void category_type2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (category_type2.SelectedIndex <= 11)
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
            else if (category_type2.SelectedIndex > 11)
            {
                category_namelabel.Visible = true;
                category_name.Visible = true;
                category_amountlabel.Visible = true;
                category_amount.Visible = true;

                category_duedatelabel.Visible = true;
                category_datepicker.Visible = true;
                category_datepicker.Enabled = true;

                category_gracelabel.Visible = false;
                category_grace.Visible = false;
                category_grace.SelectedIndex = 0;

                category_latefee.Text = "";
                category_latefeelabel.Visible = false;
                category_latefee.Visible = false;

                category_passedlabel.Visible = false;
                category_passeddue.Visible = false;
                category_passeddue.SelectedIndex = 1;

                category_howmuchlabel.Visible = false;
                category_howmuch.Visible = false;
                category_howmuch.Text = "";

                category_30latelabel.Visible = false;
                category_30late.Visible = false;
                category_30late.SelectedIndex = 0;
            }
        }

        private void category_passeddue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (category_passeddue.SelectedIndex == 0)
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
                category_duedatelabel.Visible = false;
                category_datepicker.Visible = true;
                category_datepicker.Enabled = true;
                category_howmuchlabel.Visible = false;
                category_howmuch.Visible = false;
                category_30latelabel.Visible = false;
                category_30late.Visible = false;
            }
        }

        //null checking dropdowns and input fields

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
            else if (category_category.SelectedIndex == 1 && category_type2.SelectedIndex  < 0 || category_category.SelectedIndex == 1 && category_name.Text == "" ||
                category_category.SelectedIndex == 1 && category_amount.Text == "" || category_category.SelectedIndex == 1 && category_datepicker.Checked == false ||
                category_category.SelectedIndex == 1 && category_grace.SelectedIndex < 0 && category_type2.SelectedIndex <= 11|| category_category.SelectedIndex == 1 && category_latefee.Text == "" && category_type2.SelectedIndex <= 11 ||
                category_category.SelectedIndex == 1 && category_passeddue.SelectedIndex < 0 && category_type2.SelectedIndex <= 11)
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
            else
            {

            //establishing database connection and parsing of numerical input data to decimal. checking for correct decimal format and confirmation from user to continue to reduce user error

                if (category_category.SelectedIndex == 0)
                {
                    using (SqlConnection conn = new SqlConnection(stringConnection))
                    {
                        decimal userIncomeInput;

                        if (!decimal.TryParse(category_amount.Text, out userIncomeInput))
                        {
                            MessageBox.Show("Please enter amount in decimal format ex: 90.00", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (MessageBox.Show("Are you sure you want to add/update this item?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == DialogResult.Yes)
                            {

            //opening database connection, collecting user data, using stored procedure to check against data do minimize duplicates, and sending data to be saved in proper format in database
            //**** going to impliment a merge into the stored procedure instead of using insert, for better updating of ID automatic incrementation *****

                                conn.Open();

                                SqlCommand cmd = new SqlCommand("AddAndUpdateIncome", conn);
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.AddWithValue("@category_category", category_category.SelectedItem);
                                cmd.Parameters.AddWithValue("@category_type", category_type.SelectedItem);
                                cmd.Parameters.AddWithValue("@category_name", category_name.Text);
                                cmd.Parameters.AddWithValue("@category_datepicker", category_datepicker.Value.Date);
                                cmd.Parameters.AddWithValue("@category_amount", userIncomeInput);
            
                                cmd.ExecuteNonQuery();

            //properly stored message box shows confirmation of add or update ***going to impliment a message box for NOT added or updated successfully***

                                MessageBox.Show("Income added/updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //calling clear fields method to refresh form fields

                                clearFields();

            //closing connection

                                conn.Close();
                            }
                        }
                    }
                }

                if (category_category.SelectedIndex == 1 && category_type2.SelectedIndex <= 11)
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
                    else if (MessageBox.Show("Are you sure you want to add/update this item?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                         == DialogResult.Yes)
                    {
                        if (category_passeddue.SelectedIndex == 0 && category_type2.SelectedIndex <= 11)
                        {
                            SqlConnection conn = new SqlConnection(stringConnection);
                            
                            conn.Open();

                            SqlCommand cmd = new SqlCommand("AddAndUpdateExpense", conn);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@category_category", category_category.SelectedItem);
                            cmd.Parameters.AddWithValue("@category_type2", category_type2.SelectedItem);
                            cmd.Parameters.AddWithValue("@category_name", category_name.Text);
                            cmd.Parameters.AddWithValue("@category_datepicker", category_datepicker.Value.Date);
                            cmd.Parameters.AddWithValue("@category_amount", userInputAmount);
                            cmd.Parameters.AddWithValue("@category_grace", category_grace.SelectedItem);
                            cmd.Parameters.AddWithValue("@category_latefee", userInputLate);
                            cmd.Parameters.AddWithValue("@category_passeddue", category_passeddue.SelectedItem);
                            cmd.Parameters.AddWithValue("@category_howmuch", userInputDue);
                            cmd.Parameters.AddWithValue("@category_30late", category_30late.SelectedItem);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Expense Added/Updated Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            clearFields();

                            conn.Close();
                            
                        }
                        else if (category_passeddue.SelectedIndex == 1 && category_type2.SelectedIndex <= 11)
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
                                decimal userInputDue1 = 0;
                                var userInput30 = category_30late.SelectedIndex == 0;

                                SqlConnection conn = new SqlConnection(stringConnection);
                                
                                conn.Open();

                                SqlCommand cmd = new SqlCommand("AddAndUpdateExpense", conn);

                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.AddWithValue("@category_category", category_category.SelectedItem);
                                cmd.Parameters.AddWithValue("@category_type2", category_type2.SelectedItem);
                                cmd.Parameters.AddWithValue("@category_name", category_name.Text);
                                cmd.Parameters.AddWithValue("@category_datepicker", category_datepicker.Value.Date);
                                cmd.Parameters.AddWithValue("@category_amount", userInputAmount);
                                cmd.Parameters.AddWithValue("@category_grace", category_grace.SelectedItem);
                                cmd.Parameters.AddWithValue("@category_latefee", userInputLate);
                                cmd.Parameters.AddWithValue("@category_passeddue", category_passeddue.SelectedItem);
                                cmd.Parameters.AddWithValue("@category_howmuch", userInputDue1);
                                cmd.Parameters.AddWithValue("@category_30late", category_30late.SelectedIndex == -1);

                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Expense Added/Updated Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                clearFields();

                                conn.Close();
                                
                            }

                        }
                    }
                }
                else if (category_category.SelectedIndex == 1 && category_type2.SelectedIndex > 11)
                {
                    if (!decimal.TryParse(category_amount.Text, out userInputAmount))
                    {
                        MessageBox.Show("Please enter amount in decimal format ex: 90.00", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else if (MessageBox.Show("Are you sure you want to add/update this item?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                         == DialogResult.Yes)
                    {
                        decimal nullAmountDue1 = 0;
                        decimal nullLateFee = 0;

                        SqlConnection conn = new SqlConnection(stringConnection);

                        conn.Open();

                        SqlCommand cmd = new SqlCommand("AddAndUpdateExpense", conn);

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@category_category", category_category.SelectedItem);
                        cmd.Parameters.AddWithValue("@category_type2", category_type2.SelectedItem);
                        cmd.Parameters.AddWithValue("@category_name", category_name.Text);
                        cmd.Parameters.AddWithValue("@category_datepicker", category_datepicker.Value.Date);
                        cmd.Parameters.AddWithValue("@category_amount", userInputAmount);
                        cmd.Parameters.AddWithValue("@category_grace", category_grace.SelectedIndex == -1);
                        cmd.Parameters.AddWithValue("@category_latefee", nullLateFee);
                        cmd.Parameters.AddWithValue("@category_passeddue", category_passeddue.SelectedIndex == -1);
                        cmd.Parameters.AddWithValue("@category_howmuch", nullAmountDue1);
                        cmd.Parameters.AddWithValue("@category_30late", category_30late.SelectedIndex == -1);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Expense Added/Updated Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        clearFields();

                        conn.Close();
                    }
                }
            }

        // calling display methods to refresh data grid display. User can see data updates in "real time" lol

            displayExpenseData();
            displayIncomeData();
        }

        // selection of rows within data grid and sending information to auto fill form fields

        private int getID;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                getID = Convert.ToInt32(row.Cells[0].Value);
                category_category.SelectedItem = row.Cells[1].Value;
                category_type2.SelectedItem = row.Cells[2].Value;
                category_name.Text = row.Cells[3].Value.ToString();
                category_amount.Text = row.Cells[5].Value.ToString();
                category_grace.SelectedItem = row.Cells[6].Value;
                category_latefee.Text = row.Cells[7].Value.ToString();
                category_passeddue.SelectedItem = row.Cells[8].Value;
                category_howmuch.Text = row.Cells[9].Value.ToString();
                category_30late.SelectedItem = row.Cells[10].Value;

                category_type2_SelectedIndexChanged(sender, e);
                category_passeddue_SelectedIndexChanged(sender, e);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                getID = Convert.ToInt32(row.Cells[0].Value);
                category_category.SelectedItem = row.Cells[1].Value;
                category_type.SelectedItem = row.Cells[2].Value.ToString();
                category_name.Text = row.Cells[3].Value.ToString();
                category_amount.Text = row.Cells[5].Value.ToString();

                category_type_SelectedIndexChanged(sender, e);
            }
        }
        
        //clear all fields method

        public void clearFields()
        {
            category_category.SelectedIndex = -1;
            category_type.SelectedIndex = -1;
            category_type2.SelectedIndex = -1;
            category_name.Text = "";
            category_datepicker.Text = "";
            category_amount.Text = "";
            category_grace.SelectedIndex = -1;
            category_latefee.Text = "";
            category_passeddue.SelectedIndex = -1;
            category_howmuch.Text = "";
            category_30late.SelectedIndex = -1;

        }

        //calling clear fields method on clear fields button click

        private void category_clear_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        //on selected row selection, delete row on click of delete button

        private void category_delete_Click(object sender, EventArgs e)
        {


            if (category_category.SelectedIndex == 0)
            {


                if (MessageBox.Show("Are you sure you want to delete this item?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
                {
                    SqlConnection conn = new SqlConnection(stringConnection);

                    conn.Open();

                    string deleteDataIncome = "DELETE FROM income WHERE id = @id";


                    SqlCommand cmd = new SqlCommand(deleteDataIncome, conn);



                    cmd.Parameters.AddWithValue("@id", getID);


                    cmd.ExecuteNonQuery();


                    MessageBox.Show("Item Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    clearFields();

                    conn.Close();
                }
            }
            else if(category_category.SelectedIndex ==  1)
            {


                if (MessageBox.Show("Are you sure you want to delete this item?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
                {
                    SqlConnection conn = new SqlConnection(stringConnection);

                    conn.Open();

                    string deleteDataExpenses = "DELETE FROM expenses WHERE id = @id";


                    SqlCommand cmd = new SqlCommand(deleteDataExpenses, conn);



                    cmd.Parameters.AddWithValue("@id", getID);


                    cmd.ExecuteNonQuery();


                    MessageBox.Show("Item Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    clearFields();

                    conn.Close();
                }
            }

        //again "real time" updates

            displayExpenseData();

            displayIncomeData();
        }
        
    }
}
