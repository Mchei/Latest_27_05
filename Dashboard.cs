using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace Latest_27_05
{
    public partial class Dashboard : Form
    {
        private bool mouseDown;
        private Point lastLocation;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
         (
               int nLeftRect,
               int nTopRect,
               int nRightRect,
               int nBottomRect,
               int nWidthEllipse,
               int nHeightEllipse

         );

        public Dashboard()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = btnDashbord.Height;
            pnlNav.Top = btnDashbord.Top;
            pnlNav.Left = btnDashbord.Left;

            lbltitle.Text = "Dashbord";
            frmDashboard frmDashboard_vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmDashboard_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmDashboard_vrb);
            frmDashboard_vrb.Show();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void btnDashbord_Click(object sender, EventArgs e)
        {

        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnContactUs_Click(object sender, EventArgs e)
        {

        }

        private void btnDashbord_Click_1(object sender, EventArgs e)
        {
            //Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            // pnlNav.Height = btnDashbord.Height;
            //pnlNav.Top = btnDashbord.Top;
            //pnlNav.Left = btnDashbord.Left;
            //btnDashbord.BackColor = Color.FromArgb(46, 51, 73);

            lbltitle.Text = "Dashbord";
            this.pnlFormLoader.Controls.Clear();
            frmDashboard frmDashboard_vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmDashboard_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmDashboard_vrb);
            frmDashboard_vrb.Show();
        }

        private void btnQueries_Click(object sender, EventArgs e)
        {
            //Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            //pnlNav.Height = btnQueries.Height;
            //pnlNav.Top = btnQueries.Top;
            //pnlNav.Left = btnQueries.Left;
            //btnDashbord.BackColor = Color.FromArgb(46, 51, 73);

            lbltitle.Text = "Dashbord";
            this.pnlFormLoader.Controls.Clear();
            frmQueries frmQueries_vrb = new frmQueries() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmQueries_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmQueries_vrb);
            frmQueries_vrb.Show();
        }

        private void btnsettings_Click(object sender, EventArgs e)
        {
            //Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            //pnlNav.Height = btnQueries.Height;
            //pnlNav.Top = btnQueries.Top;
            //pnlNav.Left = btnQueries.Left;
            //btnDashbord.BackColor = Color.FromArgb(46, 51, 73);

            lbltitle.Text = "Dashbord";
            this.pnlFormLoader.Controls.Clear();
            frmSetting frmSetting_vrb = new frmSetting() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmSetting_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmSetting_vrb);
            frmSetting_vrb.Show();
        }

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void pnlHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void pnlHeader_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
