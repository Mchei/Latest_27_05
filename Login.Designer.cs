
namespace Latest_27_05
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.login_panel = new System.Windows.Forms.Panel();
            this.login_button = new System.Windows.Forms.Button();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.password_icon = new System.Windows.Forms.PictureBox();
            this.username_icon = new System.Windows.Forms.PictureBox();
            this.Title = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Label();
            this.login_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.password_icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.username_icon)).BeginInit();
            this.SuspendLayout();
            // 
            // login_panel
            // 
            this.login_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.login_panel.Controls.Add(this.exit);
            this.login_panel.Controls.Add(this.login_button);
            this.login_panel.Controls.Add(this.txtpassword);
            this.login_panel.Controls.Add(this.txtUserName);
            this.login_panel.Controls.Add(this.password_icon);
            this.login_panel.Controls.Add(this.username_icon);
            this.login_panel.Controls.Add(this.Title);
            this.login_panel.Location = new System.Drawing.Point(12, 12);
            this.login_panel.Name = "login_panel";
            this.login_panel.Size = new System.Drawing.Size(257, 362);
            this.login_panel.TabIndex = 0;
            // 
            // login_button
            // 
            this.login_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.login_button.FlatAppearance.BorderSize = 0;
            this.login_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.login_button.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_button.ForeColor = System.Drawing.Color.White;
            this.login_button.Location = new System.Drawing.Point(27, 235);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(200, 31);
            this.login_button.TabIndex = 14;
            this.login_button.Text = "LOGIN";
            this.login_button.UseVisualStyleBackColor = false;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // txtpassword
            // 
            this.txtpassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.txtpassword.Location = new System.Drawing.Point(58, 163);
            this.txtpassword.Multiline = true;
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(169, 24);
            this.txtpassword.TabIndex = 13;
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.txtUserName.Location = new System.Drawing.Point(58, 120);
            this.txtUserName.Multiline = true;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(169, 24);
            this.txtUserName.TabIndex = 12;
            // 
            // password_icon
            // 
            this.password_icon.Image = ((System.Drawing.Image)(resources.GetObject("password_icon.Image")));
            this.password_icon.Location = new System.Drawing.Point(27, 162);
            this.password_icon.Name = "password_icon";
            this.password_icon.Size = new System.Drawing.Size(25, 25);
            this.password_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.password_icon.TabIndex = 11;
            this.password_icon.TabStop = false;
            // 
            // username_icon
            // 
            this.username_icon.Image = ((System.Drawing.Image)(resources.GetObject("username_icon.Image")));
            this.username_icon.Location = new System.Drawing.Point(27, 119);
            this.username_icon.Name = "username_icon";
            this.username_icon.Size = new System.Drawing.Size(25, 25);
            this.username_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.username_icon.TabIndex = 8;
            this.username_icon.TabStop = false;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Bauhaus 93", 24F, System.Drawing.FontStyle.Bold);
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.Title.Location = new System.Drawing.Point(83, 57);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(93, 36);
            this.Title.TabIndex = 0;
            this.Title.Text = "Login";
            this.Title.Click += new System.EventHandler(this.Title_Click);
            // 
            // exit
            // 
            this.exit.AutoSize = true;
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.exit.Location = new System.Drawing.Point(109, 285);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(33, 16);
            this.exit.TabIndex = 15;
            this.exit.Text = "Exit";
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(281, 386);
            this.Controls.Add(this.login_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL Checker Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.login_panel.ResumeLayout(false);
            this.login_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.password_icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.username_icon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel login_panel;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.PictureBox password_icon;
        private System.Windows.Forms.PictureBox username_icon;
        private System.Windows.Forms.Label exit;
    }
}

