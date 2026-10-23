namespace AgentFrameworkApp.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Panel pnlAppHeader;
    private System.Windows.Forms.Label lblAppTitle;
    private System.Windows.Forms.Label lblAppSubtitle;
    private System.Windows.Forms.SplitContainer splitContenedor;
    private System.Windows.Forms.Panel pnlSidebar;
    private System.Windows.Forms.Panel pnlChatContainer;
    private System.Windows.Forms.Label _tituloConfiguracion;
    private System.Windows.Forms.Label _ayudaConfiguracion;
    private System.Windows.Forms.Label _explicacionFlujo;
    private System.Windows.Forms.LinkLabel _opcionesAvanzadas;
    private System.Windows.Forms.Label _tituloResultados;
    private System.Windows.Forms.Label _ayudaResultados;
    private System.Windows.Forms.Label lblModelo;
    private System.Windows.Forms.Label lblProblema;
    private System.Windows.Forms.Label lblInstrucciones;
    private System.Windows.Forms.Label lblConsulta;
    private System.Windows.Forms.ComboBox cbModelos;
    private System.Windows.Forms.TextBox txtProblema;
    private System.Windows.Forms.TextBox txtInstrucciones;
    private System.Windows.Forms.TextBox txtConsulta;
    private System.Windows.Forms.Button btnCrearAgente;
    private System.Windows.Forms.Button btnVerOperacionesJev;
    private System.Windows.Forms.Button btnEnviar;
    private System.Windows.Forms.Button btnNuevaSesion;
    private System.Windows.Forms.Label lblEstadoConexion;
    private System.Windows.Forms.RichTextBox rtbConversacion;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatus;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        pnlAppHeader = new Panel();
        lblAppTitle = new Label();
        lblAppSubtitle = new Label();
        splitContenedor = new SplitContainer();
        pnlSidebar = new Panel();
        _tituloConfiguracion = new Label();
        _ayudaConfiguracion = new Label();
        lblModelo = new Label();
        cbModelos = new ComboBox();
        _explicacionFlujo = new Label();
        btnCrearAgente = new Button();
        _opcionesAvanzadas = new LinkLabel();
        lblProblema = new Label();
        txtProblema = new TextBox();
        lblInstrucciones = new Label();
        txtInstrucciones = new TextBox();
        btnVerOperacionesJev = new Button();
        lblEstadoConexion = new Label();
        pnlChatContainer = new Panel();
        _tituloResultados = new Label();
        _ayudaResultados = new Label();
        rtbConversacion = new RichTextBox();
        lblConsulta = new Label();
        txtConsulta = new TextBox();
        btnNuevaSesion = new Button();
        btnEnviar = new Button();
        statusStrip = new StatusStrip();
        toolStripStatus = new ToolStripStatusLabel();
        pnlAppHeader.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContenedor).BeginInit();
        splitContenedor.Panel1.SuspendLayout();
        splitContenedor.Panel2.SuspendLayout();
        splitContenedor.SuspendLayout();
        pnlSidebar.SuspendLayout();
        pnlChatContainer.SuspendLayout();
        statusStrip.SuspendLayout();
        SuspendLayout();
        // 
        // pnlAppHeader
        // 
        pnlAppHeader.BackColor = Color.White;
        pnlAppHeader.Controls.Add(lblAppTitle);
        pnlAppHeader.Controls.Add(lblAppSubtitle);
        pnlAppHeader.Dock = DockStyle.Top;
        pnlAppHeader.Location = new Point(0, 0);
        pnlAppHeader.Name = "pnlAppHeader";
        pnlAppHeader.Size = new Size(1225, 76);
        pnlAppHeader.TabIndex = 0;
        // 
        // lblAppTitle
        // 
        lblAppTitle.AutoSize = true;
        lblAppTitle.Font = new Font("Segoe UI Semibold", 19F, FontStyle.Bold);
        lblAppTitle.ForeColor = Color.FromArgb(35, 46, 42);
        lblAppTitle.Location = new Point(517, 9);
        lblAppTitle.Name = "lblAppTitle";
        lblAppTitle.Size = new Size(52, 36);
        lblAppTitle.TabIndex = 0;
        lblAppTitle.Text = "Jev";
        // 
        // lblAppSubtitle
        // 
        lblAppSubtitle.AutoSize = true;
        lblAppSubtitle.Font = new Font("Segoe UI", 9.5F);
        lblAppSubtitle.ForeColor = Color.FromArgb(99, 111, 105);
        lblAppSubtitle.Location = new Point(421, 45);
        lblAppSubtitle.Name = "lblAppSubtitle";
        lblAppSubtitle.Size = new Size(254, 17);
        lblAppSubtitle.TabIndex = 1;
        lblAppSubtitle.Text = "Analiza correos sospechosos con claridad";
        // 
        // splitContenedor
        // 
        splitContenedor.BackColor = Color.FromArgb(215, 223, 217);
        splitContenedor.Dock = DockStyle.Fill;
        splitContenedor.FixedPanel = FixedPanel.Panel1;
        splitContenedor.Location = new Point(0, 76);
        splitContenedor.Name = "splitContenedor";
        // 
        // splitContenedor.Panel1
        // 
        splitContenedor.Panel1.Controls.Add(pnlSidebar);
        // 
        // splitContenedor.Panel2
        // 
        splitContenedor.Panel2.Controls.Add(pnlChatContainer);
        splitContenedor.Size = new Size(1225, 761);
        splitContenedor.SplitterDistance = 340;
        splitContenedor.SplitterWidth = 1;
        splitContenedor.TabIndex = 1;
        // 
        // pnlSidebar
        // 
        pnlSidebar.AutoScroll = true;
        pnlSidebar.BackColor = Color.White;
        pnlSidebar.Controls.Add(_tituloConfiguracion);
        pnlSidebar.Controls.Add(_ayudaConfiguracion);
        pnlSidebar.Controls.Add(lblModelo);
        pnlSidebar.Controls.Add(cbModelos);
        pnlSidebar.Controls.Add(_explicacionFlujo);
        pnlSidebar.Controls.Add(btnCrearAgente);
        pnlSidebar.Controls.Add(_opcionesAvanzadas);
        pnlSidebar.Controls.Add(lblProblema);
        pnlSidebar.Controls.Add(txtProblema);
        pnlSidebar.Controls.Add(lblInstrucciones);
        pnlSidebar.Controls.Add(txtInstrucciones);
        pnlSidebar.Controls.Add(btnVerOperacionesJev);
        pnlSidebar.Controls.Add(lblEstadoConexion);
        pnlSidebar.Dock = DockStyle.Fill;
        pnlSidebar.Location = new Point(0, 0);
        pnlSidebar.Name = "pnlSidebar";
        pnlSidebar.Size = new Size(340, 761);
        pnlSidebar.TabIndex = 0;
        // 
        // _tituloConfiguracion
        // 
        _tituloConfiguracion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        _tituloConfiguracion.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
        _tituloConfiguracion.ForeColor = Color.FromArgb(35, 46, 42);
        _tituloConfiguracion.Location = new Point(24, 23);
        _tituloConfiguracion.Name = "_tituloConfiguracion";
        _tituloConfiguracion.Size = new Size(292, 32);
        _tituloConfiguracion.TabIndex = 0;
        _tituloConfiguracion.Text = "Configuración";
        // 
        // _ayudaConfiguracion
        // 
        _ayudaConfiguracion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        _ayudaConfiguracion.Font = new Font("Segoe UI", 9.5F);
        _ayudaConfiguracion.ForeColor = Color.FromArgb(99, 111, 105);
        _ayudaConfiguracion.Location = new Point(24, 58);
        _ayudaConfiguracion.Name = "_ayudaConfiguracion";
        _ayudaConfiguracion.Size = new Size(292, 42);
        _ayudaConfiguracion.TabIndex = 1;
        _ayudaConfiguracion.Text = "Jev analiza cada correo y estima su riesgo de phishing.";
        // 
        // lblModelo
        // 
        lblModelo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        lblModelo.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        lblModelo.ForeColor = Color.FromArgb(35, 46, 42);
        lblModelo.Location = new Point(24, 123);
        lblModelo.Name = "lblModelo";
        lblModelo.Size = new Size(292, 21);
        lblModelo.TabIndex = 2;
        lblModelo.Text = "Modelo Jev";
        // 
        // cbModelos
        // 
        cbModelos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        cbModelos.BackColor = Color.White;
        cbModelos.DropDownStyle = ComboBoxStyle.DropDownList;
        cbModelos.FlatStyle = FlatStyle.Flat;
        cbModelos.Font = new Font("Segoe UI", 10F);
        cbModelos.ForeColor = Color.FromArgb(35, 46, 42);
        cbModelos.FormattingEnabled = true;
        cbModelos.Items.AddRange(new object[] { "jev-1.13-free" });
        cbModelos.SelectedIndex = 0;
        cbModelos.Location = new Point(24, 150);
        cbModelos.Name = "cbModelos";
        cbModelos.Size = new Size(292, 25);
        cbModelos.TabIndex = 3;
        // 
        // _explicacionFlujo
        // 
        _explicacionFlujo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        _explicacionFlujo.Font = new Font("Segoe UI", 9.5F);
        _explicacionFlujo.ForeColor = Color.FromArgb(99, 111, 105);
        _explicacionFlujo.Location = new Point(24, 202);
        _explicacionFlujo.Name = "_explicacionFlujo";
        _explicacionFlujo.Size = new Size(292, 62);
        _explicacionFlujo.TabIndex = 4;
        _explicacionFlujo.Text = "Jev combina señales locales del correo con una decisión de riesgo estructurada.";
        // 
        // btnCrearAgente
        // 
        btnCrearAgente.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        btnCrearAgente.BackColor = Color.FromArgb(39, 104, 85);
        btnCrearAgente.Cursor = Cursors.Hand;
        btnCrearAgente.FlatAppearance.BorderSize = 0;
        btnCrearAgente.FlatAppearance.MouseDownBackColor = Color.FromArgb(24, 70, 56);
        btnCrearAgente.FlatAppearance.MouseOverBackColor = Color.FromArgb(31, 88, 71);
        btnCrearAgente.FlatStyle = FlatStyle.Flat;
        btnCrearAgente.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        btnCrearAgente.ForeColor = Color.White;
        btnCrearAgente.Location = new Point(24, 284);
        btnCrearAgente.Name = "btnCrearAgente";
        btnCrearAgente.Size = new Size(292, 44);
        btnCrearAgente.TabIndex = 5;
        btnCrearAgente.Text = "Preparar análisis";
        btnCrearAgente.UseVisualStyleBackColor = false;
        btnCrearAgente.Click += btnCrearAgente_Click;
        // 
        // _opcionesAvanzadas
        // 
        _opcionesAvanzadas.ActiveLinkColor = Color.FromArgb(25, 77, 62);
        _opcionesAvanzadas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        _opcionesAvanzadas.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        _opcionesAvanzadas.LinkBehavior = LinkBehavior.HoverUnderline;
        _opcionesAvanzadas.LinkColor = Color.FromArgb(39, 104, 85);
        _opcionesAvanzadas.Location = new Point(24, 336);
        _opcionesAvanzadas.Name = "_opcionesAvanzadas";
        _opcionesAvanzadas.Size = new Size(292, 28);
        _opcionesAvanzadas.TabIndex = 6;
        _opcionesAvanzadas.TabStop = true;
        _opcionesAvanzadas.Text = "Mostrar opciones avanzadas";
        _opcionesAvanzadas.VisitedLinkColor = Color.FromArgb(39, 104, 85);
        _opcionesAvanzadas.LinkClicked += OpcionesAvanzadas_LinkClicked;
        // 
        // lblProblema
        // 
        lblProblema.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        lblProblema.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        lblProblema.ForeColor = Color.FromArgb(35, 46, 42);
        lblProblema.Location = new Point(24, 379);
        lblProblema.Name = "lblProblema";
        lblProblema.Size = new Size(292, 22);
        lblProblema.TabIndex = 7;
        lblProblema.Text = "Qué hace Jev";
        lblProblema.Visible = false;
        lblProblema.Click += lblProblema_Click;
        // 
        // txtProblema
        // 
        txtProblema.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtProblema.BackColor = Color.FromArgb(247, 248, 246);
        txtProblema.BorderStyle = BorderStyle.FixedSingle;
        txtProblema.Font = new Font("Segoe UI", 10F);
        txtProblema.ForeColor = Color.FromArgb(35, 46, 42);
        txtProblema.Location = new Point(24, 435);
        txtProblema.Multiline = true;
        txtProblema.Name = "txtProblema";
        txtProblema.ReadOnly = true;
        txtProblema.ScrollBars = ScrollBars.Vertical;
        txtProblema.Size = new Size(292, 92);
        txtProblema.TabIndex = 8;
        txtProblema.Visible = false;
        // 
        // lblInstrucciones
        // 
        lblInstrucciones.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        lblInstrucciones.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        lblInstrucciones.ForeColor = Color.FromArgb(35, 46, 42);
        lblInstrucciones.Location = new Point(24, 533);
        lblInstrucciones.Name = "lblInstrucciones";
        lblInstrucciones.Size = new Size(292, 22);
        lblInstrucciones.TabIndex = 9;
        lblInstrucciones.Text = "Instrucciones para Space Bunny";
        lblInstrucciones.Visible = false;
        // 
        // txtInstrucciones
        // 
        txtInstrucciones.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtInstrucciones.BackColor = Color.White;
        txtInstrucciones.BorderStyle = BorderStyle.FixedSingle;
        txtInstrucciones.Font = new Font("Segoe UI", 10F);
        txtInstrucciones.ForeColor = Color.FromArgb(35, 46, 42);
        txtInstrucciones.Location = new Point(24, 560);
        txtInstrucciones.Multiline = true;
        txtInstrucciones.Name = "txtInstrucciones";
        txtInstrucciones.ScrollBars = ScrollBars.Vertical;
        txtInstrucciones.Size = new Size(292, 180);
        txtInstrucciones.TabIndex = 10;
        txtInstrucciones.Visible = false;
        txtInstrucciones.TextChanged += txtInstrucciones_TextChanged;
        // 
        // btnVerOperacionesJev
        // 
        btnVerOperacionesJev.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        btnVerOperacionesJev.BackColor = Color.FromArgb(232, 237, 233);
        btnVerOperacionesJev.Cursor = Cursors.Hand;
        btnVerOperacionesJev.FlatAppearance.BorderSize = 0;
        btnVerOperacionesJev.FlatAppearance.MouseDownBackColor = Color.FromArgb(204, 218, 208);
        btnVerOperacionesJev.FlatAppearance.MouseOverBackColor = Color.FromArgb(218, 228, 221);
        btnVerOperacionesJev.FlatStyle = FlatStyle.Flat;
        btnVerOperacionesJev.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        btnVerOperacionesJev.ForeColor = Color.FromArgb(35, 46, 42);
        btnVerOperacionesJev.Location = new Point(24, 404);
        btnVerOperacionesJev.Name = "btnVerOperacionesJev";
        btnVerOperacionesJev.Size = new Size(292, 25);
        btnVerOperacionesJev.TabIndex = 11;
        btnVerOperacionesJev.Text = "Ver registro de Jev";
        btnVerOperacionesJev.UseVisualStyleBackColor = false;
        btnVerOperacionesJev.Click += btnVerOperacionesJev_Click;
        // 
        // lblEstadoConexion
        // 
        lblEstadoConexion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        lblEstadoConexion.Font = new Font("Segoe UI", 9.5F);
        lblEstadoConexion.ForeColor = Color.FromArgb(99, 111, 105);
        lblEstadoConexion.Location = new Point(24, 452);
        lblEstadoConexion.Name = "lblEstadoConexion";
        lblEstadoConexion.Size = new Size(292, 58);
        lblEstadoConexion.TabIndex = 12;
        lblEstadoConexion.Text = "Estado: Listo para preparar el análisis";
        // 
        // pnlChatContainer
        // 
        pnlChatContainer.BackColor = Color.FromArgb(247, 248, 246);
        pnlChatContainer.Controls.Add(_tituloResultados);
        pnlChatContainer.Controls.Add(_ayudaResultados);
        pnlChatContainer.Controls.Add(rtbConversacion);
        pnlChatContainer.Controls.Add(lblConsulta);
        pnlChatContainer.Controls.Add(txtConsulta);
        pnlChatContainer.Controls.Add(btnNuevaSesion);
        pnlChatContainer.Controls.Add(btnEnviar);
        pnlChatContainer.Dock = DockStyle.Fill;
        pnlChatContainer.Location = new Point(0, 0);
        pnlChatContainer.Name = "pnlChatContainer";
        pnlChatContainer.Size = new Size(884, 761);
        pnlChatContainer.TabIndex = 0;
        // 
        // _tituloResultados
        // 
        _tituloResultados.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        _tituloResultados.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
        _tituloResultados.ForeColor = Color.FromArgb(35, 46, 42);
        _tituloResultados.Location = new Point(24, 20);
        _tituloResultados.Name = "_tituloResultados";
        _tituloResultados.Size = new Size(836, 30);
        _tituloResultados.TabIndex = 0;
        _tituloResultados.Text = "Análisis";
        // 
        // _ayudaResultados
        // 
        _ayudaResultados.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        _ayudaResultados.Font = new Font("Segoe UI", 9.5F);
        _ayudaResultados.ForeColor = Color.FromArgb(99, 111, 105);
        _ayudaResultados.Location = new Point(24, 53);
        _ayudaResultados.Name = "_ayudaResultados";
        _ayudaResultados.Size = new Size(836, 20);
        _ayudaResultados.TabIndex = 1;
        _ayudaResultados.Text = "Aquí verás el dictamen y las señales encontradas.";
        // 
        // rtbConversacion
        // 
        rtbConversacion.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        rtbConversacion.BackColor = Color.White;
        rtbConversacion.BorderStyle = BorderStyle.FixedSingle;
        rtbConversacion.Font = new Font("Segoe UI", 10F);
        rtbConversacion.ForeColor = Color.FromArgb(35, 46, 42);
        rtbConversacion.Location = new Point(24, 88);
        rtbConversacion.Name = "rtbConversacion";
        rtbConversacion.ReadOnly = true;
        rtbConversacion.Size = new Size(836, 439);
        rtbConversacion.TabIndex = 2;
        rtbConversacion.Text = "";
        // 
        // lblConsulta
        // 
        lblConsulta.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lblConsulta.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        lblConsulta.ForeColor = Color.FromArgb(35, 46, 42);
        lblConsulta.Location = new Point(24, 545);
        lblConsulta.Name = "lblConsulta";
        lblConsulta.Size = new Size(836, 22);
        lblConsulta.TabIndex = 3;
        lblConsulta.Text = "Correo para analizar";
        // 
        // txtConsulta
        // 
        txtConsulta.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        txtConsulta.BackColor = Color.White;
        txtConsulta.BorderStyle = BorderStyle.FixedSingle;
        txtConsulta.Font = new Font("Segoe UI", 10F);
        txtConsulta.ForeColor = Color.FromArgb(35, 46, 42);
        txtConsulta.Location = new Point(24, 575);
        txtConsulta.Multiline = true;
        txtConsulta.Name = "txtConsulta";
        txtConsulta.PlaceholderText = "Pega aquí el contenido del correo…";
        txtConsulta.Size = new Size(836, 116);
        txtConsulta.TabIndex = 4;
        txtConsulta.TextChanged += txtConsulta_TextChanged;
        // 
        // btnNuevaSesion
        // 
        btnNuevaSesion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btnNuevaSesion.BackColor = Color.FromArgb(232, 237, 233);
        btnNuevaSesion.Cursor = Cursors.Hand;
        btnNuevaSesion.FlatAppearance.BorderSize = 0;
        btnNuevaSesion.FlatAppearance.MouseDownBackColor = Color.FromArgb(204, 218, 208);
        btnNuevaSesion.FlatAppearance.MouseOverBackColor = Color.FromArgb(218, 228, 221);
        btnNuevaSesion.FlatStyle = FlatStyle.Flat;
        btnNuevaSesion.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        btnNuevaSesion.ForeColor = Color.FromArgb(35, 46, 42);
        btnNuevaSesion.Location = new Point(24, 707);
        btnNuevaSesion.Name = "btnNuevaSesion";
        btnNuevaSesion.Size = new Size(150, 40);
        btnNuevaSesion.TabIndex = 5;
        btnNuevaSesion.Text = "Nueva revisión";
        btnNuevaSesion.UseVisualStyleBackColor = false;
        btnNuevaSesion.Click += btnNuevaSesion_Click;
        // 
        // btnEnviar
        // 
        btnEnviar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnEnviar.BackColor = Color.FromArgb(39, 104, 85);
        btnEnviar.Cursor = Cursors.Hand;
        btnEnviar.FlatAppearance.BorderSize = 0;
        btnEnviar.FlatAppearance.MouseDownBackColor = Color.FromArgb(24, 70, 56);
        btnEnviar.FlatAppearance.MouseOverBackColor = Color.FromArgb(31, 88, 71);
        btnEnviar.FlatStyle = FlatStyle.Flat;
        btnEnviar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        btnEnviar.ForeColor = Color.White;
        btnEnviar.Location = new Point(686, 707);
        btnEnviar.Name = "btnEnviar";
        btnEnviar.Size = new Size(174, 40);
        btnEnviar.TabIndex = 6;
        btnEnviar.Text = "Analizar correo";
        btnEnviar.UseVisualStyleBackColor = false;
        btnEnviar.Click += btnEnviar_Click;
        // 
        // statusStrip
        // 
        statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatus });
        statusStrip.Location = new Point(0, 0);
        statusStrip.Name = "statusStrip";
        statusStrip.Size = new Size(200, 22);
        statusStrip.TabIndex = 2;
        statusStrip.Visible = false;
        // 
        // toolStripStatus
        // 
        toolStripStatus.Name = "toolStripStatus";
        toolStripStatus.Size = new Size(108, 17);
        toolStripStatus.Text = "Sistema preparado.";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(247, 248, 246);
        ClientSize = new Size(1225, 837);
        Controls.Add(splitContenedor);
        Controls.Add(statusStrip);
        Controls.Add(pnlAppHeader);
        MinimumSize = new Size(980, 680);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Jev · Analizador de correos";
        Load += MainForm_Load;
        pnlAppHeader.ResumeLayout(false);
        pnlAppHeader.PerformLayout();
        splitContenedor.Panel1.ResumeLayout(false);
        splitContenedor.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContenedor).EndInit();
        splitContenedor.ResumeLayout(false);
        pnlSidebar.ResumeLayout(false);
        pnlSidebar.PerformLayout();
        pnlChatContainer.ResumeLayout(false);
        pnlChatContainer.PerformLayout();
        statusStrip.ResumeLayout(false);
        statusStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
}
