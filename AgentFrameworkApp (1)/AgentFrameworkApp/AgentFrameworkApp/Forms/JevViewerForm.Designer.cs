namespace AgentFrameworkApp.Forms;

partial class JevViewerForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.RichTextBox rtbJevLogs;
    private System.Windows.Forms.Button btnCerrar;
    private System.Windows.Forms.Panel pnlHeader;
    private System.Windows.Forms.Label lblTitulo;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        rtbJevLogs = new RichTextBox();
        btnCerrar = new Button();
        pnlHeader = new Panel();
        lblTitulo = new Label();
        pnlHeader.SuspendLayout();
        SuspendLayout();
        // 
        // rtbJevLogs
        // 
        rtbJevLogs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        rtbJevLogs.BackColor = Color.FromArgb(18, 22, 30);
        rtbJevLogs.BorderStyle = BorderStyle.None;
        rtbJevLogs.Font = new Font("Consolas", 10F);
        rtbJevLogs.ForeColor = Color.FromArgb(50, 205, 50);
        rtbJevLogs.Location = new Point(16, 62);
        rtbJevLogs.Name = "rtbJevLogs";
        rtbJevLogs.ReadOnly = true;
        rtbJevLogs.Size = new Size(688, 380);
        rtbJevLogs.TabIndex = 0;
        rtbJevLogs.Text = "";
        // 
        // btnCerrar
        // 
        btnCerrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnCerrar.BackColor = Color.FromArgb(35, 45, 60);
        btnCerrar.Cursor = Cursors.Hand;
        btnCerrar.FlatAppearance.BorderSize = 0;
        btnCerrar.FlatStyle = FlatStyle.Flat;
        btnCerrar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
        btnCerrar.ForeColor = Color.White;
        btnCerrar.Location = new Point(594, 454);
        btnCerrar.Name = "btnCerrar";
        btnCerrar.Size = new Size(110, 34);
        btnCerrar.TabIndex = 1;
        btnCerrar.Text = "Cerrar";
        btnCerrar.UseVisualStyleBackColor = false;
        btnCerrar.Click += btnCerrar_Click;
        // 
        // pnlHeader
        // 
        pnlHeader.BackColor = Color.FromArgb(24, 30, 44);
        pnlHeader.Controls.Add(lblTitulo);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(0, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Size = new Size(720, 50);
        pnlHeader.TabIndex = 2;
        // 
        // lblTitulo
        // 
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.White;
        lblTitulo.Location = new Point(16, 14);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(185, 21);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Jev · Registro de análisis";
        // 
        // JevViewerForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(15, 18, 25);
        ClientSize = new Size(720, 500);
        Controls.Add(btnCerrar);
        Controls.Add(rtbJevLogs);
        Controls.Add(pnlHeader);
        MinimumSize = new Size(550, 400);
        Name = "JevViewerForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Jev · Registro de análisis";
        Load += JevViewerForm_Load;
        pnlHeader.ResumeLayout(false);
        pnlHeader.PerformLayout();
        ResumeLayout(false);
    }
}
