using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjetoCrudPacientes
{
    public partial class frmLogin : Form
    {
        string prontuario, senha;
        public frmLogin()
        {
            InitializeComponent();
        }

        public void campoVazio()
        {

            if (txtLogin.Text == "" || txtSenha.Text == "")
            {
                MessageBox.Show(" Campo Obrigatório Vazio ");
            }
            else
            {
                usuario();
            }
        }
        public void usuario()
        {
            prontuario = txtLogin.Text;
            senha = txtSenha.Text;
            try
            {    //selecionar dados no banco de dados
                MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User Id=root; database=bd_crudcad; ");

                objcon.Open();
                //busca pelo prontuario
                MySqlCommand objCmd = new MySqlCommand("select  prontuario,nome, senha from tb_colaborador where  prontuario= ?", objcon);

                objCmd.Parameters.Clear();

                objCmd.Parameters.Add("@prontuario", MySqlDbType.VarChar).Value = txtLogin.Text;
                
                //comando para executar query
                objCmd.CommandType = CommandType.Text;

                //recebe conteudo do banco
                MySqlDataReader dr;
                dr = objCmd.ExecuteReader();

                dr.Read();

                String id = dr.GetString(0);               
                string nome = dr.GetString(1);
                String sen = dr.GetString(2);

                if ( sen ==senha && id == prontuario )
                {
                    frmOpcoes frm = new frmOpcoes();
                    frm.lblUsuario.Text = nome;
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Login ou Senha incorretos");
                }
                objcon.Close();
            }
           
            catch (Exception)
            {
                MessageBox.Show("Login ou Senha incorretos");
            }
            txtLogin.Text = "";
            txtSenha.Text = "";
        }
        public void ValidaLogin()
        {
            campoVazio();
                    
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
