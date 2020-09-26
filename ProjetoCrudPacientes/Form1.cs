using System;
using System.Windows.Forms;

namespace ProjetoCrudPacientes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Value = progressBar1.Value + 2;
            }
            catch
            {
                timer1.Enabled = false;

                this.Visible = false;

                frmLogin frm = new frmLogin();

                frm.ShowDialog();

            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
