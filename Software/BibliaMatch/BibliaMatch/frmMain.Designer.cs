namespace BibliaMatch
{
  partial class frmMain
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
        this.components = new System.ComponentModel.Container();
        this.btnAbrirPuerto = new System.Windows.Forms.Button();
        this.btnReset = new System.Windows.Forms.Button();
        this.btnTiempo = new System.Windows.Forms.Button();
        this.btnCerrarPuerto = new System.Windows.Forms.Button();
        this.cbxPuertos = new System.Windows.Forms.ComboBox();
        this.lblCompetidorRojo = new System.Windows.Forms.Label();
        this.lblCompetidorAzul = new System.Windows.Forms.Label();
        this.btnBien = new System.Windows.Forms.Button();
        this.btnMal = new System.Windows.Forms.Button();
        this.btnPregunta = new System.Windows.Forms.Button();
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.label20 = new System.Windows.Forms.Label();
        this.gbxBotones = new System.Windows.Forms.GroupBox();
        this.btnJugador = new System.Windows.Forms.Button();
        this.timer1 = new System.Windows.Forms.Timer(this.components);
        this.panel4 = new System.Windows.Forms.Panel();
        this.lblNumeroResp = new System.Windows.Forms.Label();
        this.lblEquipo1 = new System.Windows.Forms.Label();
        this.lblPuntosE3 = new System.Windows.Forms.Label();
        this.lblPuntosE5 = new System.Windows.Forms.Label();
        this.lblEquipo5 = new System.Windows.Forms.Label();
        this.lblPuntosE6 = new System.Windows.Forms.Label();
        this.lblEquipo4 = new System.Windows.Forms.Label();
        this.lblPuntosE4 = new System.Windows.Forms.Label();
        this.lblPuntosE1 = new System.Windows.Forms.Label();
        this.lblEquipo3 = new System.Windows.Forms.Label();
        this.lblPuntosE2 = new System.Windows.Forms.Label();
        this.lblEquipo6 = new System.Windows.Forms.Label();
        this.lblEquipo2 = new System.Windows.Forms.Label();
        this.lblSig2 = new System.Windows.Forms.Label();
        this.lblSiguienteAzul2 = new System.Windows.Forms.Label();
        this.lblSiguienteAzul1 = new System.Windows.Forms.Label();
        this.lblSiguienteRojo2 = new System.Windows.Forms.Label();
        this.lblSiguienteRojo1 = new System.Windows.Forms.Label();
        this.lblSig1 = new System.Windows.Forms.Label();
        this.lblPregunta = new System.Windows.Forms.Label();
        this.lblTiempo = new System.Windows.Forms.Label();
        this.gbxBotones.SuspendLayout();
        this.panel4.SuspendLayout();
        this.SuspendLayout();
        // 
        // btnAbrirPuerto
        // 
        this.btnAbrirPuerto.Location = new System.Drawing.Point(12, 7);
        this.btnAbrirPuerto.Name = "btnAbrirPuerto";
        this.btnAbrirPuerto.Size = new System.Drawing.Size(75, 23);
        this.btnAbrirPuerto.TabIndex = 0;
        this.btnAbrirPuerto.Text = "Abrir Puerto";
        this.btnAbrirPuerto.UseVisualStyleBackColor = true;
        this.btnAbrirPuerto.Click += new System.EventHandler(this.btnAbrirPuerto_Click);
        // 
        // btnReset
        // 
        this.btnReset.Location = new System.Drawing.Point(100, 12);
        this.btnReset.Name = "btnReset";
        this.btnReset.Size = new System.Drawing.Size(73, 45);
        this.btnReset.TabIndex = 1;
        this.btnReset.Text = "Comenzar";
        this.btnReset.UseVisualStyleBackColor = true;
        this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
        // 
        // btnTiempo
        // 
        this.btnTiempo.Enabled = false;
        this.btnTiempo.Location = new System.Drawing.Point(307, 10);
        this.btnTiempo.Name = "btnTiempo";
        this.btnTiempo.Size = new System.Drawing.Size(58, 45);
        this.btnTiempo.TabIndex = 2;
        this.btnTiempo.Text = "Tiempo";
        this.btnTiempo.UseVisualStyleBackColor = true;
        this.btnTiempo.Click += new System.EventHandler(this.btnPulsador_Click);
        // 
        // btnCerrarPuerto
        // 
        this.btnCerrarPuerto.Enabled = false;
        this.btnCerrarPuerto.Location = new System.Drawing.Point(12, 36);
        this.btnCerrarPuerto.Name = "btnCerrarPuerto";
        this.btnCerrarPuerto.Size = new System.Drawing.Size(147, 23);
        this.btnCerrarPuerto.TabIndex = 7;
        this.btnCerrarPuerto.Text = "Cerrar Puerto";
        this.btnCerrarPuerto.UseVisualStyleBackColor = true;
        this.btnCerrarPuerto.Click += new System.EventHandler(this.btnCerrarPuerto_Click);
        // 
        // cbxPuertos
        // 
        this.cbxPuertos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cbxPuertos.FormattingEnabled = true;
        this.cbxPuertos.Location = new System.Drawing.Point(94, 9);
        this.cbxPuertos.Name = "cbxPuertos";
        this.cbxPuertos.Size = new System.Drawing.Size(65, 21);
        this.cbxPuertos.TabIndex = 8;
        // 
        // lblCompetidorRojo
        // 
        this.lblCompetidorRojo.Anchor = System.Windows.Forms.AnchorStyles.Top;
        this.lblCompetidorRojo.BackColor = System.Drawing.Color.Transparent;
        this.lblCompetidorRojo.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblCompetidorRojo.ForeColor = System.Drawing.Color.Red;
        this.lblCompetidorRojo.Location = new System.Drawing.Point(62, 142);
        this.lblCompetidorRojo.Name = "lblCompetidorRojo";
        this.lblCompetidorRojo.Size = new System.Drawing.Size(189, 82);
        this.lblCompetidorRojo.TabIndex = 26;
        this.lblCompetidorRojo.Text = "Piedra angular del Este";
        this.lblCompetidorRojo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblCompetidorAzul
        // 
        this.lblCompetidorAzul.Anchor = System.Windows.Forms.AnchorStyles.Top;
        this.lblCompetidorAzul.BackColor = System.Drawing.Color.Transparent;
        this.lblCompetidorAzul.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblCompetidorAzul.ForeColor = System.Drawing.Color.Blue;
        this.lblCompetidorAzul.Location = new System.Drawing.Point(549, 142);
        this.lblCompetidorAzul.Name = "lblCompetidorAzul";
        this.lblCompetidorAzul.Size = new System.Drawing.Size(191, 82);
        this.lblCompetidorAzul.TabIndex = 27;
        this.lblCompetidorAzul.Text = "Los Bienaventurados";
        this.lblCompetidorAzul.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // btnBien
        // 
        this.btnBien.Enabled = false;
        this.btnBien.Location = new System.Drawing.Point(419, 10);
        this.btnBien.Name = "btnBien";
        this.btnBien.Size = new System.Drawing.Size(58, 45);
        this.btnBien.TabIndex = 30;
        this.btnBien.Text = "Bien";
        this.btnBien.UseVisualStyleBackColor = true;
        this.btnBien.Click += new System.EventHandler(this.button1_Click);
        // 
        // btnMal
        // 
        this.btnMal.Enabled = false;
        this.btnMal.Location = new System.Drawing.Point(483, 10);
        this.btnMal.Name = "btnMal";
        this.btnMal.Size = new System.Drawing.Size(58, 45);
        this.btnMal.TabIndex = 31;
        this.btnMal.Text = "Mal";
        this.btnMal.UseVisualStyleBackColor = true;
        this.btnMal.Click += new System.EventHandler(this.btnMal_Click);
        // 
        // btnPregunta
        // 
        this.btnPregunta.Enabled = false;
        this.btnPregunta.Location = new System.Drawing.Point(243, 10);
        this.btnPregunta.Name = "btnPregunta";
        this.btnPregunta.Size = new System.Drawing.Size(58, 45);
        this.btnPregunta.TabIndex = 32;
        this.btnPregunta.Text = "Nueva Pregunta";
        this.btnPregunta.UseVisualStyleBackColor = true;
        this.btnPregunta.Click += new System.EventHandler(this.button3_Click);
        // 
        // textBox1
        // 
        this.textBox1.Location = new System.Drawing.Point(45, 36);
        this.textBox1.MaxLength = 2;
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(25, 20);
        this.textBox1.TabIndex = 33;
        this.textBox1.Text = "10";
        this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNúmeros);
        // 
        // label20
        // 
        this.label20.AutoSize = true;
        this.label20.Location = new System.Drawing.Point(17, 15);
        this.label20.Name = "label20";
        this.label20.Size = new System.Drawing.Size(77, 13);
        this.label20.TabIndex = 34;
        this.label20.Text = "Timeout (seg.):";
        // 
        // gbxBotones
        // 
        this.gbxBotones.Controls.Add(this.btnJugador);
        this.gbxBotones.Controls.Add(this.label20);
        this.gbxBotones.Controls.Add(this.textBox1);
        this.gbxBotones.Controls.Add(this.btnPregunta);
        this.gbxBotones.Controls.Add(this.btnMal);
        this.gbxBotones.Controls.Add(this.btnBien);
        this.gbxBotones.Controls.Add(this.btnReset);
        this.gbxBotones.Controls.Add(this.btnTiempo);
        this.gbxBotones.Enabled = false;
        this.gbxBotones.Location = new System.Drawing.Point(184, 3);
        this.gbxBotones.Name = "gbxBotones";
        this.gbxBotones.Size = new System.Drawing.Size(561, 57);
        this.gbxBotones.TabIndex = 35;
        this.gbxBotones.TabStop = false;
        // 
        // btnJugador
        // 
        this.btnJugador.Enabled = false;
        this.btnJugador.Location = new System.Drawing.Point(179, 10);
        this.btnJugador.Name = "btnJugador";
        this.btnJugador.Size = new System.Drawing.Size(58, 45);
        this.btnJugador.TabIndex = 35;
        this.btnJugador.Text = "Jugador";
        this.btnJugador.UseVisualStyleBackColor = true;
        this.btnJugador.Click += new System.EventHandler(this.btnLoadPlayer_Click);
        // 
        // timer1
        // 
        this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
        // 
        // panel4
        // 
        this.panel4.BackColor = System.Drawing.Color.Transparent;
        this.panel4.Controls.Add(this.lblNumeroResp);
        this.panel4.Controls.Add(this.gbxBotones);
        this.panel4.Controls.Add(this.cbxPuertos);
        this.panel4.Controls.Add(this.btnCerrarPuerto);
        this.panel4.Controls.Add(this.btnAbrirPuerto);
        this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.panel4.Location = new System.Drawing.Point(0, 510);
        this.panel4.Name = "panel4";
        this.panel4.Size = new System.Drawing.Size(792, 63);
        this.panel4.TabIndex = 42;
        // 
        // lblNumeroResp
        // 
        this.lblNumeroResp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.lblNumeroResp.AutoSize = true;
        this.lblNumeroResp.ForeColor = System.Drawing.Color.Gray;
        this.lblNumeroResp.Location = new System.Drawing.Point(759, 46);
        this.lblNumeroResp.Name = "lblNumeroResp";
        this.lblNumeroResp.Size = new System.Drawing.Size(19, 13);
        this.lblNumeroResp.TabIndex = 36;
        this.lblNumeroResp.Text = "00";
        this.lblNumeroResp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblEquipo1
        // 
        this.lblEquipo1.BackColor = System.Drawing.Color.Transparent;
        this.lblEquipo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblEquipo1.Location = new System.Drawing.Point(0, 0);
        this.lblEquipo1.Name = "lblEquipo1";
        this.lblEquipo1.Size = new System.Drawing.Size(130, 95);
        this.lblEquipo1.TabIndex = 45;
        this.lblEquipo1.Text = "Guerreros del Señor";
        this.lblEquipo1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.lblEquipo1.Click += new System.EventHandler(this.lblEquipo1_Click);
        // 
        // lblPuntosE3
        // 
        this.lblPuntosE3.BackColor = System.Drawing.Color.Transparent;
        this.lblPuntosE3.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblPuntosE3.ForeColor = System.Drawing.Color.White;
        this.lblPuntosE3.Location = new System.Drawing.Point(283, 94);
        this.lblPuntosE3.Name = "lblPuntosE3";
        this.lblPuntosE3.Size = new System.Drawing.Size(92, 28);
        this.lblPuntosE3.TabIndex = 55;
        this.lblPuntosE3.Text = "1000";
        this.lblPuntosE3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblPuntosE5
        // 
        this.lblPuntosE5.BackColor = System.Drawing.Color.Transparent;
        this.lblPuntosE5.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblPuntosE5.ForeColor = System.Drawing.Color.White;
        this.lblPuntosE5.Location = new System.Drawing.Point(547, 94);
        this.lblPuntosE5.Name = "lblPuntosE5";
        this.lblPuntosE5.Size = new System.Drawing.Size(92, 28);
        this.lblPuntosE5.TabIndex = 53;
        this.lblPuntosE5.Text = "1000";
        this.lblPuntosE5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblEquipo5
        // 
        this.lblEquipo5.BackColor = System.Drawing.Color.Transparent;
        this.lblEquipo5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblEquipo5.Location = new System.Drawing.Point(530, 0);
        this.lblEquipo5.Name = "lblEquipo5";
        this.lblEquipo5.Size = new System.Drawing.Size(130, 95);
        this.lblEquipo5.TabIndex = 47;
        this.lblEquipo5.Text = "Los Bienaventurados";
        this.lblEquipo5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblPuntosE6
        // 
        this.lblPuntosE6.BackColor = System.Drawing.Color.Transparent;
        this.lblPuntosE6.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblPuntosE6.ForeColor = System.Drawing.Color.White;
        this.lblPuntosE6.Location = new System.Drawing.Point(677, 94);
        this.lblPuntosE6.Name = "lblPuntosE6";
        this.lblPuntosE6.Size = new System.Drawing.Size(92, 28);
        this.lblPuntosE6.TabIndex = 52;
        this.lblPuntosE6.Text = "1000";
        this.lblPuntosE6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblEquipo4
        // 
        this.lblEquipo4.BackColor = System.Drawing.Color.Transparent;
        this.lblEquipo4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblEquipo4.Location = new System.Drawing.Point(398, 0);
        this.lblEquipo4.Name = "lblEquipo4";
        this.lblEquipo4.Size = new System.Drawing.Size(130, 95);
        this.lblEquipo4.TabIndex = 48;
        this.lblEquipo4.Text = "Los Guerreros de Dios";
        this.lblEquipo4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblPuntosE4
        // 
        this.lblPuntosE4.BackColor = System.Drawing.Color.Transparent;
        this.lblPuntosE4.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblPuntosE4.ForeColor = System.Drawing.Color.White;
        this.lblPuntosE4.Location = new System.Drawing.Point(418, 94);
        this.lblPuntosE4.Name = "lblPuntosE4";
        this.lblPuntosE4.Size = new System.Drawing.Size(92, 28);
        this.lblPuntosE4.TabIndex = 54;
        this.lblPuntosE4.Text = "1000";
        this.lblPuntosE4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblPuntosE1
        // 
        this.lblPuntosE1.BackColor = System.Drawing.Color.Transparent;
        this.lblPuntosE1.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblPuntosE1.ForeColor = System.Drawing.Color.White;
        this.lblPuntosE1.Location = new System.Drawing.Point(17, 94);
        this.lblPuntosE1.Name = "lblPuntosE1";
        this.lblPuntosE1.Size = new System.Drawing.Size(92, 28);
        this.lblPuntosE1.TabIndex = 51;
        this.lblPuntosE1.Text = "1000";
        this.lblPuntosE1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.lblPuntosE1.Click += new System.EventHandler(this.lblPuntosE1_Click_1);
        // 
        // lblEquipo3
        // 
        this.lblEquipo3.BackColor = System.Drawing.Color.Transparent;
        this.lblEquipo3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblEquipo3.Location = new System.Drawing.Point(266, 0);
        this.lblEquipo3.Name = "lblEquipo3";
        this.lblEquipo3.Size = new System.Drawing.Size(130, 95);
        this.lblEquipo3.TabIndex = 49;
        this.lblEquipo3.Text = "Infantería del León";
        this.lblEquipo3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.lblEquipo3.Click += new System.EventHandler(this.lblEquipo3_Click_1);
        // 
        // lblPuntosE2
        // 
        this.lblPuntosE2.BackColor = System.Drawing.Color.Transparent;
        this.lblPuntosE2.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblPuntosE2.ForeColor = System.Drawing.Color.White;
        this.lblPuntosE2.Location = new System.Drawing.Point(148, 94);
        this.lblPuntosE2.Name = "lblPuntosE2";
        this.lblPuntosE2.Size = new System.Drawing.Size(92, 28);
        this.lblPuntosE2.TabIndex = 56;
        this.lblPuntosE2.Text = "1000";
        this.lblPuntosE2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblEquipo6
        // 
        this.lblEquipo6.BackColor = System.Drawing.Color.Transparent;
        this.lblEquipo6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblEquipo6.Location = new System.Drawing.Point(662, 0);
        this.lblEquipo6.Name = "lblEquipo6";
        this.lblEquipo6.Size = new System.Drawing.Size(130, 95);
        this.lblEquipo6.TabIndex = 46;
        this.lblEquipo6.Text = "Piedra angular del Este";
        this.lblEquipo6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblEquipo2
        // 
        this.lblEquipo2.BackColor = System.Drawing.Color.Transparent;
        this.lblEquipo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblEquipo2.Location = new System.Drawing.Point(133, 0);
        this.lblEquipo2.Name = "lblEquipo2";
        this.lblEquipo2.Size = new System.Drawing.Size(130, 95);
        this.lblEquipo2.TabIndex = 50;
        this.lblEquipo2.Text = "Portales del Cielo";
        this.lblEquipo2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.lblEquipo2.Click += new System.EventHandler(this.lblEquipo2_Click);
        // 
        // lblSig2
        // 
        this.lblSig2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.lblSig2.AutoSize = true;
        this.lblSig2.BackColor = System.Drawing.Color.Transparent;
        this.lblSig2.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblSig2.ForeColor = System.Drawing.Color.White;
        this.lblSig2.Location = new System.Drawing.Point(654, 304);
        this.lblSig2.Name = "lblSig2";
        this.lblSig2.Size = new System.Drawing.Size(81, 20);
        this.lblSig2.TabIndex = 59;
        this.lblSig2.Text = "Siguientes:";
        this.lblSig2.Click += new System.EventHandler(this.lblSig2_Click);
        // 
        // lblSiguienteAzul2
        // 
        this.lblSiguienteAzul2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.lblSiguienteAzul2.BackColor = System.Drawing.Color.Transparent;
        this.lblSiguienteAzul2.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblSiguienteAzul2.ForeColor = System.Drawing.Color.RoyalBlue;
        this.lblSiguienteAzul2.Location = new System.Drawing.Point(652, 397);
        this.lblSiguienteAzul2.Name = "lblSiguienteAzul2";
        this.lblSiguienteAzul2.Size = new System.Drawing.Size(128, 73);
        this.lblSiguienteAzul2.TabIndex = 58;
        this.lblSiguienteAzul2.Text = "Portales del Cielo";
        this.lblSiguienteAzul2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblSiguienteAzul1
        // 
        this.lblSiguienteAzul1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.lblSiguienteAzul1.BackColor = System.Drawing.Color.Transparent;
        this.lblSiguienteAzul1.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblSiguienteAzul1.ForeColor = System.Drawing.Color.RoyalBlue;
        this.lblSiguienteAzul1.Location = new System.Drawing.Point(648, 329);
        this.lblSiguienteAzul1.Name = "lblSiguienteAzul1";
        this.lblSiguienteAzul1.Size = new System.Drawing.Size(132, 73);
        this.lblSiguienteAzul1.TabIndex = 57;
        this.lblSiguienteAzul1.Text = "Los Guerreros de Dios";
        this.lblSiguienteAzul1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblSiguienteRojo2
        // 
        this.lblSiguienteRojo2.BackColor = System.Drawing.Color.Transparent;
        this.lblSiguienteRojo2.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblSiguienteRojo2.ForeColor = System.Drawing.Color.IndianRed;
        this.lblSiguienteRojo2.Location = new System.Drawing.Point(27, 402);
        this.lblSiguienteRojo2.Name = "lblSiguienteRojo2";
        this.lblSiguienteRojo2.Size = new System.Drawing.Size(126, 73);
        this.lblSiguienteRojo2.TabIndex = 62;
        this.lblSiguienteRojo2.Text = "Guerreros del Señor";
        this.lblSiguienteRojo2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblSiguienteRojo1
        // 
        this.lblSiguienteRojo1.BackColor = System.Drawing.Color.Transparent;
        this.lblSiguienteRojo1.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblSiguienteRojo1.ForeColor = System.Drawing.Color.IndianRed;
        this.lblSiguienteRojo1.Location = new System.Drawing.Point(29, 329);
        this.lblSiguienteRojo1.Name = "lblSiguienteRojo1";
        this.lblSiguienteRojo1.Size = new System.Drawing.Size(124, 73);
        this.lblSiguienteRojo1.TabIndex = 61;
        this.lblSiguienteRojo1.Text = "Infantería del León";
        this.lblSiguienteRojo1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblSig1
        // 
        this.lblSig1.AutoSize = true;
        this.lblSig1.BackColor = System.Drawing.Color.Transparent;
        this.lblSig1.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblSig1.ForeColor = System.Drawing.Color.White;
        this.lblSig1.Location = new System.Drawing.Point(67, 307);
        this.lblSig1.Name = "lblSig1";
        this.lblSig1.Size = new System.Drawing.Size(81, 20);
        this.lblSig1.TabIndex = 60;
        this.lblSig1.Text = "Siguientes:";
        // 
        // lblPregunta
        // 
        this.lblPregunta.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.lblPregunta.BackColor = System.Drawing.Color.White;
        this.lblPregunta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblPregunta.Location = new System.Drawing.Point(159, 236);
        this.lblPregunta.Name = "lblPregunta";
        this.lblPregunta.Size = new System.Drawing.Size(480, 251);
        this.lblPregunta.TabIndex = 63;
        this.lblPregunta.Text = "¿Cual es el último libro del Nuevo Testamento?";
        this.lblPregunta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.lblPregunta.Click += new System.EventHandler(this.lblPregunta_Click);
        // 
        // lblTiempo
        // 
        this.lblTiempo.Anchor = System.Windows.Forms.AnchorStyles.Top;
        this.lblTiempo.BackColor = System.Drawing.Color.Transparent;
        this.lblTiempo.Font = new System.Drawing.Font("Impact", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblTiempo.Location = new System.Drawing.Point(244, 158);
        this.lblTiempo.Name = "lblTiempo";
        this.lblTiempo.Size = new System.Drawing.Size(309, 55);
        this.lblTiempo.TabIndex = 64;
        this.lblTiempo.Text = "Tiempo";
        this.lblTiempo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.lblTiempo.Click += new System.EventHandler(this.lblTiempo_Click_1);
        // 
        // frmMain
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.SystemColors.Control;
        this.BackgroundImage = global::BibliaMatch.Properties.Resources.Fondo;
        this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.ClientSize = new System.Drawing.Size(792, 573);
        this.Controls.Add(this.lblTiempo);
        this.Controls.Add(this.lblPregunta);
        this.Controls.Add(this.lblSiguienteRojo2);
        this.Controls.Add(this.lblSiguienteRojo1);
        this.Controls.Add(this.lblSig1);
        this.Controls.Add(this.lblSig2);
        this.Controls.Add(this.lblSiguienteAzul2);
        this.Controls.Add(this.lblSiguienteAzul1);
        this.Controls.Add(this.lblEquipo1);
        this.Controls.Add(this.lblPuntosE3);
        this.Controls.Add(this.lblPuntosE5);
        this.Controls.Add(this.lblEquipo5);
        this.Controls.Add(this.lblPuntosE6);
        this.Controls.Add(this.lblEquipo4);
        this.Controls.Add(this.lblPuntosE4);
        this.Controls.Add(this.lblPuntosE1);
        this.Controls.Add(this.lblEquipo3);
        this.Controls.Add(this.lblPuntosE2);
        this.Controls.Add(this.lblEquipo6);
        this.Controls.Add(this.lblEquipo2);
        this.Controls.Add(this.panel4);
        this.Controls.Add(this.lblCompetidorAzul);
        this.Controls.Add(this.lblCompetidorRojo);
        this.Name = "frmMain";
        this.ShowIcon = false;
        this.Text = "         ...--- BIBLIA MATCH ---...";
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
        this.Load += new System.EventHandler(this.Form1_Load);
        this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmMain_KeyPress);
        this.gbxBotones.ResumeLayout(false);
        this.gbxBotones.PerformLayout();
        this.panel4.ResumeLayout(false);
        this.panel4.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnAbrirPuerto;
    private System.Windows.Forms.Button btnReset;
    private System.Windows.Forms.Button btnTiempo;
    private System.Windows.Forms.Button btnCerrarPuerto;
    private System.Windows.Forms.ComboBox cbxPuertos;
    private System.Windows.Forms.Label lblCompetidorRojo;
    private System.Windows.Forms.Label lblCompetidorAzul;
    private System.Windows.Forms.Button btnBien;
    private System.Windows.Forms.Button btnMal;
    private System.Windows.Forms.Button btnPregunta;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label20;
    private System.Windows.Forms.GroupBox gbxBotones;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.Label lblNumeroResp;
    private System.Windows.Forms.Button btnJugador;
    private System.Windows.Forms.Label lblEquipo1;
    private System.Windows.Forms.Label lblPuntosE3;
    private System.Windows.Forms.Label lblPuntosE5;
    private System.Windows.Forms.Label lblEquipo5;
    private System.Windows.Forms.Label lblPuntosE6;
    private System.Windows.Forms.Label lblEquipo4;
    private System.Windows.Forms.Label lblPuntosE4;
    private System.Windows.Forms.Label lblPuntosE1;
    private System.Windows.Forms.Label lblEquipo3;
    private System.Windows.Forms.Label lblPuntosE2;
    private System.Windows.Forms.Label lblEquipo6;
    private System.Windows.Forms.Label lblEquipo2;
    private System.Windows.Forms.Label lblSig2;
    private System.Windows.Forms.Label lblSiguienteAzul2;
    private System.Windows.Forms.Label lblSiguienteAzul1;
    private System.Windows.Forms.Label lblSiguienteRojo2;
    private System.Windows.Forms.Label lblSiguienteRojo1;
    private System.Windows.Forms.Label lblSig1;
    private System.Windows.Forms.Label lblPregunta;
    private System.Windows.Forms.Label lblTiempo;
  }
}

