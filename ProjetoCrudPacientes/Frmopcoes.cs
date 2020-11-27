using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace ProjetoCrudPacientes
{
    public partial class frmOpcoes : Form 
    {
        string nome;
        public frmOpcoes()
        {
            InitializeComponent();
           
        }
            private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCadastrodeClientes_Click(object sender, EventArgs e)
        {
            frmCadPacientes frm = new frmCadPacientes();
            frm.ShowDialog();
        }

        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //lblHora.Text = DateTime.Now.ToLongTimeString();
            lblHora.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {

        }

        private void frmOpcoes_Load(object sender, EventArgs e)
        {
            nome = lblUsuario.Text;


            try
            {    //selecionar dados no banco de dados
                MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User Id=root; database=bd_crudcad; ");

                objcon.Open();
                //busca pelo prontuario
                MySqlCommand objCmd = new MySqlCommand("select   cargo  from tb_colaborador where  nome= ?", objcon);

                objCmd.Parameters.Clear();

                objCmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = lblUsuario.Text;

                //comando para executar query
                objCmd.CommandType = CommandType.Text;

                //recebe conteudo do banco
                MySqlDataReader dr;
                dr = objCmd.ExecuteReader();

                dr.Read();

                String pront = dr.GetString(0);
                if (pront == "RECEPCIONISTA")
                {
                    button3.Visible = false;
                    button4.Visible = false;
                    button1.Visible = false;

                }
                if (pront == "MÉDICO")
                {
                    button1.Visible = false;
                    button3.Visible = false;
                    btnCadastrodeClientes.Visible = false;
                }
                if (pront == "ENFERMEIRO")
                {
                    button1.Visible = false;
                    button4.Visible = false;
                    btnCadastrodeClientes.Visible = false;
                }

                objcon.Close();
            }
            catch (Exception)
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCadColaboradorescs frm = new frmCadColaboradorescs();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmTriagem frm = new frmTriagem();
            this.Visible = false;
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmVerificarAgenda frm = new frmVerificarAgenda();
            this.Visible = false;
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            frmConsulta frm = new frmConsulta();
            this.Visible = false;
            frm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmHistoricoAtendimento frm = new frmHistoricoAtendimento();
            frm.lblUsuario.Text = nome;
            this.Visible = false;
            frm.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCadColaboradorescs frm = new frmCadColaboradorescs();
            frm.ShowDialog();
        }
    }
}
