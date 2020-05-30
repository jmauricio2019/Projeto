using MySql.Data.MySqlClient;
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
    public partial class frmCadPacientes : Form
    {
        public frmCadPacientes()
        {
            InitializeComponent();
        }

        //inserir dados no banco de dados
        public void Cadastrar()
        {
            //verificar campo vazio
            if (txtNome.Text == "" || txtDataNasc.Text == "" || txtCpf.Text == "" || txtCns.Text == "" ||
                txtMae.Text == "" || txtTel1.Text == "" || txtCep.Text == "" || txtRua.Text == "" ||
                txtNum.Text == "" || txtBairro.Text == "" || txtCidade.Text == "" || txtUf.Text == "")
            {
                MessageBox.Show("Campo Obrigatório Vazio");
            }
            else
            {
                try
                {    //inserir dados no banco de dados
                    MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User Id=root;database=bd_crudcad; ");
                    objcon.Open();
                    MySqlCommand objCmd = new MySqlCommand("insert into tb_paciente (id, nome, datanasc, cpf, rg, cns, mae, \n" +
                        " pai, tel1, tel2, email, cep, logadouro, num, bairro, cidade, \n" +
                        " uf, observacoes) values( null, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", objcon);

                    //parametros do comando sql
                    objCmd.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = txtNome.Text;
                    objCmd.Parameters.Add("@datanasc", MySqlDbType.VarChar, 17).Value = txtDataNasc.Text;
                    objCmd.Parameters.Add("@cpf", MySqlDbType.VarChar, 18).Value = txtCpf.Text;
                    objCmd.Parameters.Add("@rg", MySqlDbType.VarChar, 18).Value = txtRg.Text;
                    objCmd.Parameters.Add("@cns", MySqlDbType.VarChar, 18).Value = txtCns.Text;
                    objCmd.Parameters.Add("@mae", MySqlDbType.VarChar, 400).Value = txtMae.Text;
                    objCmd.Parameters.Add("@pai", MySqlDbType.VarChar, 40).Value = txtPai.Text;
                    objCmd.Parameters.Add("@tel1", MySqlDbType.VarChar, 20).Value = txtTel1.Text;
                    objCmd.Parameters.Add("@tel2", MySqlDbType.VarChar, 20).Value = txtTel2.Text;
                    objCmd.Parameters.Add("@email", MySqlDbType.VarChar, 50).Value = txtEmail.Text;
                    objCmd.Parameters.Add("@cep", MySqlDbType.VarChar, 14).Value = txtCep.Text;
                    objCmd.Parameters.Add("@logadouro", MySqlDbType.VarChar, 100).Value = txtRua.Text;
                    objCmd.Parameters.Add("@num", MySqlDbType.VarChar, 8).Value = txtNum.Text;
                    objCmd.Parameters.Add("@bairro", MySqlDbType.VarChar, 50).Value = txtBairro.Text;
                    objCmd.Parameters.Add("@cidade", MySqlDbType.VarChar, 50).Value = txtCidade.Text;
                    objCmd.Parameters.Add("@uf", MySqlDbType.VarChar, 4).Value = txtUf.Text;
                    objCmd.Parameters.Add("@observacoes", MySqlDbType.VarChar, 200).Value = txtObservacoes.Text;

                    //para colocar os estados no combo box
                    //cmbestado.itens.add("sp");

                    //comando para executar query
                    objCmd.ExecuteNonQuery();

                    MessageBox.Show("Cadastrado com Sucesso!!!");

                    //fecha o banco de dados
                    objcon.Close();
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Cadastro NÃO Realizado!!!" + erro);
                }

            }

        }

        //selecionar dados do banco de dados
        public void Selecionar()
        {
            btnSalvar.Enabled = false;
            btnAtualizar.Enabled = true;

            try
            {    //selecionar dados no banco de dados
                MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User Id=root; database=bd_crudcad; ");

                objcon.Open();
                //busca pelo cpf
                MySqlCommand objCmd = new MySqlCommand("select nome, datanasc, cpf, rg, cns, mae, pai, tel1, " +
                    "tel2, email, cep, logadouro, num, bairro, cidade, uf, observacoes from tb_paciente where cpf = ?", objcon);

                objCmd.Parameters.Clear();

                objCmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = txtCpf1.Text;

                //comando para executar query
                objCmd.CommandType = CommandType.Text;

                //recebe conteudo do banco
                MySqlDataReader dr;
                dr = objCmd.ExecuteReader();

                dr.Read();

                txtNome.Text = dr.GetString(0);
                txtDataNasc.Text = dr.GetString(1);
                txtCpf.Text = dr.GetString(2);
                txtRg.Text = dr.GetString(3);
                txtCns.Text = dr.GetString(4);
                txtMae.Text = dr.GetString(5);
                txtPai.Text = dr.GetString(6);
                txtTel1.Text = dr.GetString(7);
                txtTel2.Text = dr.GetString(8);
                txtEmail.Text = dr.GetString(9);
                txtCep.Text = dr.GetString(10);
                txtRua.Text = dr.GetString(11);
                txtNum.Text = dr.GetString(12);
                txtBairro.Text = dr.GetString(13);
                txtCidade.Text = dr.GetString(14);
                txtUf.Text = dr.GetString(15);
                txtObservacoes.Text = dr.GetString(16);


                //mensagem
                MessageBox.Show("busca realizada com sucesso");

                //fecha o banco de dados
                objcon.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("busca nao realizada" + erro);
            }
        }

        //atualiar dados no banco de dados
        public void Atualizar()
        {
            if (txtNome.Text == "" || txtDataNasc.Text == "" || txtCpf.Text == "" || txtCns.Text == "" ||
               txtMae.Text == "" || txtTel1.Text == "" || txtCep.Text == "" || txtRua.Text == "" ||
               txtNum.Text == "" || txtBairro.Text == "" || txtCidade.Text == "" || txtUf.Text == "")
            {
                MessageBox.Show("Campo Obrigatório Vazio");
            }
            else
            {
                //atualizar dados no banco de dados

                try
                {    //atualizar dados no banco de dados
                    MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User Id=root;database=bd_crudcad; ");
                    objcon.Open();
                    MySqlCommand objCmd = new MySqlCommand("update tb_paciente set nome = ? datanasc = ?, cpf = ?," +
                        " rg = ?, cns = ?, mae = ?, pai = ?, tel1 = ?, tel2 = ?, email = ?, cep = ?, logadouro = ?," +
                        " num = ?, bairro = ?, cidade = ?, uf = ?, observacoes = ? where cpf = ?", objcon);
                    objCmd.Parameters.Clear();

                    //parametros do comando sql
                    objCmd.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = txtNome.Text;
                    objCmd.Parameters.Add("@datanasc", MySqlDbType.VarChar, 17).Value = txtDataNasc.Text;
                    objCmd.Parameters.Add("@cpf", MySqlDbType.VarChar, 18).Value = txtCpf.Text;
                    objCmd.Parameters.Add("@rg", MySqlDbType.VarChar, 18).Value = txtRg.Text;
                    objCmd.Parameters.Add("@cns", MySqlDbType.VarChar, 18).Value = txtCns.Text;
                    objCmd.Parameters.Add("@mae", MySqlDbType.VarChar, 400).Value = txtMae.Text;
                    objCmd.Parameters.Add("@pai", MySqlDbType.VarChar, 40).Value = txtPai.Text;
                    objCmd.Parameters.Add("@tel1", MySqlDbType.VarChar, 20).Value = txtTel1.Text;
                    objCmd.Parameters.Add("@tel2", MySqlDbType.VarChar, 20).Value = txtTel2.Text;
                    objCmd.Parameters.Add("@email", MySqlDbType.VarChar, 50).Value = txtEmail.Text;
                    objCmd.Parameters.Add("@cep", MySqlDbType.VarChar, 14).Value = txtCep.Text;
                    objCmd.Parameters.Add("@logadouro", MySqlDbType.VarChar, 100).Value = txtRua.Text;
                    objCmd.Parameters.Add("@num", MySqlDbType.VarChar, 8).Value = txtNum.Text;
                    objCmd.Parameters.Add("@bairro", MySqlDbType.VarChar, 50).Value = txtBairro.Text;
                    objCmd.Parameters.Add("@cidade", MySqlDbType.VarChar, 50).Value = txtCidade.Text;
                    objCmd.Parameters.Add("@uf", MySqlDbType.VarChar, 4).Value = txtUf.Text;
                    objCmd.Parameters.Add("@observacoes", MySqlDbType.VarChar, 200).Value = txtObservacoes.Text;

                    //comando para executar query
                    objCmd.CommandType = CommandType.Text;
                    objCmd.ExecuteNonQuery();
                    //fecha o banco de dados
                    objcon.Close();

                    //mensagem
                    MessageBox.Show("Atualizado com Sucesso !!!");

                }
                catch (Exception erro)
                {
                    MessageBox.Show("Não Atualizado !!!" + erro);
                }
            }
        }
        //excluir dados no banco de dados
        public void Excluir()
        {
            try
            {    //excluir dados no banco de dados
                MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User Id=root;database=bd_crudcad; ");
                objcon.Open();
                MySqlCommand objCmd = new MySqlCommand("delete from tb_paciente where cpf = ?", objcon);
                objCmd.Parameters.Clear();
                objCmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = txtCpf.Text;


                //comando para executar query
                objCmd.CommandType = CommandType.Text;
                objCmd.ExecuteNonQuery();
                //mensagem
                MessageBox.Show("Exclusão Realizada com Sucesso !!!");

                //fecha o banco de dados
                objcon.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Dados não Excluidos !!!" + erro);

            }
        }

        //limpar todos os txt box
        public void LimparBox()
        {
            txtNome.Text = (" ");
            txtDataNasc.Text = (" ");
            txtCpf.Text = (" ");
            txtRg.Text = (" ");
            txtCns.Text = (" ");
            txtMae.Text = (" ");
            txtPai.Text = (" ");
            txtTel1.Text = (" ");
            txtTel2.Text = (" ");
            txtEmail.Text = (" ");
            txtCep.Text = (" ");
            txtRua.Text = (" ");
            txtNum.Text = (" ");
            txtBairro.Text = (" ");
            txtCidade.Text = (" ");
            txtUf.Text = (" ");
            txtObservacoes.Text = (" ");
            txtProntuario.Text = (" ");
        }


        private void frmCadPacientes_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmOpcoes frm = new frmOpcoes();
            this.Visible = false;
            frm.ShowDialog();
        }

        private void btnBuscar1_Click(object sender, EventArgs e)
        {
            Selecionar();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Cadastrar();
            LimparBox();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Atualizar();
            LimparBox();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
            LimparBox();
        }

        private void checkBoxIncluirCadastro_CheckedChanged(object sender, EventArgs e)
        {
            btnSalvar.Enabled = true;
            btnAtualizar.Enabled = false;
            btnExcluir.Enabled = false;

            LimparBox();
        }
    }
}
