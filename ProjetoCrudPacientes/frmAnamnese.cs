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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            frmConsulta frm = new frmConsulta();
            this.Visible = false;
            frm.ShowDialog();
        }
    }
}
