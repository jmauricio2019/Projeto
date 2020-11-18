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
    public partial class frmVerificarAgenda : Form
    {
        public frmVerificarAgenda()
        {
            InitializeComponent();
        }
        public void SelecionarDataGrewViewTodos()
        {
            //btnSalvar.Enabled = false;
            //btnAtualizar.Enabled = true;
            //btnExcluir.Enabled = true;
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
                string strSql = "select * from tb_agenda ";
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
            LimparBox2();
        }
        //metodo select pelo nome do cadastrado
        public void SelecionarDataGrewViewNome()
        {
           // btnSalvar.Enabled = false;
           // btnAtualizar.Enabled = true;
           // btnExcluir.Enabled = true;
            //limpa o campo a cada busca 
            tabeladeClientes.Rows.Clear();
            tabeladeClientes.DataSource = null; //Remover a datasource
            tabeladeClientes.Columns.Clear(); //Remover as colunas
            tabeladeClientes.Rows.Clear();    //Remover as linhas
            tabeladeClientes.Refresh();
            string name = txtmedico1.Text;
            try
            {    //selecionar dados no banco de dados
                // define a string de conexao com provedor caminho e nome do banco de dados
                string strProvider = "server=localhost;port=3306;User Id=root;database=bd_crudcad;";
                //cria a conexão com o banco de dados
                MySqlConnection con = new MySqlConnection(strProvider);
                //define a instrução SQL
                //abre a conexao
                con.Open();
                string strSql = "select * from tb_agenda where medico like '%" + name + "%'";
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
            LimparBox2();
            //TextBox();
        }
        //metodo select pelo cpf do cadastrado
        public void SelecionarDataGrewViewDataAtend()
        {
            //btnSalvar.Enabled = false;
           // btnAtualizar.Enabled = true;
           // btnExcluir.Enabled = true;
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
                //if (txtCpf1.Enabled == true )
                //{
                MySqlCommand cmd = new MySqlCommand("select* from tb_agenda where datadeatend = ?", con);
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@datadeatend", MySqlDbType.VarChar).Value = txtDataAtend1.Text;
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
                    // txtCpf.Enabled = false;
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
            LimparBox2();
        }

        //metodo select pela matricula
        public void SelecionarDataGrewViewEspecialidade()
        {
            //btnSalvar.Enabled = false;
            //btnAtualizar.Enabled = true;
            //btnExcluir.Enabled = true;
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
                //if (txtCpf1.Enabled == true )
                //{
                MySqlCommand cmd = new MySqlCommand("select* from tb_agenda where especialidade= ?", con);
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@especialidade", MySqlDbType.VarChar).Value = txtEspecialidade1.Text;
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
                    //txtCpf.Enabled = false;
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
            LimparBox2();
        }

        //metodo delete cadastro
        public void Excluir()
        {
            try
            {    //excluir dados no banco de dados
                MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User Id=root;database=bd_crudcad; ");
                objcon.Open();
                MySqlCommand objCmd = new MySqlCommand("delete from tb_agenda where id = ?", objcon);
                objCmd.Parameters.Clear();
                objCmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = tabeladeClientes.CurrentRow.Cells[0].Value.ToString(); ;
                //comando para executar query
                objCmd.CommandType = CommandType.Text;
                objCmd.ExecuteNonQuery();
                //mensagem
                // MessageBox.Show("Exclusão Realizada com Sucesso !!!");
                //fecha o banco de dados
                objcon.Close();
            }
            catch (Exception erro)
            {
                //MessageBox.Show("Dados não Excluidos !!!" + erro);
                LimparBox();
            }
        }
        public void LimparBox()
        {
            txtNome.Text = (" ");
            txtDataNasc.Text = (" ");
            txtmedico.Text = (" ");
            txtMae.Text = (" ");
            txtDataAtend.Text = (" ");
            txtHoraAtend.Text = (" ");
            txtCrm.Text = (" ");
            txtProntuario.Text = (" ");
            txtEspecialidade.Text = (" ");
        }
        //limpar todos os txt box dos campos de pesquisa
        public void LimparBox2()
        {
            txtmedico1.Text = (" ");
            txtEspecialidade1.Text = (" ");
            txtDataAtend.Text = (" ");
        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmOpcoes frm = new frmOpcoes();
            this.Visible = false;
            frm.ShowDialog();
        }

        private void frmVerificarAgenda_Load(object sender, EventArgs e)
        {

        }

        private void tabeladeClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtProntuario.Text = tabeladeClientes.CurrentRow.Cells[1].Value.ToString();
                txtNome.Text = tabeladeClientes.CurrentRow.Cells[2].Value.ToString();
                txtDataNasc.Text = tabeladeClientes.CurrentRow.Cells[3].Value.ToString();
                txtMae.Text = tabeladeClientes.CurrentRow.Cells[4].Value.ToString();
                txtmedico.Text = tabeladeClientes.CurrentRow.Cells[5].Value.ToString();
                txtEspecialidade.Text = tabeladeClientes.CurrentRow.Cells[6].Value.ToString();
                txtDataAtend.Text = tabeladeClientes.CurrentRow.Cells[7].Value.ToString();
                txtHoraAtend.Text = tabeladeClientes.CurrentRow.Cells[8].Value.ToString();
                txtCrm.Text = tabeladeClientes.CurrentRow.Cells[9].Value.ToString();

            }
            catch
            {

            }
        }

        private void txtmedico1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SelecionarDataGrewViewNome();
                btnBuscar1.Focus();
            }
        }

        private void txtDataAtend1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SelecionarDataGrewViewDataAtend();
                btnBuscar1.Focus();
            }
        }

        private void txtEspecialidade1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SelecionarDataGrewViewEspecialidade();
                btnBuscar1.Focus();
            }
        }

        private void btnBuscar1_Click(object sender, EventArgs e)
        {
                SelecionarDataGrewViewTodos();
                btnBuscar1.Focus();
        }

        private void btnBuscar1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SelecionarDataGrewViewTodos();
                btnBuscar1.Focus();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == " " || txtDataNasc.Text == " " )
            {
                MessageBox.Show("Necessario Realizar uma Busca!!!", "Mensagem");
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja EXCLUIR a consulta?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    //Sua rotina de exclusão
                    Excluir();
                    LimparBox();
                    limpardatagrewview();
                    //Confirmando exclusão para o usuário
                    MessageBox.Show("Consulta EXCLUIDA com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        public void limpardatagrewview()
        {
            //LIMPAR GRID
            tabeladeClientes.Rows.Clear();
            tabeladeClientes.Refresh();
        }
    }
}
