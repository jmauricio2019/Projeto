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
    public partial class frmAgendar : Form
    {
        string cns, Cpff;
        int CNS, Prot, cpff, cnss;
        public frmAgendar()
        {
            InitializeComponent();
            

        }
        public frmAgendar(string valor, string valor1, string valor2, string valor3)
        {
            InitializeComponent();
            txtNome.Text = valor;
            txtProntuario.Text = valor1;
            txtDataNasc.Text = valor2;
            txtMae.Text = valor3;

            txtNome.Enabled = false;
            txtProntuario.Enabled = false;
            txtDataNasc.Enabled = false; ;
            txtMae.Enabled = false;
            txtmedico.Enabled = false;
            txtEspecialidade.Enabled = false;
            txtCrm.Enabled = false;
        }

        //metodo verificar se ja existe cadastro
        public void VerificaConsulta()
        {
            string id = txtHoraAtend.Text;
            Prot = 0;
            try
            {    //selecionar dados no banco de dados
                MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User Id=root; database=bd_crudcad; ");

                objcon.Open();
                //busca pelo prontuario
                MySqlCommand objCmd = new MySqlCommand("select  prontuario, paciente, datanasc, mae, medico," +
                    " especialidade, datadeatend, hora, from tb_agenda where  hora= ?", objcon);

                objCmd.Parameters.Clear();

                objCmd.Parameters.Add("@hora", MySqlDbType.VarChar).Value = txtHoraAtend.Text;

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

        //metodo select pelo nome do cadastrado
        public void SelecionarDataGrewViewNome()
        {
            btnSalvar.Enabled = true;
            //btnAtualizar.Enabled = true;
            //btnExcluir.Enabled = true;
            //limpa o campo a cada busca 
            tabeladeClientes.Rows.Clear();
            tabeladeClientes.DataSource = null; //Remover a datasource
            tabeladeClientes.Columns.Clear(); //Remover as colunas
            tabeladeClientes.Rows.Clear();    //Remover as linhas
            tabeladeClientes.Refresh();
            string name = txtNome1.Text;
            try
            {    //selecionar dados no banco de dados
                // define a string de conexao com provedor caminho e nome do banco de dados
                string strProvider = "server=localhost;port=3306;User Id=root;database=bd_crudcad;";
                //cria a conexão com o banco de dados
                MySqlConnection con = new MySqlConnection(strProvider);
                //define a instrução SQL
                //abre a conexao
                con.Open();
                string strSql = "select * from tb_colaborador where nome like '%" + name + "%'";
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
                        //verifica o tipo de dados da coluna
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
                    //txtProntuario.Enabled = false;
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
            //TextBox();
        }

        //metodo cadastrar
        public void Cadastrar()
        {
            //ValidaCns(); //verifica Prontuario com mesmo nome no Banco
            VerificaConsulta();
            //verificar campo vazio
            //verificar campo vazio
            if (txtNome.Text == " " || txtDataNasc.Text == " " ||
                 txtProntuario.Text == " " || txtMae.Text == " " || txtmedico.Text == " " ||
                txtEspecialidade.Text == " " || txtDataAtend.Text == " " || txtDataAtend.Text == " " || txtHoraAtend.Text == " " || txtCrm.Text == " ")
            {
                MessageBox.Show("Necessario Preencher." + "\n" + "Todos os Campos", "Mensagem");
            }

            else
            {
                if (Prot == 0)
                {

                    try
                    {    //inserir dados no banco de dados
                        MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User Id=root;database=bd_crudcad; ");
                        objcon.Open();
                        MySqlCommand objCmd = new MySqlCommand("insert into tb_agenda (prontuario, paciente, datanasc, mae, medico," +
                            " especialidade, datadeatend, hora, crm) values( ?, ?, ?, ?, ?, ?, ?, ?, ?)", objcon);
                        //parametros do comando sql
                        objCmd.Parameters.Add("@prontuario", MySqlDbType.VarChar, 10).Value = txtProntuario.Text;
                        objCmd.Parameters.Add("@paciente", MySqlDbType.VarChar, 100).Value = txtNome.Text;
                        objCmd.Parameters.Add("@datanasc", MySqlDbType.VarChar, 17).Value = txtDataNasc.Text;
                        objCmd.Parameters.Add("@mae", MySqlDbType.VarChar, 17).Value = txtMae.Text;
                        objCmd.Parameters.Add("@medico", MySqlDbType.VarChar, 17).Value = txtmedico.Text;
                        objCmd.Parameters.Add("@especialidade", MySqlDbType.VarChar, 17).Value = txtEspecialidade.Text;
                        objCmd.Parameters.Add("@datadeatend", MySqlDbType.VarChar, 17).Value = txtDataAtend.Text;
                        objCmd.Parameters.Add("@hora", MySqlDbType.VarChar, 17).Value = txtHoraAtend.Text;
                        objCmd.Parameters.Add("@crm", MySqlDbType.VarChar, 15).Value = txtCrm.Text;

                        //para colocar os estados no combo box
                        //cmbestado.itens.add("sp");
                        //comando para executar query
                        objCmd.ExecuteNonQuery();
                        MessageBox.Show("Consulta agendada com Sucesso!!!");
                        //fecha o banco de dados
                        objcon.Close();
                        //LimparBox();
                        //btnSalvar.Enabled = false;
                        //btnAtualizar.Enabled = false;
                        //btnExcluir.Enabled = false;
                       // checkBoxIncluirCadastro.Focus();
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show("Consulta NÃO Agendada!!!" + erro);
                    }
                }
                else
                {
                    VerificaConsulta();
                    if (Prot != 0)
                    {
                        MessageBox.Show("Há uma consulta marcada para este paciente!!!");
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Cadastrar();
        }

        private void tabeladeClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
                try
                {
                    txtmedico.Text = tabeladeClientes.CurrentRow.Cells[2].Value.ToString();
                    txtCrm.Text = tabeladeClientes.CurrentRow.Cells[7].Value.ToString();
                    txtEspecialidade.Text = tabeladeClientes.CurrentRow.Cells[19].Value.ToString();
                }
                catch
                {

                }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmOpcoes frm = new frmOpcoes();
            this.Visible = false;
            frm.ShowDialog();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void frmAgendar_Load(object sender, EventArgs e)
        {

        }

        private void txtNome1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SelecionarDataGrewViewNome();
                btnBuscar1.Focus();
            }
        }
    }
}
