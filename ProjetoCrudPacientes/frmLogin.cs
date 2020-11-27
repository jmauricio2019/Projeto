using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjetoCrudPacientes
{
    public partial class frmLogin : Form
    {
        string nome, senha, cargo;
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

        public void usuario()
        {
            nome = txtLogin.Text;
            senha = txtSenha.Text;

            /*try
            {    //selecionar dados no banco de dados
                // define a string de conexao com provedor caminho e nome do banco de dados
                string strProvider = "server=localhost;port=3306;User Id=root;database=bd_crudcad;";
                //cria a conexão com o banco de dados
                MySqlConnection con = new MySqlConnection(strProvider);
                //define a instrução SQL
                //abre a conexao
                con.Open();
                //if (txtCpf1.Enabled == true )
                //{
                MySqlCommand cmd = new MySqlCommand("select * from tb_colaborador where nome= @nome and senha = @senha" , con);

                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@senha", senha);
                var resultado = cmd.ExecuteScalar();
                if(resultado != null)
                {
                    frmOpcoes frm = new frmOpcoes();
                    frm.lblUsuario.Text = txtLogin.Text;
                    frm.ShowDialog();
                }
            
            }
            catch (Exception erro)
            {
                MessageBox.Show("Algo erro no banco " + erro);
            }*/
            try
            {    //selecionar dados no banco de dados
                MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User Id=root; database=bd_crudcad; ");

                objcon.Open();
                //busca pelo prontuario
                MySqlCommand objCmd = new MySqlCommand("select  nome, senha from tb_colaborador where  nome= ?", objcon);

                objCmd.Parameters.Clear();

                objCmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = txtLogin.Text;
                


                //comando para executar query
                objCmd.CommandType = CommandType.Text;

                //recebe conteudo do banco
                MySqlDataReader dr;
                dr = objCmd.ExecuteReader();

                dr.Read();

                String id = dr.GetString(0);
                String sen = dr.GetString(1);
                MessageBox.Show(id,sen);

                if ( sen ==senha && id == nome)
                {
                    frmOpcoes frm = new frmOpcoes();
                    frm.lblUsuario.Text = txtLogin.Text;
                    frm.ShowDialog();

                }
               


                objcon.Close();
            }
           
            catch (Exception)
            {
             
                
            }
        }
        public void ValidaLogin()
        {
            

            campoVazio();
            usuario();
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
