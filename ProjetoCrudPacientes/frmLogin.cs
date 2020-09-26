using System;
using System.Windows.Forms;

namespace ProjetoCrudPacientes
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        public void campoVazio()
        {

            if (txtLogin.Text == "" && txtSenha.Text == "")
            {

            }
        }

        public void ValidaLogin()
        {
            campoVazio();
            if ((txtLogin.Text == "admin") && (txtSenha.Text == "admin"))
            {
                frmOpcoes frm = new frmOpcoes();
                frm.lblUsuario.Text = txtLogin.Text;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Login e Senha não correspondem!!!");
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ValidaLogin();
        }

        private void btnLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ValidaLogin();
            }
        }

        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtSenha.TextAlign = HorizontalAlignment.Left;
                txtSenha.Focus();
            }
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //btnLogin.Focus();
                ValidaLogin();
            }
        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
