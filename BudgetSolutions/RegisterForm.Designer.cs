namespace BudgetSolutions
{
    partial class RegisterForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.register_loginbutton = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.register_showpass = new System.Windows.Forms.CheckBox();
            this.register_button = new System.Windows.Forms.Button();
            this.register_password = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.close = new System.Windows.Forms.Label();
            this.register_username = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.register_confirmpass = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(178)))), ((int)(((byte)(184)))));
            this.panel1.Controls.Add(this.register_loginbutton);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(214, 483);
            this.panel1.TabIndex = 8;
            // 
            // register_loginbutton
            // 
            this.register_loginbutton.AutoSize = true;
            this.register_loginbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.register_loginbutton.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.register_loginbutton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.register_loginbutton.Location = new System.Drawing.Point(66, 390);
            this.register_loginbutton.Name = "register_loginbutton";
            this.register_loginbutton.Size = new System.Drawing.Size(73, 20);
            this.register_loginbutton.TabIndex = 8;
            this.register_loginbutton.Text = "Sign In";
            this.register_loginbutton.Click += new System.EventHandler(this.register_loginbutton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BudgetSolutions.Properties.Resources.icons8_money_bag_96;
            this.pictureBox1.Location = new System.Drawing.Point(54, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.label2.Location = new System.Drawing.Point(21, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "BudgetSolutions";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // register_showpass
            // 
            this.register_showpass.AutoSize = true;
            this.register_showpass.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(239)))), ((int)(((byte)(243)))));
            this.register_showpass.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.register_showpass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(223)))), ((int)(((byte)(231)))));
            this.register_showpass.Location = new System.Drawing.Point(476, 342);
            this.register_showpass.Name = "register_showpass";
            this.register_showpass.Size = new System.Drawing.Size(109, 18);
            this.register_showpass.TabIndex = 16;
            this.register_showpass.Text = "Show Password";
            this.register_showpass.UseVisualStyleBackColor = true;
            this.register_showpass.CheckedChanged += new System.EventHandler(this.register_showpass_CheckedChanged);
            // 
            // register_button
            // 
            this.register_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(223)))), ((int)(((byte)(231)))));
            this.register_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.register_button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(178)))), ((int)(((byte)(184)))));
            this.register_button.FlatAppearance.BorderSize = 2;
            this.register_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.register_button.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.register_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.register_button.Location = new System.Drawing.Point(272, 388);
            this.register_button.Name = "register_button";
            this.register_button.Size = new System.Drawing.Size(92, 31);
            this.register_button.TabIndex = 15;
            this.register_button.Text = "CREATE";
            this.register_button.UseVisualStyleBackColor = false;
            this.register_button.Click += new System.EventHandler(this.register_button_Click);
            // 
            // register_password
            // 
            this.register_password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(239)))), ((int)(((byte)(243)))));
            this.register_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.register_password.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.register_password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.register_password.Location = new System.Drawing.Point(272, 224);
            this.register_password.Name = "register_password";
            this.register_password.PasswordChar = '*';
            this.register_password.Size = new System.Drawing.Size(308, 26);
            this.register_password.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(223)))), ((int)(((byte)(231)))));
            this.label5.Location = new System.Drawing.Point(268, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Password:";
            // 
            // close
            // 
            this.close.AutoSize = true;
            this.close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(223)))), ((int)(((byte)(231)))));
            this.close.Location = new System.Drawing.Point(631, 9);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(16, 14);
            this.close.TabIndex = 9;
            this.close.Text = "X";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // register_username
            // 
            this.register_username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(239)))), ((int)(((byte)(243)))));
            this.register_username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.register_username.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.register_username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.register_username.Location = new System.Drawing.Point(272, 144);
            this.register_username.Name = "register_username";
            this.register_username.Size = new System.Drawing.Size(308, 26);
            this.register_username.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(223)))), ((int)(((byte)(231)))));
            this.label4.Location = new System.Drawing.Point(268, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(223)))), ((int)(((byte)(231)))));
            this.label3.Location = new System.Drawing.Point(267, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 30);
            this.label3.TabIndex = 10;
            this.label3.Text = "Create Account";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(223)))), ((int)(((byte)(231)))));
            this.label1.Location = new System.Drawing.Point(271, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Confirm Password:";
            // 
            // register_confirmpass
            // 
            this.register_confirmpass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(239)))), ((int)(((byte)(243)))));
            this.register_confirmpass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.register_confirmpass.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.register_confirmpass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.register_confirmpass.Location = new System.Drawing.Point(272, 310);
            this.register_confirmpass.Name = "register_confirmpass";
            this.register_confirmpass.PasswordChar = '*';
            this.register_confirmpass.Size = new System.Drawing.Size(308, 26);
            this.register_confirmpass.TabIndex = 18;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(651, 483);
            this.Controls.Add(this.register_confirmpass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.register_showpass);
            this.Controls.Add(this.register_button);
            this.Controls.Add(this.register_password);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.close);
            this.Controls.Add(this.register_username);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label register_loginbutton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox register_showpass;
        private System.Windows.Forms.Button register_button;
        private System.Windows.Forms.TextBox register_password;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label close;
        private System.Windows.Forms.TextBox register_username;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox register_confirmpass;
    }
}