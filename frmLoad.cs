using System;
using System.Windows.Forms;
namespace Latest_27_05

{
    public partial class frmLoad : Form
    {
        public frmLoad()
        {
            InitializeComponent();
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            String strText; 
            openFileDialog1.InitialDirectory = "E:/codes";
            openFileDialog1.Title = "Select Text files";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Filter = "Text Files (*.TXT)|*.TXT|" + "All files (*.*)|*.*";

            openFileDialog1.ShowDialog();

            strText = openFileDialog1.FileName;
            MessageBox.Show(strText);

        }

        private void selectTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
            }
