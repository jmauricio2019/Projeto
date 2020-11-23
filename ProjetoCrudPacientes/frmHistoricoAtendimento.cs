﻿using System;
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            limpardatagrewview();
            LimparBox();
        }
    }
}
