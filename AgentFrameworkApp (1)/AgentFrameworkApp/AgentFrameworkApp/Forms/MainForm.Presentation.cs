using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AgentFrameworkApp.Forms;

public partial class MainForm
{
    private enum TonoInterfaz { Neutro, Bien, Atencion, Error }

    private Color ColorDelTono(TonoInterfaz tono) => tono switch
    {
        TonoInterfaz.Bien => btnCrearAgente.BackColor,
        TonoInterfaz.Atencion => Color.FromArgb(148, 90, 31),
        TonoInterfaz.Error => Color.FromArgb(166, 60, 54),
        _ => _ayudaResultados.ForeColor
    };

    private void OpcionesAvanzadas_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
    {
        bool mostrar = !txtProblema.Visible;
        _opcionesAvanzadas.Text = mostrar ? "Ocultar opciones avanzadas" : "Mostrar opciones avanzadas";
        lblProblema.Visible = txtProblema.Visible = lblInstrucciones.Visible = txtInstrucciones.Visible = mostrar;
        btnVerOperacionesJev.Top = mostrar ? 758 : 394;
        lblEstadoConexion.Top = mostrar ? 816 : 452;
    }

    private void txtConsulta_TextChanged(object? sender, EventArgs e) =>
        txtConsulta.ScrollBars = txtConsulta.Lines.Length > 5 ? ScrollBars.Vertical : ScrollBars.None;

    private void ActualizarEstado(string mensaje, TonoInterfaz tono)
    {
        lblEstadoConexion.Text = $"Estado: {mensaje}";
        lblEstadoConexion.ForeColor = ColorDelTono(tono);
        toolStripStatus.Text = mensaje;
    }

    private void AgregarMensajeChat(string remitente, string mensaje, TonoInterfaz tono)
    {
        rtbConversacion.SelectionStart = rtbConversacion.TextLength;
        rtbConversacion.SelectionLength = 0;
        rtbConversacion.SelectionIndent = 16;
        rtbConversacion.SelectionRightIndent = 16;
        rtbConversacion.SelectionColor = ColorDelTono(tono);
        rtbConversacion.SelectionFont = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        rtbConversacion.AppendText($"{remitente}   ·   {DateTime.Now:HH:mm}\n\n");

        string[] lineas = mensaje.Replace("\r\n", "\n").Split('\n');
        bool lineaAnteriorVacia = false;
        foreach (string original in lineas)
        {
            string linea = original.Trim();
            if (linea.Length == 0 || Regex.IsMatch(linea, @"^-{3,}$"))
            {
                if (!lineaAnteriorVacia)
                    rtbConversacion.AppendText("\n");
                lineaAnteriorVacia = true;
                continue;
            }

            Match titulo = Regex.Match(linea, @"^#{1,6}\s+(.+)$");
            bool esTitulo = titulo.Success;
            bool esVineta = Regex.IsMatch(linea, @"^[-*]\s+");
            bool esPaso = Regex.IsMatch(linea, @"^\d+[.)]\s+");
            if (esTitulo && !lineaAnteriorVacia)
                rtbConversacion.AppendText("\n");

            rtbConversacion.SelectionIndent = esVineta || esPaso ? 34 : 16;
            rtbConversacion.SelectionHangingIndent = esVineta || esPaso ? -18 : 0;
            rtbConversacion.SelectionRightIndent = 16;

            string contenido = esTitulo ? titulo.Groups[1].Value : linea;
            if (esVineta)
                contenido = "•  " + Regex.Replace(contenido, @"^[-*]\s+", "");

            foreach (string parte in Regex.Split(contenido, @"(\*\*[^*\r\n]+\*\*)"))
            {
                if (parte.Length == 0) continue;
                bool negrita = parte.StartsWith("**") && parte.EndsWith("**");
                rtbConversacion.SelectionColor = esTitulo ? btnCrearAgente.BackColor : rtbConversacion.ForeColor;
                rtbConversacion.SelectionFont = new Font("Segoe UI", esTitulo ? 11.5F : 10.5F,
                    esTitulo || negrita ? FontStyle.Bold : FontStyle.Regular);
                rtbConversacion.AppendText(negrita ? parte[2..^2] : parte);
            }

            rtbConversacion.AppendText(esTitulo ? "\n\n" : "\n");
            lineaAnteriorVacia = esTitulo;
        }

        rtbConversacion.SelectionColor = rtbConversacion.ForeColor;
        rtbConversacion.SelectionIndent = 16;
        rtbConversacion.SelectionHangingIndent = 0;
        rtbConversacion.AppendText("\n");
        rtbConversacion.ScrollToCaret();
    }
}
