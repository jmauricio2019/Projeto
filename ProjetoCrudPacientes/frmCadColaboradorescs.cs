using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjetoCrudPacientes
{
    public partial class frmCadColaboradorescs : Form
    {
        string cns, Cpff;
        int CNS, Prot, cpff, cnss;
        public frmCadColaboradorescs()
        {
            InitializeComponent();
        }
        public void Cadastrar()
        {

            //ValidaCns(); //verifica Prontuario com mesmo nome no Banco
            VerificaProntuario();
            
            //verificar campo vazio
            //verificar campo vazio

            if (txtNome.Text == " " || txtDataNasc.Text == " " ||
                 txtTel1.Text == " " || txtCep.Text == " " || txtRua.Text == " " ||
                txtNum.Text == " " || txtBairro.Text == " " || txtCidade.Text == " " || txtUf.Text == " ")
            {
                MessageBox.Show("Necessario Preencher." + "\n" + "Nome, Data de Nasc., Tel1, Endereço Completo", "Mensagem");
            }

            else
            {
                if (Prot == 0)
                {
                    txtCpf.TextAlign = HorizontalAlignment.Left;
                    txtCpf.Focus();
                    try
                    {    //inserir dados no banco de dados
                        MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User Id=root;database=bd_crudcad; ");
                        objcon.Open();
                        MySqlCommand objCmd = new MySqlCommand("insert into tb_colaborador (prontuario, nome, datanasc, cpf, rg, cargo, crm," +
                            "coren, tel, tell, email, cep, logradouro, num, bairro, cidade, \n" +
                            " uf, senha) values( ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", objcon);
                        //parametros do comando sql
                        objCmd.Parameters.Add("@prontuario", MySqlDbType.VarChar, 10).Value = txtProntuario.Text;
                        objCmd.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = txtNome.Text;
                        objCmd.Parameters.Add("@datanasc", MySqlDbType.VarChar, 17).Value = txtDataNasc.Text;
                        objCmd.Parameters.Add("@cpf", MySqlDbType.VarChar, 18).Value = txtCpf.Text;
                        objCmd.Parameters.Add("@rg", MySqlDbType.VarChar, 18).Value = txtRg.Text;
                        objCmd.Parameters.Add("@cargo", MySqlDbType.VarChar, 20).Value = txtCargo.Text;
                        objCmd.Parameters.Add("@crm", MySqlDbType.VarChar, 18).Value = txtCrm.Text;
                        objCmd.Parameters.Add("@coren", MySqlDbType.VarChar, 18).Value = txtCoren.Text;
                        objCmd.Parameters.Add("@tel", MySqlDbType.VarChar, 20).Value = txtTel1.Text;
                        objCmd.Parameters.Add("@tell", MySqlDbType.VarChar, 20).Value = txtTel2.Text;
                        objCmd.Parameters.Add("@email", MySqlDbType.VarChar, 50).Value = txtEmail.Text;
                        objCmd.Parameters.Add("@cep", MySqlDbType.VarChar, 14).Value = txtCep.Text;
                        objCmd.Parameters.Add("@logadouro", MySqlDbType.VarChar, 100).Value = txtRua.Text;
                        objCmd.Parameters.Add("@num", MySqlDbType.VarChar, 8).Value = txtNum.Text;
                        objCmd.Parameters.Add("@bairro", MySqlDbType.VarChar, 50).Value = txtBairro.Text;
                        objCmd.Parameters.Add("@cidade", MySqlDbType.VarChar, 50).Value = txtCidade.Text;
                        objCmd.Parameters.Add("@uf", MySqlDbType.VarChar, 4).Value = txtUf.Text;
                        objCmd.Parameters.Add("@senha", MySqlDbType.VarChar, 200).Value = txtSenha.Text;

                        //para colocar os estados no combo box
                        //cmbestado.itens.add("sp");

                        //comando para executar query
                        objCmd.ExecuteNonQuery();

                        MessageBox.Show("Cadastrado com Sucesso!!!");

                        //fecha o banco de dados
                        objcon.Close();
                        //LimparBox();
                        btnSalvar.Enabled = false;
                        btnAtualizar.Enabled = false;
                        btnExcluir.Enabled = false;
                        checkBoxIncluirCadastro.Focus();
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show("Cadastro NÃO Realizado!!!" + erro);
                    }
                }
                else
                {
                    VerificaProntuario();
                    if (Prot != 0)
                    {
                        MessageBox.Show("Há um cadastro com este Nùmero de Prontuario!!!");
                        txtProntuario.Text = " ";

                        //GerarProntuario();
                    }
                    else
                    {
                        Cadastrar();
                    }
                }
            }
        }
        public void VerificaProntuario()
        {
            string id = txtProntuario.Text;
            Prot = 0;
            try
            {    //selecionar dados no banco de dados
                MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User Id=root; database=bd_crudcad; ");

                objcon.Open();
                //busca pelo prontuario
                MySqlCommand objCmd = new MySqlCommand("select  prontuario, nome, datanasc, cpf, rg, cns, mae, pai, tel1, " +
                    "tel2, email, cep, logadouro, num, bairro, cidade, uf, observacoes from tb_paciente where  prontuario= ?", objcon);

                objCmd.Parameters.Clear();

                objCmd.Parameters.Add("@prontuario", MySqlDbType.VarChar).Value = txtProntuario.Text;

                //comando para executar query
                objCmd.CommandType = CommandType.Text;

                //recebe conteudo do banco
                MySqlDataReader dr;
                dr = objCmd.ExecuteReader();

                dr.Read();

                String pront = dr.GetString(0);
                if (pront == id)
                {
                    Prot = 1;
                }

                objcon.Close();
            }
            catch (Exception)
            {

            }
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmOpcoes frm = new frmOpcoes();
            this.Visible = false;
            frm.ShowDialog();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Cadastrar();
        }

        private void cbbCargo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tabeladeClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmCadColaboradorescs_Load(object sender, EventArgs e)
        {

        }
    }
}
