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
    public partial class frmAnamnese : Form
    {
        string cns, Cpff;
        int CNS, Prot, cpff, cnss;
        public frmAnamnese()
        {
            InitializeComponent();
        }

        public frmAnamnese(string valor, string valor1, string valor2, string valor3, string valor4, 
            string valor5, string valor6, string valor7, string valor8, 
            string valor9, string valor10, string valor11, string valor12)
        {
            InitializeComponent();
            txtNome.Text = valor;
            txtProntuario.Text = valor1;
            txtDataNasc.Text = valor2;
            txtDataAtend.Text = valor3;           
            txtmedico.Text = valor4;
            txtEspecialidade.Text = valor5;
            txtPesoKg.Text = valor6;
            txtPressaoArterial.Text = valor7;
            txtGlicose.Text = valor8;
            txtTemperatura.Text = valor9;
            txtSaturacao.Text = valor10;
            txtRelatoPaciente.Text = valor11;
            txtHoraTriagem.Text = valor12;
            
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
            txtHoraTriagem.Enabled = false;


        }
        public void Verificatriagem()
        {
            string id = txtEspecialidade.Text;
            Prot = 0;
            try
            {    //selecionar dados no banco de dados
                MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User Id=root; database=bd_crudcad; ");

                objcon.Open();
                //busca pelo prontuario
                MySqlCommand objCmd = new MySqlCommand("select  prontuario, paciente, dataatend, datanasc,  medico," +
                    " especialidade, pesokg, pressaoarterial, glicose, temperatura, saturacao, relatoriopaciente, relatoriomedico, horatriagem, from tb_consulta where  especialidade= ?", objcon);

                objCmd.Parameters.Clear();

                objCmd.Parameters.Add("@horatriagem", MySqlDbType.VarChar).Value = txtHoraTriagem.Text;

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


        //metodo cadastrar
        public void Cadastrar()
        {
            //ValidaCns(); //verifica Prontuario com mesmo nome no Banco
            Verificatriagem();
            //verificar campo vazio
            //verificar campo vazio
            if (txtPesoKg.Text == " " || txtPressaoArterial.Text == " " ||
                 txtGlicose.Text == " " || txtTemperatura.Text == " " ||
                txtSaturacao.Text == " " || txtRelatoPaciente.Text == " " || txtHoraTriagem.Text == " ")
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
                        MySqlCommand objCmd = new MySqlCommand("insert into tb_consulta (prontuario, paciente, datadeatend, datanasc, " +
                            " medico, especialidade, pesokg, pressaoarterial, glicose, temperatura, " +
                            "saturacao, relatoriopaciente, horatriagem) values( ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", objcon);
                        //parametros do comando sql
                        objCmd.Parameters.Add("@prontuario", MySqlDbType.VarChar, 10).Value = txtProntuario.Text;
                        objCmd.Parameters.Add("@paciente", MySqlDbType.VarChar, 100).Value = txtNome.Text;
                        objCmd.Parameters.Add("@datadeatend", MySqlDbType.VarChar, 17).Value = txtDataAtend.Text;
                        objCmd.Parameters.Add("@datanasc", MySqlDbType.VarChar, 17).Value = txtDataNasc.Text;
                        objCmd.Parameters.Add("@medico", MySqlDbType.VarChar, 17).Value = txtmedico.Text;
                        objCmd.Parameters.Add("@especialidade", MySqlDbType.VarChar, 17).Value = txtEspecialidade.Text;
                        objCmd.Parameters.Add("@pesokg", MySqlDbType.VarChar, 17).Value = txtPesoKg.Text;
                        objCmd.Parameters.Add("@pressaoarterial", MySqlDbType.VarChar, 17).Value = txtPressaoArterial.Text;
                        objCmd.Parameters.Add("@glicose", MySqlDbType.VarChar, 17).Value = txtGlicose.Text;
                        objCmd.Parameters.Add("@temperatura", MySqlDbType.VarChar, 17).Value = txtTemperatura.Text;
                        objCmd.Parameters.Add("@saturacao", MySqlDbType.VarChar, 17).Value = txtSaturacao.Text;
                        objCmd.Parameters.Add("@relatoriopaciente", MySqlDbType.VarChar, 99).Value = txtRelatoPaciente.Text;
                        objCmd.Parameters.Add("@horatriagem", MySqlDbType.VarChar, 17).Value = txtHoraTriagem.Text;
                        objCmd.Parameters.Add("@horatriagem", MySqlDbType.VarChar, 17).Value = txtRelatoMedico.Text;


                        //para colocar os estados no combo box
                        //cmbestado.itens.add("sp");
                        //comando para executar query
                        objCmd.ExecuteNonQuery();
                        MessageBox.Show("Anamnese Salva com Sucesso!!!");
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
                        MessageBox.Show("Anamnese NÃO Salva!!!" + erro);
                    }
                }
                else
                {
                    Verificatriagem();
                    if (Prot != 0)
                    {
                        MessageBox.Show("Há uma Anamnese para este paciente!!!");
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
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            frmConsulta frm = new frmConsulta();
            this.Visible = false;
            frm.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmAnamnese_Load(object sender, EventArgs e)
        {

        }
    }
}
