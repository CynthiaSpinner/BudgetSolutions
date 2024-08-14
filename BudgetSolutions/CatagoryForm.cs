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
            if(category_category.SelectedIndex == -1 || category_type.SelectedIndex == -1 || category_name.Text == "" || category_amount.Text == "")
            {
                MessageBox.Show("Please fill out all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void category_type2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if( category_type2.SelectedIndex <= 8) 
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
            else if(category_type2.SelectedIndex > 8)
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
