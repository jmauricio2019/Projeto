namespace ProjetoCrudPacientes
{
    partial class frmAgendar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgendar));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtHoraAtend = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDataAtend = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMae = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEspecialidade = new System.Windows.Forms.ComboBox();
            this.txtmedico = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtProntuario = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtDataNasc = new System.Windows.Forms.MaskedTextBox();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.checkBoxIncluirCadastro = new System.Windows.Forms.CheckBox();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.txtNome1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDataNasc1 = new System.Windows.Forms.MaskedTextBox();
            this.tabeladeClientes = new System.Windows.Forms.DataGridView();
            this.btnBuscar1 = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabeladeClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox2.Controls.Add(this.txtHoraAtend);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtDataAtend);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtMae);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtEspecialidade);
            this.groupBox2.Controls.Add(this.txtmedico);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.txtProntuario);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.txtDataNasc);
            this.groupBox2.Controls.Add(this.btnExcluir);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtNome);
            this.groupBox2.Controls.Add(this.checkBoxIncluirCadastro);
            this.groupBox2.Controls.Add(this.btnAtualizar);
            this.groupBox2.Controls.Add(this.btnSalvar);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(19, 376);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1326, 348);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            // 
            // txtHoraAtend
            // 
            this.txtHoraAtend.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoraAtend.Location = new System.Drawing.Point(357, 198);
            this.txtHoraAtend.Mask = "00:00";
            this.txtHoraAtend.Name = "txtHoraAtend";
            this.txtHoraAtend.Size = new System.Drawing.Size(62, 24);
            this.txtHoraAtend.TabIndex = 106;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Poor Richard", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label9.Location = new System.Drawing.Point(304, 200);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 22);
            this.label9.TabIndex = 105;
            this.label9.Text = "Hora";
            // 
            // txtDataAtend
            // 
            this.txtDataAtend.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataAtend.Location = new System.Drawing.Point(136, 198);
            this.txtDataAtend.Mask = "00/00/0000";
            this.txtDataAtend.Name = "txtDataAtend";
            this.txtDataAtend.Size = new System.Drawing.Size(101, 24);
            this.txtDataAtend.TabIndex = 104;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Poor Richard", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label8.Location = new System.Drawing.Point(10, 200);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 22);
            this.label8.TabIndex = 103;
            this.label8.Text = "Data do Aten.";
            // 
            // txtMae
            // 
            this.txtMae.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMae.Location = new System.Drawing.Point(340, 68);
            this.txtMae.Name = "txtMae";
            this.txtMae.Size = new System.Drawing.Size(359, 24);
            this.txtMae.TabIndex = 102;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Poor Richard", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label4.Location = new System.Drawing.Point(289, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 22);
            this.label4.TabIndex = 101;
            this.label4.Text = "Mãe";
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
            this.txtEspecialidade.Location = new System.Drawing.Point(674, 133);
            this.txtEspecialidade.Name = "txtEspecialidade";
            this.txtEspecialidade.Size = new System.Drawing.Size(157, 26);
            this.txtEspecialidade.TabIndex = 100;
            // 
            // txtmedico
            // 
            this.txtmedico.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmedico.Location = new System.Drawing.Point(82, 135);
            this.txtmedico.Name = "txtmedico";
            this.txtmedico.Size = new System.Drawing.Size(418, 24);
            this.txtmedico.TabIndex = 99;
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
            this.txtProntuario.Location = new System.Drawing.Point(809, 9);
            this.txtProntuario.Name = "txtProntuario";
            this.txtProntuario.Size = new System.Drawing.Size(112, 24);
            this.txtProntuario.TabIndex = 87;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Poor Richard", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label23.Location = new System.Drawing.Point(711, 11);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(95, 22);
            this.label23.TabIndex = 86;
            this.label23.Text = "Prontuario";
            // 
            // txtDataNasc
            // 
            this.txtDataNasc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataNasc.Location = new System.Drawing.Point(136, 69);
            this.txtDataNasc.Mask = "00/00/0000";
            this.txtDataNasc.Name = "txtDataNasc";
            this.txtDataNasc.Size = new System.Drawing.Size(101, 24);
            this.txtDataNasc.TabIndex = 83;
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.Red;
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluir.Location = new System.Drawing.Point(1141, 110);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(144, 37);
            this.btnExcluir.TabIndex = 77;
            this.btnExcluir.Text = "EXCLUIR";
            this.btnExcluir.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poor Richard", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label2.Location = new System.Drawing.Point(545, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 22);
            this.label2.TabIndex = 63;
            this.label2.Text = "Especialidade";
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(214, 14);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(406, 24);
            this.txtNome.TabIndex = 61;
            // 
            // checkBoxIncluirCadastro
            // 
            this.checkBoxIncluirCadastro.AutoSize = true;
            this.checkBoxIncluirCadastro.Font = new System.Drawing.Font("Poor Richard", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxIncluirCadastro.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.checkBoxIncluirCadastro.Location = new System.Drawing.Point(10, 11);
            this.checkBoxIncluirCadastro.Name = "checkBoxIncluirCadastro";
            this.checkBoxIncluirCadastro.Size = new System.Drawing.Size(69, 26);
            this.checkBoxIncluirCadastro.TabIndex = 59;
            this.checkBoxIncluirCadastro.Text = "Triar";
            this.checkBoxIncluirCadastro.UseVisualStyleBackColor = true;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.BackColor = System.Drawing.Color.Goldenrod;
            this.btnAtualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAtualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnAtualizar.Image")));
            this.btnAtualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAtualizar.Location = new System.Drawing.Point(1141, 166);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(144, 38);
            this.btnAtualizar.TabIndex = 58;
            this.btnAtualizar.Text = "  ATUALIZAR";
            this.btnAtualizar.UseVisualStyleBackColor = false;
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(1141, 226);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(144, 39);
            this.btnSalvar.TabIndex = 49;
            this.btnSalvar.Text = "  SALVAR";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Poor Richard", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label7.Location = new System.Drawing.Point(10, 71);
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
            this.label6.Location = new System.Drawing.Point(10, 136);
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
            this.label3.Location = new System.Drawing.Point(132, 14);
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
            this.label5.Location = new System.Drawing.Point(1092, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 41);
            this.label5.TabIndex = 22;
            this.label5.Text = "Agendamento";
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
            this.menuStrip2.TabIndex = 34;
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
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.txtNome1);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtDataNasc1);
            this.groupBox1.Controls.Add(this.tabeladeClientes);
            this.groupBox1.Controls.Add(this.btnBuscar1);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(17, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1327, 316);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
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
            this.comboBox2.Location = new System.Drawing.Point(457, 44);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(157, 26);
            this.comboBox2.TabIndex = 104;
            // 
            // txtNome1
            // 
            this.txtNome1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome1.Location = new System.Drawing.Point(84, 9);
            this.txtNome1.Name = "txtNome1";
            this.txtNome1.Size = new System.Drawing.Size(530, 24);
            this.txtNome1.TabIndex = 103;
            this.txtNome1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNome1_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Poor Richard", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label11.Location = new System.Drawing.Point(332, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(123, 22);
            this.label11.TabIndex = 102;
            this.label11.Text = "Especialidade";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Poor Richard", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label12.Location = new System.Drawing.Point(12, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 22);
            this.label12.TabIndex = 101;
            this.label12.Text = "Médico";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // txtDataNasc1
            // 
            this.txtDataNasc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataNasc1.Location = new System.Drawing.Point(147, 45);
            this.txtDataNasc1.Mask = "00/00/0000";
            this.txtDataNasc1.Name = "txtDataNasc1";
            this.txtDataNasc1.Size = new System.Drawing.Size(101, 24);
            this.txtDataNasc1.TabIndex = 65;
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
            // 
            // btnBuscar1
            // 
            this.btnBuscar1.BackColor = System.Drawing.Color.DarkMagenta;
            this.btnBuscar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBuscar1.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar1.Image")));
            this.btnBuscar1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar1.Location = new System.Drawing.Point(676, 4);
            this.btnBuscar1.Name = "btnBuscar1";
            this.btnBuscar1.Size = new System.Drawing.Size(116, 37);
            this.btnBuscar1.TabIndex = 49;
            this.btnBuscar1.Text = "     BUSCAR";
            this.btnBuscar1.UseVisualStyleBackColor = false;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poor Richard", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(1177, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 41);
            this.label1.TabIndex = 21;
            this.label1.Text = "Agenda";
            // 
            // frmAgendar
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
            this.Name = "frmAgendar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAgendar";
            this.Load += new System.EventHandler(this.frmAgendar_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabeladeClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox txtEspecialidade;
        private System.Windows.Forms.TextBox txtmedico;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtProntuario;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.MaskedTextBox txtDataNasc;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.CheckBox checkBoxIncluirCadastro;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox txtDataNasc1;
        private System.Windows.Forms.DataGridView tabeladeClientes;
        private System.Windows.Forms.Button btnBuscar1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtDataAtend;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMae;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox txtNome1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox txtHoraAtend;
        private System.Windows.Forms.Label label9;
    }
}