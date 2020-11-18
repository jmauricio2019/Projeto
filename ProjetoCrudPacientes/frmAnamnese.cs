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
    public partial class frmAnamnese : Form
    {
        public frmAnamnese()
        {
            InitializeComponent();
        }
        public frmAnamnese(string valor, string valor1, string valor2, string valor3)
        {
            InitializeComponent();
            txtNome.Text = valor;
            txtProntuario.Text = valor1;
            txtDataNasc.Text = valor2;
            

            txtNome.Enabled = false;
            txtProntuario.Enabled = false;
            txtDataNasc.Enabled = false; ;
            
            txtmedico.Enabled = false;
            txtEspecialidade.Enabled = false;
            
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            frmConsulta frm = new frmConsulta();
            this.Visible = false;
            frm.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
