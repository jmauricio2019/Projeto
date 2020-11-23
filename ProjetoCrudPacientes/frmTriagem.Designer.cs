namespace ProjetoCrudPacientes
{
    partial class frmTriagem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTriagem));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDataAtend2 = new System.Windows.Forms.DateTimePicker();
            this.txtNome1 = new System.Windows.Forms.TextBox();
            this.tabeladeClientes = new System.Windows.Forms.DataGridView();
            this.btnBuscar1 = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtHoraTriagem = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDataAtend = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRelatoPaciente = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEspecialidade = new System.Windows.Forms.ComboBox();
            this.txtmedico = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.txtProntuario = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtDataNasc = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mySqlConnection1 = new MySql.Data.MySqlClient.MySqlConnection();
            this.txtPressaoArterial = new System.Windows.Forms.MaskedTextBox();
            this.txtPesoKg = new System.Windows.Forms.MaskedTextBox();
            this.txtTemperatura = new System.Windows.Forms.MaskedTextBox();
            this.txtSaturacao = new System.Windows.Forms.MaskedTextBox();
            this.txtGlicose = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabeladeClientes)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.txtDataAtend2);
            this.groupBox1.Controls.Add(this.txtNome1);
            this.groupBox1.Controls.Add(this.tabeladeClientes);
            this.groupBox1.Controls.Add(this.btnBuscar1);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(15, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1327, 316);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            // 
            // txtDataAtend2
            // 
            this.txtDataAtend2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtDataAtend2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataAtend2.Location = new System.Drawing.Point(148, 44);
            this.txtDataAtend2.Name = "txtDataAtend2";
            this.txtDataAtend2.Size = new System.Drawing.Size(118, 24);
            this.txtDataAtend2.TabIndex = 117;
            this.txtDataAtend2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDataAtend2_KeyPress);
            // 
            // txtNome1
            // 
            this.txtNome1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome1.Location = new System.Drawing.Point(104, 12);
            this.txtNome1.Name = "txtNome1";
            this.txtNome1.Size = new System.Drawing.Size(415, 24);
            this.txtNome1.TabIndex = 62;
            this.txtNome1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNome1_KeyPress);
            // 
            // tabeladeClientes
            // 
            this.tabeladeClientes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.tabeladeClientes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabeladeClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabeladeClientes.Location = new System.Drawing.Point(16, 79);
            this.tabeladeClientes.Name = "tabeladeClientes";
            this.tabeladeClientes.Size = new System.Drawing.Size(1293, 220);
            this.tabeladeClientes.TabIndex = 57;
            this.tabeladeClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabeladeClientes_CellClick);
            // 
            // btnBuscar1
            // 
            this.btnBuscar1.BackColor = System.Drawing.Color.DarkMagenta;
            this.btnBuscar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBuscar1.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar1.Image")));
            this.btnBuscar1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar1.Location = new System.Drawing.Point(533, 4);
            this.btnBuscar1.Name = "btnBuscar1";
            this.btnBuscar1.Size = new System.Drawing.Size(116, 37);
            this.btnBuscar1.TabIndex = 49;
            this.btnBuscar1.Text = "     BUSCAR";
            this.btnBuscar1.UseVisualStyleBackColor = false;
            this.btnBuscar1.Click += new System.EventHandler(this.btnBuscar1_Click);
            this.btnBuscar1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnBuscar1_KeyPress);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Poor Richard", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label19.Location = new System.Drawing.Point(21, 47);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(123, 22);
            this.label19.TabIndex = 40;
            this.label19.Text = "Data do Aten.";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Poor Richard", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label18.Location = new System.Drawing.Point(20, 11);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 22);
            this.label18.TabIndex = 38;
            this.label18.Text = "Paciente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poor Richard", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(1023, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 41);
            this.label1.TabIndex = 21;
            this.label1.Text = "Pesquisar Consulta";
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.ajudaToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip2.Size = new System.Drawing.Size(1364, 25);
            this.menuStrip2.TabIndex = 31;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(68, 21);
            this.toolStripMenuItem1.Text = "Retormar";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ajudaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(53, 21);
            this.ajudaToolStripMenuItem.Text = "Ajuda";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox2.Controls.Add(this.txtGlicose);
            this.groupBox2.Controls.Add(this.txtSaturacao);
            this.groupBox2.Controls.Add(this.txtTemperatura);
            this.groupBox2.Controls.Add(this.txtPesoKg);
            this.groupBox2.Controls.Add(this.txtPressaoArterial);
            this.groupBox2.Controls.Add(this.txtHoraTriagem);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtDataAtend);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtRelatoPaciente);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtEspecialidade);
            this.groupBox2.Controls.Add(this.txtmedico);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.txtProntuario);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.txtDataNasc);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtNome);
            this.groupBox2.Controls.Add(this.btnSalvar);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(17, 378);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1326, 348);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            // 
            // txtHoraTriagem
            // 
            this.txtHoraTriagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoraTriagem.Location = new System.Drawing.Point(245, 130);
            this.txtHoraTriagem.Mask = "00:00";
            this.txtHoraTriagem.Name = "txtHoraTriagem";
            this.txtHoraTriagem.Size = new System.Drawing.Size(62, 24);
            this.txtHoraTriagem.TabIndex = 116;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Poor Richard", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label12.Location = new System.Drawing.Point(120, 131);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 22);
            this.label12.TabIndex = 115;
            this.label12.Text = "Hora Triagem";
            // 
            // txtDataAtend
            // 
            this.txtDataAtend.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataAtend.Location = new System.Drawing.Point(153, 73);
            this.txtDataAtend.Mask = "00/00/0000";
            this.txtDataAtend.Name = "txtDataAtend";
            this.txtDataAtend.Size = new System.Drawing.Size(101, 24);
            this.txtDataAtend.TabIndex = 114;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Poor Richard", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label11.Location = new System.Drawing.Point(19, 75);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(133, 22);
            this.label11.TabIndex = 113;
            this.label11.Text = "Data de Atend.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Poor Richard", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label10.Location = new System.Drawing.Point(23, 217);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 22);
            this.label10.TabIndex = 107;
            this.label10.Text = "Relato:";
            // 
            // txtRelatoPaciente
            // 
            this.txtRelatoPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRelatoPaciente.Location = new System.Drawing.Point(89, 217);
            this.txtRelatoPaciente.Name = "txtRelatoPaciente";
            this.txtRelatoPaciente.Size = new System.Drawing.Size(905, 107);
            this.txtRelatoPaciente.TabIndex = 106;
            this.txtRelatoPaciente.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Poor Richard", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label9.Location = new System.Drawing.Point(669, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 22);
            this.label9.TabIndex = 104;
            this.label9.Text = "O2 Sat.";
            // 
            // txtEspecialidade
            // 
            this.txtEspecialidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEspecialidade.FormattingEnabled = true;
            this.txtEspecialidade.Items.AddRange(new object[] {
            "CARDIOLOGIA",
            "CLÍNICO GERAL",
            "DERMATOLOGIA",
            "ENDOCRINOLOGIA",
            "GASTROLOGIA",
            "NEFROLOGIA",
            "NEUROLOGIA",
            "ORTOPEDIA",
            "OTORRINO",
            "PEDIATRIA",
            "PNEUMOLOGIA"});
            this.txtEspecialidade.Location = new System.Drawing.Point(807, 71);
            this.txtEspecialidade.Name = "txtEspecialidade";
            this.txtEspecialidade.Size = new System.Drawing.Size(157, 26);
            this.txtEspecialidade.TabIndex = 100;
            // 
            // txtmedico
            // 
            this.txtmedico.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmedico.Location = new System.Drawing.Point(358, 73);
            this.txtmedico.Name = "txtmedico";
            this.txtmedico.Size = new System.Drawing.Size(289, 24);
            this.txtmedico.TabIndex = 99;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Poor Richard", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label21.Location = new System.Drawing.Point(400, 126);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(76, 22);
            this.label21.TabIndex = 97;
            this.label21.Text = "Peso KG";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Poor Richard", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label20.Location = new System.Drawing.Point(148, 175);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(91, 22);
            this.label20.TabIndex = 94;
            this.label20.Text = "Glic. HGT";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Red;
            this.label27.Location = new System.Drawing.Point(184, 10);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(0, 25);
            this.label27.TabIndex = 92;
            // 
            // txtProntuario
            // 
            this.txtProntuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProntuario.Location = new System.Drawing.Point(639, 14);
            this.txtProntuario.Name = "txtProntuario";
            this.txtProntuario.Size = new System.Drawing.Size(112, 24);
            this.txtProntuario.TabIndex = 87;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Poor Richard", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label23.Location = new System.Drawing.Point(539, 14);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(95, 22);
            this.label23.TabIndex = 86;
            this.label23.Text = "Prontuario";
            // 
            // txtDataNasc
            // 
            this.txtDataNasc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataNasc.Location = new System.Drawing.Point(943, 15);
            this.txtDataNasc.Mask = "00/00/0000";
            this.txtDataNasc.Name = "txtDataNasc";
            this.txtDataNasc.Size = new System.Drawing.Size(101, 24);
            this.txtDataNasc.TabIndex = 83;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Poor Richard", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label4.Location = new System.Drawing.Point(655, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 22);
            this.label4.TabIndex = 66;
            this.label4.Text = "PA (0x0)";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poor Richard", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label2.Location = new System.Drawing.Point(678, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 22);
            this.label2.TabIndex = 63;
            this.label2.Text = "Especialidade";
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(101, 14);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(406, 24);
            this.txtNome.TabIndex = 61;
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(1135, 285);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(144, 39);
            this.btnSalvar.TabIndex = 49;
            this.btnSalvar.Text = "  SALVAR";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Poor Richard", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label8.Location = new System.Drawing.Point(393, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 22);
            this.label8.TabIndex = 26;
            this.label8.Text = "Temp. °C";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Poor Richard", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label7.Location = new System.Drawing.Point(822, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 22);
            this.label7.TabIndex = 25;
            this.label7.Text = "Data de Nasc.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Poor Richard", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label6.Location = new System.Drawing.Point(286, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 22);
            this.label6.TabIndex = 24;
            this.label6.Text = "Médico";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poor Richard", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label3.Location = new System.Drawing.Point(19, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 22);
            this.label3.TabIndex = 23;
            this.label3.Text = "Paciente";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Poor Richard", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label5.Location = new System.Drawing.Point(1172, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 41);
            this.label5.TabIndex = 22;
            this.label5.Text = "Triagem";
            // 
            // txtPressaoArterial
            // 
            this.txtPressaoArterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPressaoArterial.Location = new System.Drawing.Point(739, 124);
            this.txtPressaoArterial.Mask = "000X00";
            this.txtPressaoArterial.Name = "txtPressaoArterial";
            this.txtPressaoArterial.Size = new System.Drawing.Size(75, 24);
            this.txtPressaoArterial.TabIndex = 117;
            // 
            // txtPesoKg
            // 
            this.txtPesoKg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesoKg.Location = new System.Drawing.Point(478, 124);
            this.txtPesoKg.Mask = "000,000";
            this.txtPesoKg.Name = "txtPesoKg";
            this.txtPesoKg.Size = new System.Drawing.Size(75, 24);
            this.txtPesoKg.TabIndex = 118;
            // 
            // txtTemperatura
            // 
            this.txtTemperatura.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTemperatura.Location = new System.Drawing.Point(480, 172);
            this.txtTemperatura.Mask = "00,0°";
            this.txtTemperatura.Name = "txtTemperatura";
            this.txtTemperatura.Size = new System.Drawing.Size(75, 24);
            this.txtTemperatura.TabIndex = 119;
            // 
            // txtSaturacao
            // 
            this.txtSaturacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaturacao.Location = new System.Drawing.Point(740, 172);
            this.txtSaturacao.Mask = "00 %";
            this.txtSaturacao.Name = "txtSaturacao";
            this.txtSaturacao.Size = new System.Drawing.Size(75, 24);
            this.txtSaturacao.TabIndex = 120;
            // 
            // txtGlicose
            // 
            this.txtGlicose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGlicose.Location = new System.Drawing.Point(245, 172);
            this.txtGlicose.Mask = "000 mg/dl";
            this.txtGlicose.Name = "txtGlicose";
            this.txtGlicose.Size = new System.Drawing.Size(75, 24);
            this.txtGlicose.TabIndex = 121;
            // 
            // frmTriagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 762);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1364, 762);
            this.MinimumSize = new System.Drawing.Size(1364, 762);
            this.Name = "frmTriagem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTriagem";
            this.Load += new System.EventHandler(this.frmTriagem_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabeladeClientes)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNome1;
        private System.Windows.Forms.DataGridView tabeladeClientes;
        private System.Windows.Forms.Button btnBuscar1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtProntuario;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.MaskedTextBox txtDataNasc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox txtEspecialidade;
        private System.Windows.Forms.TextBox txtmedico;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox txtRelatoPaciente;
        private System.Windows.Forms.MaskedTextBox txtDataAtend;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox txtHoraTriagem;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker txtDataAtend2;
        private System.Windows.Forms.MaskedTextBox txtGlicose;
        private System.Windows.Forms.MaskedTextBox txtSaturacao;
        private System.Windows.Forms.MaskedTextBox txtTemperatura;
        private System.Windows.Forms.MaskedTextBox txtPesoKg;
        private System.Windows.Forms.MaskedTextBox txtPressaoArterial;
        private MySql.Data.MySqlClient.MySqlConnection mySqlConnection1;
    }
}