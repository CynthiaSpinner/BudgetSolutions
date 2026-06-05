namespace BudgetSolutions
{
    partial class Form1
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
            this.login_createAcc = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.close = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.login_username = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.login_password = new System.Windows.Forms.TextBox();
            this.login_button = new System.Windows.Forms.Button();
            this.login_showpass = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(178)))), ((int)(((byte)(184)))));
            this.panel1.Controls.Add(this.login_createAcc);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(214, 483);
            this.panel1.TabIndex = 0;
            // 
            // login_createAcc
            // 
            this.login_createAcc.AutoSize = true;
            this.login_createAcc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.login_createAcc.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_createAcc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.login_createAcc.Location = new System.Drawing.Point(36, 387);
            this.login_createAcc.Name = "login_createAcc";
            this.login_createAcc.Size = new System.Drawing.Size(141, 20);
            this.login_createAcc.TabIndex = 8;
            this.login_createAcc.Text = "Create Account";
            this.login_createAcc.Click += new System.EventHandler(this.login_createAcc_Click);
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
            // close
            // 
            this.close.AutoSize = true;
            this.close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(223)))), ((int)(((byte)(231)))));
            this.close.Location = new System.Drawing.Point(628, 9);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(16, 14);
            this.close.TabIndex = 0;
            this.close.Text = "X";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(223)))), ((int)(((byte)(231)))));
            this.label3.Location = new System.Drawing.Point(264, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 30);
            this.label3.TabIndex = 1;
            this.label3.Text = "Sign In";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(223)))), ((int)(((byte)(231)))));
            this.label4.Location = new System.Drawing.Point(265, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Username:";
            // 
            // login_username
            // 
            this.login_username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(239)))), ((int)(((byte)(243)))));
            this.login_username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.login_username.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.login_username.Location = new System.Drawing.Point(269, 164);
            this.login_username.Name = "login_username";
            this.login_username.Size = new System.Drawing.Size(308, 26);
            this.login_username.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(223)))), ((int)(((byte)(231)))));
            this.label5.Location = new System.Drawing.Point(265, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Password:";
            // 
            // login_password
            // 
            this.login_password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(239)))), ((int)(((byte)(243)))));
            this.login_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.login_password.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.login_password.Location = new System.Drawing.Point(269, 244);
            this.login_password.Name = "login_password";
            this.login_password.PasswordChar = '*';
            this.login_password.Size = new System.Drawing.Size(308, 26);
            this.login_password.TabIndex = 5;
            // 
            // login_button
            // 
            this.login_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(223)))), ((int)(((byte)(231)))));
            this.login_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.login_button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(178)))), ((int)(((byte)(184)))));
            this.login_button.FlatAppearance.BorderSize = 2;
            this.login_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.login_button.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.login_button.Location = new System.Drawing.Point(269, 328);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(92, 31);
            this.login_button.TabIndex = 7;
            this.login_button.Text = "LOGIN";
            this.login_button.UseVisualStyleBackColor = false;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // login_showpass
            // 
            this.login_showpass.AutoSize = true;
            this.login_showpass.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(239)))), ((int)(((byte)(243)))));
            this.login_showpass.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_showpass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(223)))), ((int)(((byte)(231)))));
            this.login_showpass.Location = new System.Drawing.Point(474, 276);
            this.login_showpass.Name = "login_showpass";
            this.login_showpass.Size = new System.Drawing.Size(109, 18);
            this.login_showpass.TabIndex = 6;
            this.login_showpass.Text = "Show Password";
            this.login_showpass.UseVisualStyleBackColor = true;
            this.login_showpass.CheckedChanged += new System.EventHandler(this.login_showpass_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(124)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(651, 483);
            this.Controls.Add(this.login_showpass);
            this.Controls.Add(this.login_button);
            this.Controls.Add(this.login_password);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.close);
            this.Controls.Add(this.login_username);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label close;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox login_username;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox login_password;
        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.CheckBox login_showpass;
        private System.Windows.Forms.Label login_createAcc;
    }
}

