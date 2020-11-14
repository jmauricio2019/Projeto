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
                            " uf, senha) values( ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", objcon);
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
                        objCmd.Parameters.Add("@logradouro", MySqlDbType.VarChar, 100).Value = txtRua.Text;
                        objCmd.Parameters.Add("@num", MySqlDbType.VarChar, 8).Value = txtNum.Text;
                        objCmd.Parameters.Add("@bairro", MySqlDbType.VarChar, 50).Value = txtBairro.Text;
                        objCmd.Parameters.Add("@cidade", MySqlDbType.VarChar, 50).Value = txtCidade.Text;
                        objCmd.Parameters.Add("@uf", MySqlDbType.VarChar, 4).Value = txtUf.Text;
                        objCmd.Parameters.Add("@senha", MySqlDbType.VarChar, 20).Value = txtSenha.Text;

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
        public void SelecionarDataGrewViewTodos()
        {
            btnSalvar.Enabled = false;
            btnAtualizar.Enabled = true;
            btnExcluir.Enabled = true;
            //limpa o campo a cada busca 
            tabeladeClientes.Rows.Clear();
            tabeladeClientes.DataSource = null; //Remover a datasource
            tabeladeClientes.Columns.Clear(); //Remover as colunas
            tabeladeClientes.Rows.Clear();    //Remover as linhas
            tabeladeClientes.Refresh();
            try
            {    //selecionar dados no banco de dados
                // define a string de conexao com provedor caminho e nome do banco de dados
                string strProvider = "server=localhost;port=3306;User Id=root;database=bd_crudcad;";
                //cria a conexão com o banco de dados
                MySqlConnection con = new MySqlConnection(strProvider);
                //define a instrução SQL
                //abre a conexao
                con.Open();
                string strSql = "select * from tb_colaborador ";
                //cria o objeto command para executar a instruçao sql
                MySqlCommand cmd = new MySqlCommand(strSql, con);
                //define o tipo do comando
                cmd.CommandType = CommandType.Text;
                //cria um dataadapter
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr = cmd.ExecuteReader();
                //Obtem o número de colunas
                int nColunas = dr.FieldCount;
                //percorre as colunas obtendo o seu nome e incluindo no DataGridView
                for (int i = 0; i < nColunas; i++)
                {
                    tabeladeClientes.Columns.Add(dr.GetName(i).ToString(), dr.GetName(i).ToString());
                }
                //define um array de strings com nCOlunas

                string[] linhaDados = new string[nColunas];
                //percorre o DataRead
                int cont = 0;//para informar mensagem para o usuario se não encontrar 
                while (dr.Read())
                {
                    //percorre cada uma das colunas
                    for (int a = 0; a < nColunas; a++)
                    {
                        //verifica o tipo de dados da colun
                        if (dr.GetFieldType(a).ToString() == "System.Int32")
                        {
                            linhaDados[a] = dr.GetInt32(a).ToString();
                        }
                        if (dr.GetFieldType(a).ToString() == "System.String")
                        {
                            linhaDados[a] = dr.GetString(a).ToString();
                        }
                        if (dr.GetFieldType(a).ToString() == "System.DateTime")
                        {
                            linhaDados[a] = dr.GetDateTime(a).ToString();
                        }
                        cont++;
                    }
                    tabeladeClientes.Rows.Add(linhaDados);
                    txtProntuario.Enabled = false;
                }
                con.Close();
                if (cont == 0)
                {
                    MessageBox.Show("Cadastro inexistente");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("busca nao realizada" + erro);
            }
           // LimparBox2();
        }
        private void tabeladeClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //desabilitar salvar
            btnSalvar.Enabled = false;
            btnAtualizar.Enabled = true;
            btnExcluir.Enabled = true;

            try
            {
                txtProntuario.Text = tabeladeClientes.CurrentRow.Cells[0].Value.ToString();
                txtNome.Text = tabeladeClientes.CurrentRow.Cells[1].Value.ToString();
                txtDataNasc.Text = tabeladeClientes.CurrentRow.Cells[2].Value.ToString();
                txtCpf.Text = tabeladeClientes.CurrentRow.Cells[3].Value.ToString();
                txtRg.Text = tabeladeClientes.CurrentRow.Cells[4].Value.ToString();
                txtCargo.Text = tabeladeClientes.CurrentRow.Cells[5].Value.ToString();
                txtCrm.Text = tabeladeClientes.CurrentRow.Cells[6].Value.ToString();
                txtCoren.Text = tabeladeClientes.CurrentRow.Cells[7].Value.ToString();
                txtTel1.Text = tabeladeClientes.CurrentRow.Cells[8].Value.ToString();
                txtTel2.Text = tabeladeClientes.CurrentRow.Cells[9].Value.ToString();
                txtEmail.Text = tabeladeClientes.CurrentRow.Cells[10].Value.ToString();
                txtCep.Text = tabeladeClientes.CurrentRow.Cells[11].Value.ToString();
                txtRua.Text = tabeladeClientes.CurrentRow.Cells[12].Value.ToString();
                txtNum.Text = tabeladeClientes.CurrentRow.Cells[13].Value.ToString();
                txtBairro.Text = tabeladeClientes.CurrentRow.Cells[14].Value.ToString();
                txtCidade.Text = tabeladeClientes.CurrentRow.Cells[15].Value.ToString();
                txtUf.Text = tabeladeClientes.CurrentRow.Cells[16].Value.ToString();
                txtSenha.Text = tabeladeClientes.CurrentRow.Cells[17].Value.ToString();
            }
            catch
            {

            }

        }
        public void Atualizar()
        {
            if (txtNome.Text == " " || txtDataNasc.Text == " " ||
               txtTel1.Text == " " || txtCep.Text == " " || txtRua.Text == " " ||
                txtNum.Text == " " || txtBairro.Text == " " || txtCidade.Text == " " || txtUf.Text == " ")
            {
                MessageBox.Show("Os Campos: Prontuario, Nome, Data de Nascimento, Nome da Mãe\n Telefone 1" +
                    "e o Endereço Completo Devem ser Preenchidos. ", "Mensagem");
            }
            else
            {
                //atualizar dados no banco de dados

                try
                {    //atualizar dados no banco de dados
                    MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User Id=root;database=bd_crudcad; ");
                    objcon.Open();
                    MySqlCommand objCmd = new MySqlCommand("update tb_colaborador set nome = ?," +
                        "" +
                        " datanasc = ?," +
                        " cpf = ?, rg = ?, cargo = ?, crm = ?, coren = ?, tel = ?, tell = ?, email = ?, cep = ?, logradouro = ?," +
                        " num = ?, bairro = ?, cidade = ?, uf = ?, senha = ? where prontuario = ?", objcon);
                    objCmd.Parameters.Clear();

                    //parametros do comando sql
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
                    objCmd.Parameters.Add("@senha", MySqlDbType.VarChar, 20).Value = txtSenha.Text;
                    objCmd.Parameters.Add("@prontuario", MySqlDbType.VarChar, 18).Value = txtProntuario.Text;
                    //comando para executar query
                    objCmd.CommandType = CommandType.Text;
                    objCmd.ExecuteNonQuery();
                    //fecha o banco de dados
                    objcon.Close();

                    //mensagem
                    MessageBox.Show("Atualizado com Sucesso !!!");
                    //LimparBox();

                }
                catch (Exception erro)
                {
                    MessageBox.Show("Não Atualizado !!!" + erro);
                }

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

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void btnBuscar1_Click(object sender, EventArgs e)
        {
            SelecionarDataGrewViewTodos();
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
