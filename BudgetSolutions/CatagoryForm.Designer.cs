﻿namespace BudgetSolutions
{
    partial class CatagoryForm
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.category_panel = new System.Windows.Forms.Panel();
            this.category_30late = new System.Windows.Forms.ComboBox();
            this.category_30latelabel = new System.Windows.Forms.Label();
            this.category_howmuch = new System.Windows.Forms.TextBox();
            this.category_passeddue = new System.Windows.Forms.ComboBox();
            this.category_latefee = new System.Windows.Forms.TextBox();
            this.category_grace = new System.Windows.Forms.ComboBox();
            this.category_amount = new System.Windows.Forms.TextBox();
            this.category_datepicker = new System.Windows.Forms.DateTimePicker();
            this.category_name = new System.Windows.Forms.TextBox();
            this.category_namelabel = new System.Windows.Forms.Label();
            this.category_duedatelabel = new System.Windows.Forms.Label();
            this.category_amountlabel = new System.Windows.Forms.Label();
            this.category_gracelabel = new System.Windows.Forms.Label();
            this.category_latefeelabel = new System.Windows.Forms.Label();
            this.category_passedlabel = new System.Windows.Forms.Label();
            this.category_howmuchlabel = new System.Windows.Forms.Label();
            this.category_type2 = new System.Windows.Forms.ComboBox();
            this.category_type = new System.Windows.Forms.ComboBox();
            this.category_category = new System.Windows.Forms.ComboBox();
            this.category_clear = new System.Windows.Forms.Button();
            this.category_addUpdate = new System.Windows.Forms.Button();
            this.category_typeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.category_panel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // category_panel
            // 
            this.category_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(178)))), ((int)(((byte)(184)))));
            this.category_panel.Controls.Add(this.category_30late);
            this.category_panel.Controls.Add(this.category_30latelabel);
            this.category_panel.Controls.Add(this.category_howmuch);
            this.category_panel.Controls.Add(this.category_passeddue);
            this.category_panel.Controls.Add(this.category_latefee);
            this.category_panel.Controls.Add(this.category_grace);
            this.category_panel.Controls.Add(this.category_amount);
            this.category_panel.Controls.Add(this.category_datepicker);
            this.category_panel.Controls.Add(this.category_name);
            this.category_panel.Controls.Add(this.category_namelabel);
            this.category_panel.Controls.Add(this.category_duedatelabel);
            this.category_panel.Controls.Add(this.category_amountlabel);
            this.category_panel.Controls.Add(this.category_gracelabel);
            this.category_panel.Controls.Add(this.category_latefeelabel);
            this.category_panel.Controls.Add(this.category_passedlabel);
            this.category_panel.Controls.Add(this.category_howmuchlabel);
            this.category_panel.Controls.Add(this.category_type2);
            this.category_panel.Controls.Add(this.category_type);
            this.category_panel.Controls.Add(this.category_category);
            this.category_panel.Controls.Add(this.category_clear);
            this.category_panel.Controls.Add(this.category_addUpdate);
            this.category_panel.Controls.Add(this.category_typeLabel);
            this.category_panel.Controls.Add(this.label1);
            this.category_panel.Location = new System.Drawing.Point(37, 35);
            this.category_panel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.category_panel.Name = "category_panel";
            this.category_panel.Size = new System.Drawing.Size(559, 1134);
            this.category_panel.TabIndex = 0;
            // 
            // category_30late
            // 
            this.category_30late.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(239)))), ((int)(((byte)(243)))));
            this.category_30late.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_30late.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.category_30late.FormattingEnabled = true;
            this.category_30late.Items.AddRange(new object[] {
            "No",
            "30 days or more?",
            "60 days or more?",
            "90 days or more?"});
            this.category_30late.Location = new System.Drawing.Point(55, 899);
            this.category_30late.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.category_30late.Name = "category_30late";
            this.category_30late.Size = new System.Drawing.Size(444, 38);
            this.category_30late.TabIndex = 25;
            this.category_30late.Visible = false;
            // 
            // category_30latelabel
            // 
            this.category_30latelabel.AutoSize = true;
            this.category_30latelabel.Font = new System.Drawing.Font("Mongolian Baiti", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_30latelabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.category_30latelabel.Location = new System.Drawing.Point(50, 866);
            this.category_30latelabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.category_30latelabel.Name = "category_30latelabel";
            this.category_30latelabel.Size = new System.Drawing.Size(171, 30);
            this.category_30latelabel.TabIndex = 24;
            this.category_30latelabel.Text = "30 days late?";
            this.category_30latelabel.Visible = false;
            // 
            // category_howmuch
            // 
            this.category_howmuch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(239)))), ((int)(((byte)(243)))));
            this.category_howmuch.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_howmuch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.category_howmuch.Location = new System.Drawing.Point(55, 807);
            this.category_howmuch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.category_howmuch.Name = "category_howmuch";
            this.category_howmuch.Size = new System.Drawing.Size(444, 40);
            this.category_howmuch.TabIndex = 23;
            this.category_howmuch.Visible = false;
            // 
            // category_passeddue
            // 
            this.category_passeddue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(239)))), ((int)(((byte)(243)))));
            this.category_passeddue.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_passeddue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.category_passeddue.FormattingEnabled = true;
            this.category_passeddue.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.category_passeddue.Location = new System.Drawing.Point(55, 716);
            this.category_passeddue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.category_passeddue.Name = "category_passeddue";
            this.category_passeddue.Size = new System.Drawing.Size(444, 38);
            this.category_passeddue.TabIndex = 22;
            this.category_passeddue.Visible = false;
            this.category_passeddue.SelectedIndexChanged += new System.EventHandler(this.category_passeddue_SelectedIndexChanged);
            // 
            // category_latefee
            // 
            this.category_latefee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(239)))), ((int)(((byte)(243)))));
            this.category_latefee.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_latefee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.category_latefee.Location = new System.Drawing.Point(55, 624);
            this.category_latefee.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.category_latefee.Name = "category_latefee";
            this.category_latefee.Size = new System.Drawing.Size(444, 40);
            this.category_latefee.TabIndex = 21;
            this.category_latefee.Visible = false;
            // 
            // category_grace
            // 
            this.category_grace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(239)))), ((int)(((byte)(243)))));
            this.category_grace.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_grace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.category_grace.FormattingEnabled = true;
            this.category_grace.Items.AddRange(new object[] {
            "none",
            "1 day",
            "2 days",
            "3 days",
            "4 days",
            "5 days",
            "6 days",
            "7 days",
            "8 days",
            "9 days",
            "10 days",
            "11 days",
            "12 days",
            "13 days",
            "14 days",
            "15 days"});
            this.category_grace.Location = new System.Drawing.Point(55, 528);
            this.category_grace.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.category_grace.Name = "category_grace";
            this.category_grace.Size = new System.Drawing.Size(444, 38);
            this.category_grace.TabIndex = 20;
            this.category_grace.Visible = false;
            // 
            // category_amount
            // 
            this.category_amount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(239)))), ((int)(((byte)(243)))));
            this.category_amount.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_amount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.category_amount.Location = new System.Drawing.Point(55, 432);
            this.category_amount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.category_amount.Name = "category_amount";
            this.category_amount.Size = new System.Drawing.Size(444, 40);
            this.category_amount.TabIndex = 19;
            this.category_amount.Visible = false;
            // 
            // category_datepicker
            // 
            this.category_datepicker.AllowDrop = true;
            this.category_datepicker.CalendarFont = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_datepicker.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.category_datepicker.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(239)))), ((int)(((byte)(243)))));
            this.category_datepicker.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.category_datepicker.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.category_datepicker.Checked = false;
            this.category_datepicker.Font = new System.Drawing.Font("Mongolian Baiti", 11.14286F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_datepicker.Location = new System.Drawing.Point(55, 338);
            this.category_datepicker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.category_datepicker.Name = "category_datepicker";
            this.category_datepicker.Size = new System.Drawing.Size(444, 37);
            this.category_datepicker.TabIndex = 18;
            this.category_datepicker.Visible = false;
            // 
            // category_name
            // 
            this.category_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(239)))), ((int)(((byte)(243)))));
            this.category_name.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.category_name.Location = new System.Drawing.Point(55, 244);
            this.category_name.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.category_name.Name = "category_name";
            this.category_name.Size = new System.Drawing.Size(444, 40);
            this.category_name.TabIndex = 17;
            this.category_name.Visible = false;
            // 
            // category_namelabel
            // 
            this.category_namelabel.AutoSize = true;
            this.category_namelabel.Font = new System.Drawing.Font("Mongolian Baiti", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_namelabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.category_namelabel.Location = new System.Drawing.Point(50, 210);
            this.category_namelabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.category_namelabel.Name = "category_namelabel";
            this.category_namelabel.Size = new System.Drawing.Size(135, 30);
            this.category_namelabel.TabIndex = 16;
            this.category_namelabel.Text = "Nickname";
            this.category_namelabel.Visible = false;
            // 
            // category_duedatelabel
            // 
            this.category_duedatelabel.AutoSize = true;
            this.category_duedatelabel.Font = new System.Drawing.Font("Mongolian Baiti", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_duedatelabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.category_duedatelabel.Location = new System.Drawing.Point(50, 305);
            this.category_duedatelabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.category_duedatelabel.Name = "category_duedatelabel";
            this.category_duedatelabel.Size = new System.Drawing.Size(126, 30);
            this.category_duedatelabel.TabIndex = 15;
            this.category_duedatelabel.Text = "Due Date";
            this.category_duedatelabel.Visible = false;
            // 
            // category_amountlabel
            // 
            this.category_amountlabel.AutoSize = true;
            this.category_amountlabel.Font = new System.Drawing.Font("Mongolian Baiti", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_amountlabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.category_amountlabel.Location = new System.Drawing.Point(50, 399);
            this.category_amountlabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.category_amountlabel.Name = "category_amountlabel";
            this.category_amountlabel.Size = new System.Drawing.Size(119, 30);
            this.category_amountlabel.TabIndex = 14;
            this.category_amountlabel.Text = "Amount ";
            this.category_amountlabel.Visible = false;
            // 
            // category_gracelabel
            // 
            this.category_gracelabel.AutoSize = true;
            this.category_gracelabel.Font = new System.Drawing.Font("Mongolian Baiti", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_gracelabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.category_gracelabel.Location = new System.Drawing.Point(50, 495);
            this.category_gracelabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.category_gracelabel.Name = "category_gracelabel";
            this.category_gracelabel.Size = new System.Drawing.Size(170, 30);
            this.category_gracelabel.TabIndex = 13;
            this.category_gracelabel.Text = "Grace Period";
            this.category_gracelabel.Visible = false;
            // 
            // category_latefeelabel
            // 
            this.category_latefeelabel.AutoSize = true;
            this.category_latefeelabel.Font = new System.Drawing.Font("Mongolian Baiti", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_latefeelabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.category_latefeelabel.Location = new System.Drawing.Point(50, 591);
            this.category_latefeelabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.category_latefeelabel.Name = "category_latefeelabel";
            this.category_latefeelabel.Size = new System.Drawing.Size(317, 30);
            this.category_latefeelabel.TabIndex = 12;
            this.category_latefeelabel.Text = "Late Fee Charge Amount";
            this.category_latefeelabel.Visible = false;
            // 
            // category_passedlabel
            // 
            this.category_passedlabel.AutoSize = true;
            this.category_passedlabel.Font = new System.Drawing.Font("Mongolian Baiti", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_passedlabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.category_passedlabel.Location = new System.Drawing.Point(50, 683);
            this.category_passedlabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.category_passedlabel.Name = "category_passedlabel";
            this.category_passedlabel.Size = new System.Drawing.Size(165, 30);
            this.category_passedlabel.TabIndex = 11;
            this.category_passedlabel.Text = "Passed Due?";
            this.category_passedlabel.Visible = false;
            // 
            // category_howmuchlabel
            // 
            this.category_howmuchlabel.AutoSize = true;
            this.category_howmuchlabel.Font = new System.Drawing.Font("Mongolian Baiti", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_howmuchlabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.category_howmuchlabel.Location = new System.Drawing.Point(50, 774);
            this.category_howmuchlabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.category_howmuchlabel.Name = "category_howmuchlabel";
            this.category_howmuchlabel.Size = new System.Drawing.Size(160, 30);
            this.category_howmuchlabel.TabIndex = 10;
            this.category_howmuchlabel.Text = "How Much?";
            this.category_howmuchlabel.Visible = false;
            // 
            // category_type2
            // 
            this.category_type2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(239)))), ((int)(((byte)(243)))));
            this.category_type2.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_type2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.category_type2.FormattingEnabled = true;
            this.category_type2.Items.AddRange(new object[] {
            "Utility bill",
            "Mortgage/Rent",
            "Childcare",
            "Phone Bill",
            "Internet",
            "Home Security",
            "Car Payment",
            "Car insurance",
            "Credit Card",
            "Loan",
            "Subscription",
            "Other- Bill",
            "Food",
            "Weekly Miscelleneous",
            "Monthly Miscelleneous",
            "Baby Weekly Expense",
            "Monthly Child Expense",
            "Weekly Transportation",
            "Weekly Gas",
            "Other Expense"});
            this.category_type2.Location = new System.Drawing.Point(55, 153);
            this.category_type2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.category_type2.Name = "category_type2";
            this.category_type2.Size = new System.Drawing.Size(444, 38);
            this.category_type2.TabIndex = 9;
            this.category_type2.Visible = false;
            this.category_type2.SelectedIndexChanged += new System.EventHandler(this.category_type2_SelectedIndexChanged);
            // 
            // category_type
            // 
            this.category_type.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(239)))), ((int)(((byte)(243)))));
            this.category_type.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_type.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.category_type.FormattingEnabled = true;
            this.category_type.Items.AddRange(new object[] {
            "Bi-weekly Paycheck",
            "Weekly Paycheck",
            "Monthly Paycheck",
            "VA Benefits",
            "BAH",
            "Settlement Payment",
            "Child Support Bi-weekly",
            "Child Support Weekly",
            "Child Support Monthly",
            "One Time Income",
            "Food Stamps",
            "Wic",
            "Other"});
            this.category_type.Location = new System.Drawing.Point(55, 153);
            this.category_type.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.category_type.Name = "category_type";
            this.category_type.Size = new System.Drawing.Size(444, 38);
            this.category_type.TabIndex = 8;
            this.category_type.Visible = false;
            // 
            // category_category
            // 
            this.category_category.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(239)))), ((int)(((byte)(243)))));
            this.category_category.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_category.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.category_category.FormattingEnabled = true;
            this.category_category.Items.AddRange(new object[] {
            "Income",
            "Expense"});
            this.category_category.Location = new System.Drawing.Point(55, 63);
            this.category_category.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.category_category.Name = "category_category";
            this.category_category.Size = new System.Drawing.Size(444, 38);
            this.category_category.TabIndex = 7;
            this.category_category.SelectedIndexChanged += new System.EventHandler(this.category_category_SelectedIndexChanged);
            // 
            // category_clear
            // 
            this.category_clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.category_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.category_clear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(239)))), ((int)(((byte)(243)))));
            this.category_clear.Location = new System.Drawing.Point(104, 977);
            this.category_clear.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.category_clear.Name = "category_clear";
            this.category_clear.Size = new System.Drawing.Size(345, 63);
            this.category_clear.TabIndex = 5;
            this.category_clear.Text = "CLEAR ALL FIELDS";
            this.category_clear.UseVisualStyleBackColor = false;
            // 
            // category_addUpdate
            // 
            this.category_addUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.category_addUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.category_addUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(239)))), ((int)(((byte)(243)))));
            this.category_addUpdate.Location = new System.Drawing.Point(104, 1050);
            this.category_addUpdate.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.category_addUpdate.Name = "category_addUpdate";
            this.category_addUpdate.Size = new System.Drawing.Size(345, 61);
            this.category_addUpdate.TabIndex = 3;
            this.category_addUpdate.Text = "ADD/UPDATE";
            this.category_addUpdate.UseVisualStyleBackColor = false;
            this.category_addUpdate.Click += new System.EventHandler(this.category_addUpdate_Click);
            // 
            // category_typeLabel
            // 
            this.category_typeLabel.AutoSize = true;
            this.category_typeLabel.Font = new System.Drawing.Font("Mongolian Baiti", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_typeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.category_typeLabel.Location = new System.Drawing.Point(50, 118);
            this.category_typeLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.category_typeLabel.Name = "category_typeLabel";
            this.category_typeLabel.Size = new System.Drawing.Size(74, 30);
            this.category_typeLabel.TabIndex = 2;
            this.category_typeLabel.Text = "Type";
            this.category_typeLabel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(50, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(178)))), ((int)(((byte)(184)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(631, 35);
            this.panel2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1419, 1134);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.label2.Location = new System.Drawing.Point(42, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 40);
            this.label2.TabIndex = 1;
            this.label2.Text = "Category List";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.panel3.Location = new System.Drawing.Point(50, 137);
            this.panel3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1320, 949);
            this.panel3.TabIndex = 0;
            // 
            // CatagoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(239)))), ((int)(((byte)(243)))));
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.category_panel);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "CatagoryForm";
            this.Size = new System.Drawing.Size(2081, 1213);
            this.category_panel.ResumeLayout(false);
            this.category_panel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel category_panel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label category_typeLabel;
        private System.Windows.Forms.ComboBox category_type;
        private System.Windows.Forms.ComboBox category_category;
        private System.Windows.Forms.Button category_clear;
        private System.Windows.Forms.Button category_addUpdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox category_type2;
        private System.Windows.Forms.TextBox category_name;
        private System.Windows.Forms.Label category_namelabel;
        private System.Windows.Forms.Label category_duedatelabel;
        private System.Windows.Forms.Label category_amountlabel;
        private System.Windows.Forms.Label category_gracelabel;
        private System.Windows.Forms.Label category_latefeelabel;
        private System.Windows.Forms.Label category_passedlabel;
        private System.Windows.Forms.Label category_howmuchlabel;
        private System.Windows.Forms.DateTimePicker category_datepicker;
        private System.Windows.Forms.ComboBox category_grace;
        private System.Windows.Forms.TextBox category_amount;
        private System.Windows.Forms.ComboBox category_passeddue;
        private System.Windows.Forms.TextBox category_latefee;
        private System.Windows.Forms.TextBox category_howmuch;
        private System.Windows.Forms.ComboBox category_30late;
        private System.Windows.Forms.Label category_30latelabel;
    }
}
