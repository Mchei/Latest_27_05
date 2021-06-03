using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latest_27_05
{
    public partial class frmSetting : Form
    {
        
        public frmSetting()
        {
            InitializeComponent();
        }
        
        private void frmSetting_Load(object sender, EventArgs e)
        {
            sampleDatabaseTextbox.Text = Properties.Settings.Default.Sample_location;
            excel_location.Text = Properties.Settings.Default.Excel_location;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Sample_location = sampleDatabaseTextbox.Text;
            Properties.Settings.Default.Excel_location = excel_location.Text;
            Properties.Settings.Default.Save();
            pathret();
        }

        public string pathret()
        {
            return sampleDatabaseTextbox.Text;
        }
        
    }
}
