
namespace Latest_27_05
{
    partial class frmSetting
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
            this.sampleDatabaseTextbox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.excal_location = new System.Windows.Forms.Label();
            this.excel_location = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // sampleDatabaseTextbox
            // 
            this.sampleDatabaseTextbox.Location = new System.Drawing.Point(318, 197);
            this.sampleDatabaseTextbox.Name = "sampleDatabaseTextbox";
            this.sampleDatabaseTextbox.Size = new System.Drawing.Size(285, 22);
            this.sampleDatabaseTextbox.TabIndex = 0;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(318, 322);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 31);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(102, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sample Database Location: ";
            // 
            // excal_location
            // 
            this.excal_location.AutoSize = true;
            this.excal_location.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.excal_location.ForeColor = System.Drawing.SystemColors.Control;
            this.excal_location.Location = new System.Drawing.Point(102, 245);
            this.excal_location.Name = "excal_location";
            this.excal_location.Size = new System.Drawing.Size(150, 25);
            this.excal_location.TabIndex = 3;
            this.excal_location.Text = "Excel Location: ";
            // 
            // excel_location
            // 
            this.excel_location.Location = new System.Drawing.Point(361, 245);
            this.excel_location.Name = "excel_location";
            this.excel_location.Size = new System.Drawing.Size(242, 22);
            this.excel_location.TabIndex = 4;
            // 
            // frmSetting
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.ClientSize = new System.Drawing.Size(835, 575);
            this.Controls.Add(this.excel_location);
            this.Controls.Add(this.excal_location);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.sampleDatabaseTextbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSetting";
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox sampleDatabaseTextbox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label excal_location;
        private System.Windows.Forms.TextBox excel_location;
    }
}