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
using Root.Reports;

namespace ProjetoCrudPacientes
{
   
    public partial class frmHistoricoAtendimento : Form
    {
     
        public frmHistoricoAtendimento()
        {
            InitializeComponent();
            // inicializa o form sem poder editar os txtbox
            txtNome.Enabled = false;
            txtProntuario.Enabled = false;
            txtDataNasc.Enabled = false; ;
            txtmedico.Enabled = false;
            txtEspecialidade.Enabled = false;
            txtDataAtend.Enabled = false;
            txtPesoKg.Enabled = false;
            txtPressaoArterial.Enabled = false;
            txtGlicose.Enabled = false;
            txtTemperatura.Enabled = false;
            txtSaturacao.Enabled = false;
            txtRelatoPaciente.Enabled = false;
            txtRelatoMedico.Enabled = false;
           
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmOpcoes frm = new frmOpcoes();
            frm.lblUsuario.Text = lblUsuario.Text;
            this.Visible = false;
            frm.ShowDialog();
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
                string strSql = "select * from tb_consulta ";
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
                    MessageBox.Show("Não há Consulta");
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
                string strSql = "select * from tb_consulta where paciente like '%" + name + "%'";
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
                    MessageBox.Show("Não há Consulta");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("busca nao realizada" + erro);
            }
            LimparBox2();
            //TextBox();
        }
        //metodo select pelo data de atendimento do cadastrado
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
                MySqlCommand cmd = new MySqlCommand("select* from tb_consulta where datadeatend = ?", con);
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
                    MessageBox.Show("Não há Consulta");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("busca nao realizada" + erro);
            }
            LimparBox2();
        }

        public void SelecionarDataGrewViewDataNasc()
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
                MySqlCommand cmd = new MySqlCommand("select* from tb_consulta where datanasc = ?", con);
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@datanasc", MySqlDbType.VarChar).Value = txtDataNasc1.Text;
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
                    MessageBox.Show("Não há Consulta");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("busca nao realizada" + erro);
            }
             LimparBox2();
        }

        public void SelecionarDataGrewViewProntuario()
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
                MySqlCommand cmd = new MySqlCommand("select* from tb_consulta where prontuario = ?", con);
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@prontuario", MySqlDbType.VarChar).Value = txtProntuario.Text;
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
                    MessageBox.Show("Não há Consulta");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("busca nao realizada" + erro);
            }
             LimparBox2();
        }
        private void frmHistoricoAtendimento_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar1_Click(object sender, EventArgs e)
        {
            SelecionarDataGrewViewTodos();
        }

        private void txtNome1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SelecionarDataGrewViewNome();
               
            }
        }

        private void txtDataNasc1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SelecionarDataGrewViewDataNasc();
            }
        }

        private void txtDataAtend1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SelecionarDataGrewViewDataAtend();
            }
        }

        private void txtProntuario1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SelecionarDataGrewViewProntuario();
            }
        }

        private void tabeladeClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtProntuario.Text = tabeladeClientes.CurrentRow.Cells[1].Value.ToString();
                txtNome.Text = tabeladeClientes.CurrentRow.Cells[2].Value.ToString();
                txtDataAtend.Text = tabeladeClientes.CurrentRow.Cells[3].Value.ToString();
                txtDataNasc.Text = tabeladeClientes.CurrentRow.Cells[4].Value.ToString();
                txtmedico.Text = tabeladeClientes.CurrentRow.Cells[5].Value.ToString();
                txtEspecialidade.Text = tabeladeClientes.CurrentRow.Cells[6].Value.ToString();
                txtPesoKg.Text = tabeladeClientes.CurrentRow.Cells[7].Value.ToString();
                txtPressaoArterial.Text = tabeladeClientes.CurrentRow.Cells[8].Value.ToString();
                txtGlicose.Text = tabeladeClientes.CurrentRow.Cells[9].Value.ToString();
                txtTemperatura.Text = tabeladeClientes.CurrentRow.Cells[10].Value.ToString();
                txtSaturacao.Text = tabeladeClientes.CurrentRow.Cells[11].Value.ToString();
                txtRelatoPaciente.Text = tabeladeClientes.CurrentRow.Cells[12].Value.ToString();
                txtRelatoMedico.Text = tabeladeClientes.CurrentRow.Cells[14].Value.ToString();
            }
            catch
            {

            }
        }
        public void limpardatagrewview()
        {
            //LIMPAR GRID
            tabeladeClientes.Rows.Clear();
            tabeladeClientes.Refresh();
        }

        public void LimparBox()
        {
            txtNome.Text = (" ");
            txtProntuario.Text = (" ");
            txtNome.Text = (" ");
            txtDataAtend.Text = (" ");
            txtDataNasc.Text = (" ");
            txtmedico.Text = (" ");
            txtEspecialidade.Text = (" ");
            txtPesoKg.Text = (" ");
            txtPressaoArterial.Text = (" ");
            txtGlicose.Text = (" ");
            txtTemperatura.Text = (" ");
            txtSaturacao.Text = (" ");
            txtRelatoPaciente.Text = (" ");
            txtRelatoMedico.Text = (" ");
        }
            //limpar todos os txt box dos campos de pesquisa
            public void LimparBox2()
        {
            txtNome1.Text = (" ");
            txtDataNasc1.Text = (" ");
            txtDataAtend.Text = (" ");
            txtProntuario1.Text = (" ");
        }


        public void GerarPdf()
        {
            // Variavel do Nome e caminho do arquivo
            string vArq = "";
            // Abre janela para usuário escolher a pasta onde o arquivo será gerado

            FolderBrowserDialog vSalvar = new FolderBrowserDialog();
            // Verifica se o usuário clicou em ok ou cancelar na janela de seleção da pasta

            if (vSalvar.ShowDialog() == DialogResult.Cancel)
                return; // Cancela todo processo
            // Insere na variavel o caminho selecionado pelo usuário e concatena com o nome do arquivo
            vArq = vSalvar.SelectedPath + "\\" + txtNome.Text.Trim() + ".pdf";
            try
            {
                // Cria um objeto PDF
                Report vPdf = new Report(new PdfFormatter());

                // Define a fonte que sera usada no relatório PDF
                FontDef vDef = new FontDef(vPdf, FontDef.StandardFont.TimesRoman);



                // Define o tamanho a fonte que sera usada no relatório PDF
                FontProp vDrop = new FontProp(vDef, 10);//tamanho da fonte
                FontProp vProp = new FontProp(vDef, 5);// tamanho da fonte
                FontProp vTrop = new FontProp(vDef, 8);// tamanho da fonte
                FontProp vGrop = new FontProp(vDef, 7);// tamanho da fonte


                // Cria uma Nova Pagina
                Page vPage = new Page(vPdf);

                // Escreve no Arquivo
                vPage.AddCB_MM(10, new RepString(vDrop, "FICHA DE ATENDIMENTO AMBULATORIAL - FAA")); // Centraliza
                vPage.AddCB_MM(20, new RepString(vDrop, "UBS RITA ASSIS")); // Centraliza
                vPage.AddCB_MM(25, new RepString(vProp, "RUA: AVENIDA SEM NOME")); // Centraliza
                vPage.AddCB_MM(30, new RepString(vProp, "CONTATO: (00) 0000-0000")); // CentralizA
                vPage.AddCB_MM(40, new RepString(vDrop, "IDENTIFICAÇÃO DO PACIENTE")); // Centraliza
                vPage.AddCB_MM(32, new RepString(vDrop, "_____________________________________________________________________________")); // define lado + altura

                vPage.AddCB_MM(20, 50, new RepString(vTrop, "ATENDIMENTO: ")); // define lado + altura
                vPage.AddCB_MM(45, 50, new RepString(vGrop, txtDataAtend.Text)); // define lado + altura pega o texto do box

                vPage.AddCB_MM(15, 60, new RepString(vDrop, "NOME: ")); // define lado + altura
                vPage.AddCB_MM(45, 60, new RepString(vGrop, txtNome.Text)); // define lado + altura pega o texto do box

                vPage.AddCB_MM(160, 60, new RepString(vTrop, "PRONTUARIO: ")); // define lado + altura
                vPage.AddCB_MM(180, 60, new RepString(vGrop, txtProntuario.Text)); // define lado + altura pega o texto do box

                vPage.AddCB_MM(20, 70, new RepString(vTrop, "DATA NASC.: ")); // define lado + altura
                vPage.AddCB_MM(40, 70, new RepString(vGrop, txtDataNasc.Text)); // define lado + altura pega o texto do box

                vPage.AddCB_MM(85, new RepString(vDrop, "DADOS DO ATENDIMENTO")); // Centraliza
                vPage.AddCB_MM(88, new RepString(vDrop, "_____________________________________________________________________________")); // define lado + altura

                vPage.AddCB_MM(20, 95, new RepString(vTrop, "MÉDICO: ")); // define lado + altura
                vPage.AddCB_MM(40, 95, new RepString(vGrop, txtmedico.Text)); // define lado + altura pega o texto do box

                vPage.AddCB_MM(130, 95, new RepString(vTrop, "ESPECIALIDADE: ")); // define lado + altura
                vPage.AddCB_MM(165, 95, new RepString(vGrop, txtEspecialidade.Text)); // define lado + altura pega o texto do box

                vPage.AddCB_MM(15, 110, new RepString(vTrop, "PESO: ")); // define lado + altura
                vPage.AddCB_MM(30, 110, new RepString(vGrop, txtPesoKg.Text)); // define lado + altura pega o texto do box

                vPage.AddCB_MM(100, 110, new RepString(vTrop, "PRESSÃO ARTERIAL: ")); // define lado + altura
                vPage.AddCB_MM(130, 110, new RepString(vGrop, txtPressaoArterial.Text)); // define lado + altura pega o texto do box

                vPage.AddCB_MM(160, 110, new RepString(vTrop, "GLISSEMIA: ")); // define lado + altura
                vPage.AddCB_MM(180, 110, new RepString(vGrop, txtGlicose.Text)); // define lado + altura pega o texto do box

                vPage.AddCB_MM(25, 120, new RepString(vTrop, "TEMPERATURA: ")); // define lado + altura
                vPage.AddCB_MM(48, 120, new RepString(vGrop, txtTemperatura.Text)); // define lado + altura pega o texto do box

                vPage.AddCB_MM(100, 120, new RepString(vTrop, "SATURAÇÃO: ")); // define lado + altura
                vPage.AddCB_MM(120, 120, new RepString(vGrop, txtSaturacao.Text)); // define lado + altura pega o texto do box

                vPage.AddCB_MM(124, new RepString(vDrop, "_____________________________________________________________________________")); // define lado + altura
                vPage.AddCB_MM(35, 135, new RepString(vTrop, "RELATO PACIENTE: ")); // define lado + altura
                vPage.AddCB_MM(35, 140, new RepString(vGrop, txtRelatoPaciente.Text)); // define lado + altura pega o texto do box

                vPage.AddCB_MM(173, new RepString(vDrop, "_____________________________________________________________________________")); // define lado + altura
                vPage.AddCB_MM(35, 180, new RepString(vTrop, "RELATORIO MÉDICO: ")); // define lado + altura
                vPage.AddCB_MM(40, 185, new RepString(vGrop, txtRelatoMedico.Text)); // define lado + altura pega o texto do box

                vPage.AddCB_MM(260, new RepString(vDrop, "_____________________________________________________________________________")); // define lado + altura
                vPage.AddCB_MM(35, 275, new RepString(vProp, "________________________________")); // define lado + altura
                vPage.AddCB_MM(35, 280, new RepString(vProp, "ASS. MÉDICO: ")); // define lado + altura
                vPage.AddCB_MM(160, 275, new RepString(vProp, "________________________________")); // define lado + altura
                vPage.AddCB_MM(160, 280, new RepString(vProp, "ASS. RESPONSÁVEL: ")); // define lado + altura


               // vPage.AddCB_MM(15, 350, new RepString(vDrop, txtTextoArquivo2.Text)); // define lado + altura pega o texto do box
                // vPage.AddCB_MM(15, 350, new RepString(vGrop, txtTextoArquivo2.Text)); // define lado + altura pega o texto do box

                // Salvar Arquivo no disco
                vPdf.Save(vArq);
                MessageBox.Show("FAA Gerada com sucesso !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Gerar arquivo !!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            GerarPdf();
            limpardatagrewview();
            LimparBox();
        }

        private void tabeladeClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
