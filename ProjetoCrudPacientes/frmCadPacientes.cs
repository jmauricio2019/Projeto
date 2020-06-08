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
        string cns;
        int CNS, Prot, cpff;

        public frmCadPacientes()
        {
            InitializeComponent();
            LimparBox();//limpar campos ao iniciar o form
        }
        /// <summary>
        //realiza a busca de endereço pelo cep
        /// </summary>
        public void BuscarCep()
        {
            using (var ws = new WScorreios.AtendeClienteClient())
            {
                try
                {
                    var resultado = ws.consultaCEP(txtCep.Text);
                    txtRua.Text = resultado.end;
                    txtCidade.Text = resultado.cidade;
                    txtBairro.Text = resultado.bairro;
                    txtUf.Text = resultado.uf;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        //verifica se o cartão do sus é valido
        public void ValidaCns()
        {
            CNS = 0;
            cns = txtCns.Text;
            if (cns == null || cns.Trim().Length < 15)
            {
                MessageBox.Show("Número CNS inválido");
                txtCns.BackColor = Color.Red;
                txtCns.TextAlign = HorizontalAlignment.Left;

            }
            else
            {
                //1. Rotina de validação de Números que iniciam com 1 ou 2:
                if (cns.StartsWith("1") || cns.StartsWith("2"))
                {
                    float soma;
                    float resto, dv;
                    String pis = "";
                    String resultado = "";
                    pis = cns.Substring(0, 11);

                    soma = (Convert.ToInt32(pis.Substring(0, 1)) * 15) +
                            (Convert.ToInt32(pis.Substring(1, 1)) * 14) +
                            (Convert.ToInt32(pis.Substring(2, 1)) * 13) +
                            (Convert.ToInt32(pis.Substring(3, 1)) * 12) +
                            (Convert.ToInt32(pis.Substring(4, 1)) * 11) +
                            (Convert.ToInt32(pis.Substring(5, 1)) * 10) +
                            (Convert.ToInt32(pis.Substring(6, 1)) * 9) +
                            (Convert.ToInt32(pis.Substring(7, 1)) * 8) +
                            (Convert.ToInt32(pis.Substring(8, 1)) * 7) +
                            (Convert.ToInt32(pis.Substring(9, 1)) * 6) +
                            (Convert.ToInt32(pis.Substring(10, 1)) * 5);

                    //1º teste
                    resto = soma % 11;
                    dv = 11 - resto;

                    //2º teste
                    if (dv == 11)
                    {
                        dv = 0;
                    }

                    //3º teste
                    if (dv == 10)
                    {
                        soma += 2;

                        resto = soma % 11;
                        dv = 11 - resto;
                        resultado = pis + "001" + dv.ToString();
                    }
                    else
                    {
                        resultado = pis + "000" + dv.ToString();
                    }
                    if (dv == 0)
                    {
                        CNS = 1;
                        txtCns.BackColor = Color.DeepSkyBlue;
                        txtCns.TextAlign = HorizontalAlignment.Left;
                        txtMae.BackColor = Color.DeepSkyBlue;
                        txtMae.TextAlign = HorizontalAlignment.Left;
                        txtMae.Focus();

                    }


                }


                //2. Rotina de validação de Números que iniciam com 7, 8 ou 9:
                if (cns.StartsWith("7") || cns.StartsWith("8") || cns.StartsWith("9"))
                {
                    float resto, soma;

                    soma = (Convert.ToInt32(cns.Substring(0, 1)) * 15) +
                            (Convert.ToInt32(cns.Substring(1, 1)) * 14) +
                            (Convert.ToInt32(cns.Substring(2, 1)) * 13) +
                            (Convert.ToInt32(cns.Substring(3, 1)) * 12) +
                            (Convert.ToInt32(cns.Substring(4, 1)) * 11) +
                            (Convert.ToInt32(cns.Substring(5, 1)) * 10) +
                            (Convert.ToInt32(cns.Substring(6, 1)) * 9) +
                            (Convert.ToInt32(cns.Substring(7, 1)) * 8) +
                            (Convert.ToInt32(cns.Substring(8, 1)) * 7) +
                            (Convert.ToInt32(cns.Substring(9, 1)) * 6) +
                            (Convert.ToInt32(cns.Substring(10, 1)) * 5) +
                            (Convert.ToInt32(cns.Substring(11, 1)) * 4) +
                            (Convert.ToInt32(cns.Substring(12, 1)) * 3) +
                            (Convert.ToInt32(cns.Substring(13, 1)) * 2) +
                            (Convert.ToInt32(cns.Substring(14, 1)) * 1);


                    resto = soma % 11;


                    if (resto == 0)
                    {
                        CNS = 1;
                        txtCns.BackColor = Color.DeepSkyBlue;
                        txtCns.TextAlign = HorizontalAlignment.Left;
                        txtMae.BackColor = Color.DeepSkyBlue;
                        txtMae.TextAlign = HorizontalAlignment.Left;
                        txtMae.Focus();
                    }

                }

                //se for 3, 4, 5 ou 6 é inválido


            }

        }
        public void GerarProntuario()
        {
            //gerar número aleatorio
            Random numAleatorio = new Random();
            int valorInteiro = numAleatorio.Next(1, 3);//intervalo de numeros mudar aqui
            txtProntuario.Text = Convert.ToString(valorInteiro);
        }

        //inserir dados no banco de dados
        public void Cadastrar()
        {
            
            ValidaCns(); //verifica Prontuario com mesmo nome no Banco
            VerificaCPF();//verifica CPF com mesmo nome no Banco
            VerificaProntuario();
            //verificar campo vazio
            if (txtNome.Text == " " || txtDataNasc.Text == " " ||
                txtMae.Text == " " || txtTel1.Text == " " || txtCep.Text == " " || txtRua.Text == " " ||
                txtNum.Text == " " || txtBairro.Text == " " || txtCidade.Text == " " || txtUf.Text == " ")
            {
                MessageBox.Show("Os Campos Nome, Data de Nasc., tel1, Endereço" + "\n" + "\n" + "São Obrigatorios!!!", "Menssagem");
            }
            else
            {
                //verifica CNS

                if (CNS == 1 && cpff == 0 && Prot == 0)
                {
                    // vericando cpf
                    int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                    int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                    string cpf = txtCpf.Text;
                    cpf = cpf.Trim().Replace(".", "").Replace("-", "");
                    char[] arr;

                    arr = cpf.ToCharArray();
                    //verifica se todos os números são iguais para validar cpf
                    int cont = 0;
                    for (int i = 0; i < arr.Length - 1; i++)
                    {
                        if (arr[i] == arr[i + 1])
                        {
                            cont++;
                        }
                    }
                    int soma = 0;
                    if (arr.Length == 11)//verifica se tem a quantidade correta de numeros do cpf
                    {
                        for (int i = 0; i < 9; i++)
                            soma += int.Parse(arr[i].ToString()) * multiplicador1[i];

                        int resto = soma % 11;
                        if (resto < 2)
                            resto = 0;
                        else
                            resto = 11 - resto;
                        soma = 0;
                        for (int i = 0; i < 10; i++)
                            soma += int.Parse(arr[i].ToString()) * multiplicador2[i];

                        int resto1 = soma % 11;
                        if (resto1 < 2)
                            resto1 = 0;
                        else
                            resto1 = 11 - resto1;

                        if (resto == int.Parse(arr[9].ToString()) && resto1 == int.Parse(arr[10].ToString()) && cont != 10)
                        {
                            txtCpf.BackColor = Color.DeepSkyBlue;
                            txtCpf.TextAlign = HorizontalAlignment.Left;
                            txtCpf.Focus();
                            try
                            {    //inserir dados no banco de dados
                                MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User Id=root;database=bd_crudcad; ");
                                objcon.Open();
                                MySqlCommand objCmd = new MySqlCommand("insert into tb_paciente (prontuario, nome, datanasc, cpf, rg, cns, mae, \n" +
                                    " pai, tel1, tel2, email, cep, logadouro, num, bairro, cidade, \n" +
                                    " uf, observacoes) values( ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", objcon);

                                //parametros do comando sql
                                objCmd.Parameters.Add("@prontuario", MySqlDbType.VarChar, 10).Value = txtProntuario.Text;
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
                                LimparBox();
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
                            MessageBox.Show("CPF Inválido");

                            txtCpf.BackColor = Color.Red;
                            txtCpf.TextAlign = HorizontalAlignment.Left;
                            txtCpf.Focus();
                        }


                    }
                    else
                    {
                        MessageBox.Show("Faltam números no CPF");

                    }
                }
                else
                {
                    if (CNS != 1)
                    {
                        MessageBox.Show("Número CNS Inválido ");
                    }
                    if (cpff != 0)
                    {
                        MessageBox.Show("CPF Cadastrado!!! ");
                    }
                    if(Prot != 0)
                    {
                        MessageBox.Show("Há um cadastro com este Numero de Prontuario tecle em salvar novamente");
                        txtProntuario.Text = " ";
                        GerarProntuario();
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

        //selecionar dados do banco de dados
        public void VerificaCPF()
        {
            string cp = txtCpf.Text;
            cpff = 0;
            try
            {    //selecionar dados no banco de dados
                MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User Id=root; database=bd_crudcad; ");

                objcon.Open();
                //busca pelo cpf
                MySqlCommand objCmd = new MySqlCommand("select  prontuario,nome, datanasc, cpf, rg, cns, mae, pai, tel1, " +
                    "tel2, email, cep, logadouro, num, bairro, cidade, uf, observacoes from tb_paciente where  cpf=?",objcon);

                objCmd.Parameters.Clear();
                objCmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = txtCpf.Text;
                //comando para executar query
                objCmd.CommandType = CommandType.Text;

                //recebe conteudo do banco
                MySqlDataReader dr;
                dr = objCmd.ExecuteReader();

                dr.Read();

                String cpftest = dr.GetString(3);
                if (cpftest == cp)
                {
                    cpff = 1;
                }
                //mensagem
                //fecha o banco de dados
                objcon.Close();
            }
            catch (Exception)
            {
                
            }


        }

        public void SelecionarDataGrewView()
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
            string name = txtNome1.Text;
            string cpf = txtCpf1.Text;
            string dat = txtDataNasc1.Text;
            string ide = txtProntuario1.Text;
            try
            {    //selecionar dados no banco de dados

                // define a string de conexao com provedor caminho e nome do banco de dados
                string strProvider = "server=localhost;port=3306;User Id=root;database=bd_crudcad;";
                //cria a conexão com o banco de dados
                MySqlConnection con = new MySqlConnection(strProvider);
                //define a instrução SQL
                string strSql = "select * from tb_paciente";
                if (txtCpf1.Enabled == true)
                {
                    strSql = "select * from tb_paciente where cpf like '%" + cpf + "%'";
                }
                if (txtDataNasc1.Enabled == true)
                {
                    strSql = "select * from tb_paciente where datanasc like '%" + dat + "%'";
                }
                if (txtProntuario1.Enabled == true)
                {
                    strSql = "select * from tb_paciente where prontuario like '%" + ide + "%'";
                }
                if (txtNome.Enabled == true)
                {
                    strSql = "select * from tb_paciente where nome like '%" + name + "%'";
                }

                //abre a conexao
                con.Open();
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
            
            txtNome1.Text = "";
            txtCpf1.Text = "";
            txtDataNasc1.Text = "";
            txtProntuario1.Text = "";

            txtProntuario1.Enabled = true;
            txtCpf1.Enabled = true;
            txtNome1.Enabled = true;
            txtDataNasc1.Enabled = true;

        }

        //limpar datagrewview

        public void limpardatagrewview()
        {
            //LIMPAR GRID
            tabeladeClientes.Rows.Clear();
            tabeladeClientes.Refresh();
        }

        //atualiar dados no banco de dados
        public void Atualizar()
        {
            if (txtNome.Text == " " || txtDataNasc.Text == " " ||
                txtMae.Text == " " || txtTel1.Text == " " || txtCep.Text == " " || txtRua.Text == " " ||
                txtNum.Text == " " || txtBairro.Text == " " || txtCidade.Text == " " || txtUf.Text == " ")
            {
                MessageBox.Show("Os Campos Nome, Data de Nasc., tel1, Endereço" + "\n" + "\n" + "São Obrigatorios!!!" , "Menssagem");
            }
            else
            {
                //atualizar dados no banco de dados

                try
                {    //atualizar dados no banco de dados
                    MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User Id=root;database=bd_crudcad; ");
                    objcon.Open();
                    MySqlCommand objCmd = new MySqlCommand("update tb_paciente set nome = ?," +
                        "" +
                        " datanasc = ?," +
                        " rg = ?, cns = ?, mae = ?, pai = ?, tel1 = ?, tel2 = ?, email = ?, cep = ?, logadouro = ?," +
                        " num = ?, bairro = ?, cidade = ?, uf = ?, observacoes = ? where cpf = ?", objcon);
                    objCmd.Parameters.Clear();

                    //parametros do comando sql
                    objCmd.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = txtNome.Text;
                    objCmd.Parameters.Add("@datanasc", MySqlDbType.VarChar, 17).Value = txtDataNasc.Text;
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
                    objCmd.Parameters.Add("@cpf", MySqlDbType.VarChar, 18).Value = txtCpf.Text;
                    //comando para executar query
                    objCmd.CommandType = CommandType.Text;
                    objCmd.ExecuteNonQuery();
                    //fecha o banco de dados
                    objcon.Close();

                    //mensagem
                    MessageBox.Show("Atualizado com Sucesso !!!");
                    LimparBox();

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
            //verificar campo vazio
            if (txtNome.Text == " " || txtDataNasc.Text == " " ||
                txtMae.Text == " " || txtTel1.Text == " " || txtCep.Text == " " || txtRua.Text == " " ||
                txtNum.Text == " " || txtBairro.Text == " " || txtCidade.Text == " " || txtUf.Text == " ")
            {
                MessageBox.Show("Os Campos Nome, Data de Nasc., tel1, Endereço" + "\n" + "\n" + "São Obrigatorios!!!", "Menssagem");
            }
            else
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
            LimparBox();
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
        //limpar todos os txt box dos campos de pesquisa
        public void LimparBox2()
        {
            txtNome1.Text = (" ");
            txtDataNasc1.Text = (" ");
            txtCpf1.Text = (" ");
            txtProntuario1.Text = (" ");
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
            SelecionarDataGrewView();
            //LimparBox2();


        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Cadastrar();

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Atualizar();
            LimparBox();
            limpardatagrewview();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
            LimparBox();
            limpardatagrewview();
        }

        private void checkBoxIncluirCadastro_CheckedChanged(object sender, EventArgs e)
        {
            txtProntuario.ReadOnly = true;
            btnSalvar.Enabled = true;
            btnAtualizar.Enabled = false;
            btnExcluir.Enabled = false;
            VerificaCPF();
            LimparBox();
            txtNome.TextAlign = HorizontalAlignment.Left;
            txtNome.Focus();
        }

        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tel: " + "\n" + "\n" + "josehvvn@gmail.com" + "\n" + "\n" + "raphaelacacio84@gmail.com", "Ajuda?");
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                txtDataNasc.TextAlign = HorizontalAlignment.Left;
                txtDataNasc.Focus();
            }
        }

        private void txtDataNasc_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                txtCpf.TextAlign = HorizontalAlignment.Left;
                txtCpf.Focus();
            }
        }

        private void txtCpf_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                {
                    int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                    int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                    string cpf = txtCpf.Text;
                    cpf = cpf.Trim().Replace(".", "").Replace("-", "");
                    char[] arr;
                    arr = cpf.ToCharArray();

                    //verifica se todos os números são iguais para validar cpf
                    int cont = 0;
                    for (int i = 0; i < arr.Length - 1; i++)
                    {
                        if (arr[i] == arr[i + 1])
                        {
                            cont++;
                        }
                    }
                    if (arr.Length == 11)//verifica quantidade de cpf
                    {
                        int soma = 0;

                        for (int i = 0; i < 9; i++)
                            soma += int.Parse(arr[i].ToString()) * multiplicador1[i];

                        int resto = soma % 11;
                        if (resto < 2)
                            resto = 0;
                        else
                            resto = 11 - resto;



                        soma = 0;
                        for (int i = 0; i < 10; i++)
                            soma += int.Parse(arr[i].ToString()) * multiplicador2[i];

                        int resto1 = soma % 11;
                        if (resto1 < 2)
                            resto1 = 0;
                        else
                            resto1 = 11 - resto1;

                        if (resto == int.Parse(arr[9].ToString()) && resto1 == int.Parse(arr[10].ToString()) && cont != 10)
                        {
                            VerificaProntuario();
                            txtCpf.TextAlign = HorizontalAlignment.Left;
                            txtCpf.Focus();
                            txtRg.TextAlign = HorizontalAlignment.Left;
                            txtRg.Focus();
                        }
                        else
                        {
                            MessageBox.Show("CPF Inválido");

                            txtCpf.BackColor = Color.Red;
                            txtCpf.TextAlign = HorizontalAlignment.Left;
                            txtCpf.Focus();
                        }


                    } else
                    {
                        MessageBox.Show("Faltam números no CPF");
                    }

                }

            }
        }

        private void txtRg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtCns.TextAlign = HorizontalAlignment.Left;
                txtCns.Focus();
            }
        }
        private void txtCns_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cns = "";
                cns = txtCns.Text;
                CNS = 0;// Zerar caso tenha salvo na memoria
                ValidaCns();
                if (CNS != 1)
                {
                    txtCns.BackColor = Color.Red;
                    txtCns.TextAlign = HorizontalAlignment.Left;
                }
            }

        }

        private void txtMae_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtPai.TextAlign = HorizontalAlignment.Left;
                txtPai.Focus();
            }
        }

        private void txtPai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtTel1.TextAlign = HorizontalAlignment.Left;
                txtTel1.Focus();
            }
        }

        private void txtTel1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtTel2.TextAlign = HorizontalAlignment.Left;
                txtTel2.Focus();
            }
        }

        private void txtTel2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtEmail.TextAlign = HorizontalAlignment.Left;
                txtEmail.Focus();
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtCep.TextAlign = HorizontalAlignment.Left;
                txtCep.Focus();
            }
        }

        private void txtCep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtRua.TextAlign = HorizontalAlignment.Left;
                BuscarCep();
                txtRua.Focus();
            }
        }

        private void txtRua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNum.TextAlign = HorizontalAlignment.Left;
                txtNum.Focus();
            }
        }

        private void txtNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtBairro.TextAlign = HorizontalAlignment.Left;
                txtBairro.Focus();
            }
        }

        private void txtBairro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtCidade.TextAlign = HorizontalAlignment.Left;
                txtCidade.Focus();
            }
        }

        private void txtCidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtUf.TextAlign = HorizontalAlignment.Left;
                txtUf.Focus();
            }
        }

        private void txtUf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtObservacoes.TextAlign = HorizontalAlignment.Left;
                txtObservacoes.Focus();
            }
        }

        private void txtObservacoes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSalvar.Focus();
            }
        }

        private void btnSalvar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Cadastrar();
                LimparBox();
                btnSalvar.Enabled = false;
                btnAtualizar.Enabled = false;
                btnExcluir.Enabled = false;
                checkBoxIncluirCadastro.Focus();
            }
        }

        private void txtCpf1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SelecionarDataGrewView();
            }
        }

        private void txtNome1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SelecionarDataGrewView();
            }
        }

        private void txtDataNasc1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SelecionarDataGrewView();
            }
        }

        private void txtProntuario1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SelecionarDataGrewView();
            }
        }

        private void txtProntuario_TextChanged(object sender, EventArgs e)
        {
            txtProntuario.ReadOnly = true;
        }

        private void btnBuscarCep_Click(object sender, EventArgs e)
        {
            BuscarCep();
        }

        private void tabeladeClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //desabilitar salvar
            btnSalvar.Enabled = false;
            btnAtualizar.Enabled = true;
            btnExcluir.Enabled = true;
            try
            {
                txtNome.Text = tabeladeClientes.CurrentRow.Cells[1].Value.ToString();
                txtDataNasc.Text = tabeladeClientes.CurrentRow.Cells[2].Value.ToString();
                txtCpf.Text = tabeladeClientes.CurrentRow.Cells[3].Value.ToString();
                txtRg.Text = tabeladeClientes.CurrentRow.Cells[4].Value.ToString();
                txtCns.Text = tabeladeClientes.CurrentRow.Cells[5].Value.ToString();
                txtMae.Text = tabeladeClientes.CurrentRow.Cells[6].Value.ToString();
                txtPai.Text = tabeladeClientes.CurrentRow.Cells[7].Value.ToString();
                txtTel1.Text = tabeladeClientes.CurrentRow.Cells[8].Value.ToString();
                txtTel2.Text = tabeladeClientes.CurrentRow.Cells[9].Value.ToString();
                txtEmail.Text = tabeladeClientes.CurrentRow.Cells[10].Value.ToString();
                txtCep.Text = tabeladeClientes.CurrentRow.Cells[11].Value.ToString();
                txtRua.Text = tabeladeClientes.CurrentRow.Cells[12].Value.ToString();
                txtNum.Text = tabeladeClientes.CurrentRow.Cells[13].Value.ToString();
                txtBairro.Text = tabeladeClientes.CurrentRow.Cells[14].Value.ToString();
                txtCidade.Text = tabeladeClientes.CurrentRow.Cells[15].Value.ToString();
                txtUf.Text = tabeladeClientes.CurrentRow.Cells[16].Value.ToString();
                txtObservacoes.Text = tabeladeClientes.CurrentRow.Cells[17].Value.ToString();
            }
            catch
            {

            }

        }

        private void txtNome1_Click(object sender, EventArgs e)
        {
            txtProntuario1.Enabled = false;
            txtCpf1.Enabled = false;
            txtDataNasc1.Enabled = false;
        }

        private void txtProntuario1_Click(object sender, EventArgs e)
        {
            txtCpf1.Enabled = false;
            txtNome1.Enabled = false;
            txtDataNasc1.Enabled = false;
        }

        private void txtDataNasc1_Click(object sender, EventArgs e)
        {
            txtCpf1.Enabled = false;
            txtNome1.Enabled = false;
            txtProntuario1.Enabled = false;
        }

        private void txtCpf1_Click(object sender, EventArgs e)
        {
            txtDataNasc1.Enabled = false;
            txtNome1.Enabled = false;
            txtProntuario1.Enabled = false;
        }

        private void tabeladeClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtNome_Click(object sender, EventArgs e)
        {
            GerarProntuario();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //lblHora.Text = DateTime.Now.ToLongTimeString();
           //lblHora.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

    }
            
    
}
