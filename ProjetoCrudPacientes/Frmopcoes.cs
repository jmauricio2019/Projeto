using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoCrudPacientes
{
    public partial class frmOpcoes : Form
    {
        public frmOpcoes()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCadastrodeClientes_Click(object sender, EventArgs e)
        {
            frmCadPacientes frm = new frmCadPacientes();
            frm.ShowDialog();
        }

        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tel: " + "\n" + "\n" + "josehvvn@gmail.com" + "\n" + "\n" + "raphaelacacio84@gmail.com", "Ajuda?" );
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //lblHora.Text = DateTime.Now.ToLongTimeString();
            lblHora.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {

        }
    }
}
