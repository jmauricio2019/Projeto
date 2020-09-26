using System;
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
            MessageBox.Show("Raphael (12)9 8169-1914" + "\n" + "\n" + "Jose Mauricio(12)9 9720-9637 ", "Ajuda?");
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

        private void frmOpcoes_Load(object sender, EventArgs e)
        {

        }
    }
}
