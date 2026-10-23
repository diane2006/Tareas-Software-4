using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AgentFrameworkApp.Forms;

public partial class JevViewerForm : Form
{
    public JevViewerForm(IEnumerable<string> logs)
    {
        InitializeComponent();
        BackColor = Color.FromArgb(248, 246, 241);
        pnlHeader.BackColor = Color.White;
        lblTitulo.ForeColor = Color.FromArgb(38, 48, 42);
        lblTitulo.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
        rtbJevLogs.BackColor = Color.White;
        rtbJevLogs.ForeColor = Color.FromArgb(48, 50, 45);
        rtbJevLogs.BorderStyle = BorderStyle.FixedSingle;
        btnCerrar.BackColor = Color.FromArgb(47, 112, 94);
        btnCerrar.ForeColor = Color.White;
        btnCerrar.FlatStyle = FlatStyle.Flat;
        btnCerrar.FlatAppearance.BorderSize = 0;
        btnCerrar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        rtbJevLogs.Clear();
        foreach (var log in logs)
        {
            rtbJevLogs.AppendText(log + "\n");
        }

        if (rtbJevLogs.TextLength == 0)
        {
            rtbJevLogs.Text = "Aún no hay análisis registrados de Jev. Inicia una revisión en la ventana principal.";
        }
    }

    private void btnCerrar_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void JevViewerForm_Load(object sender, EventArgs e)
    {

    }
}
