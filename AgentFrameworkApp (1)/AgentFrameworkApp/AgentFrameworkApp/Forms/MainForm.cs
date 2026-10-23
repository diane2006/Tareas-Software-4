using System;
using System.Windows.Forms;
using AgentFrameworkApp.Services;

namespace AgentFrameworkApp.Forms;

public partial class MainForm : Form
{
    private PhishingAgentOrchestrator? _orquestador;

    public MainForm()
    {
        InitializeComponent();
    }

    private void txtInstrucciones_TextChanged(object? sender, EventArgs e)
    {
        if (_orquestador != null)
            MarcarConfiguracionPendiente();
    }
    private void MarcarConfiguracionPendiente()
    {
        btnEnviar.Enabled = false;
        btnCrearAgente.Text = "Aplicar cambios";
        ActualizarEstado("Hay cambios por aplicar", TonoInterfaz.Atencion);
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        // Cargar variables de entorno desde .env
        DotNetEnv.Env.TraversePath().Load();

        ActiveControl = txtConsulta;

        // Datos iniciales
        txtProblema.Text = "El usuario común no distingue correos sospechosos o con riesgo de phishing. El agente debe orientar e identificar indicadores de riesgo sin abrir enlaces.";

        txtInstrucciones.Text = @"ROL: Orientador y Auditor de Seguridad de Correos.
LÍMITES:
- NUNCA recomiendes interactuar con enlaces o descargar adjuntos sospechosos.
- Realiza deducción por sintaxis (URLs, dominios engañosos, urgencia y suplantación).
FORMATO DE SALIDA:
1. DICTAMEN: [SEGURO / SOSPECHOSO / MALICIOSO]
2. INDICADORES ENCONTRADOS
3. ACCIÓN RECOMENDADA PARA EL USUARIO";

        ActualizarEstado("Listo para preparar el análisis", TonoInterfaz.Neutro);
        AgregarMensajeChat("JEV", "Pega un correo en el campo inferior para comenzar. Jev mostrará aquí las señales encontradas.", TonoInterfaz.Bien);
    }

    private void btnCrearAgente_Click(object sender, EventArgs e)
    {
        string? openCodeKey = Environment.GetEnvironmentVariable("OPENCODE_API_KEY");

        _orquestador = new PhishingAgentOrchestrator(
            openCodeKey ?? string.Empty,
            txtInstrucciones.Text
        );
        btnEnviar.Enabled = true;

        ActualizarEstado("Listo · análisis con Jev", TonoInterfaz.Bien);
        btnCrearAgente.Text = "Actualizar configuración";
        AgregarMensajeChat("CONFIGURACIÓN", "Jev está listo para analizar correos.", TonoInterfaz.Neutro);
    }

    private async void btnEnviar_Click(object sender, EventArgs e)
    {
        if (_orquestador == null)
        {
            MessageBox.Show("Primero configura Jev para iniciar el análisis.", "Jev no está configurado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string consulta = txtConsulta.Text.Trim();
        if (string.IsNullOrWhiteSpace(consulta))
        {
            MessageBox.Show("Por favor introduce el correo sospechoso en el cuadro de consulta.", "Consulta vacía", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        // Bloqueo temporal de UI durante la inferencia
        btnEnviar.Enabled = false;
        btnEnviar.Text = "Analizando…";
        btnCrearAgente.Enabled = false;
        cbModelos.Enabled = false;
        txtInstrucciones.Enabled = false;
        ActualizarEstado("Analizando el correo…", TonoInterfaz.Atencion);

        AgregarMensajeChat("CORREO", consulta, TonoInterfaz.Neutro);
        txtConsulta.Clear();

        try
        {
            // Evaluación con Jev (reglas locales + Microsoft Agent Framework)
            var resultadoJev = await _orquestador.EvaluarConJevAsync(consulta);

            TonoInterfaz tonoEstado = resultadoJev.Estado switch
            {
                EstadoJev.Seguro => TonoInterfaz.Bien,
                EstadoJev.Sospechoso => TonoInterfaz.Atencion,
                EstadoJev.Inseguro => TonoInterfaz.Error,
                _ => TonoInterfaz.Neutro
            };

            AgregarMensajeChat("JEV · CLASIFICACIÓN INICIAL",
                $"Veredicto preliminar: {NombreEstado(resultadoJev.Estado)}\n" +
                $"Puntuación de Riesgo / Duda: {resultadoJev.NivelConfianza}%\n" +
                $"Observación: {resultadoJev.Explicacion}",
                tonoEstado);

            AgregarMensajeChat("RESULTADO", $"Análisis de Jev finalizado: {NombreEstado(resultadoJev.Estado)}.", TonoInterfaz.Neutro);

            ActualizarEstado("Análisis finalizado", TonoInterfaz.Bien);
        }
        catch (Exception ex)
        {
            AgregarMensajeChat("ERROR", $"No se pudo completar el análisis: {ex.Message}", TonoInterfaz.Error);
            ActualizarEstado("No se pudo completar el análisis", TonoInterfaz.Error);
        }
        finally
        {
            btnEnviar.Enabled = true;
            btnEnviar.Text = "Analizar correo";
            btnCrearAgente.Enabled = true;
            cbModelos.Enabled = true;
            txtInstrucciones.Enabled = true;
        }
    }

    private void btnNuevaSesion_Click(object sender, EventArgs e)
    {
        _orquestador?.LimpiarSesion();
        rtbConversacion.Clear();
        txtConsulta.Clear();
        ActualizarEstado("Nueva revisión lista", TonoInterfaz.Neutro);
        AgregarMensajeChat("JEV", "Sesión limpia. Puedes pegar otro correo para revisar.", TonoInterfaz.Bien);
    }

    private void btnVerOperacionesJev_Click(object sender, EventArgs e)
    {
        if (_orquestador == null)
        {
            MessageBox.Show("Primero configura Jev.", "Configuración necesaria", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var viewer = new JevViewerForm(_orquestador.LogsJev);
        viewer.ShowDialog(this);
    }

    private static string NombreEstado(EstadoJev estado) => estado switch
    {
        EstadoJev.Seguro => "Seguro",
        EstadoJev.Sospechoso => "Sospechoso",
        EstadoJev.Inseguro => "Peligroso",
        _ => "Sin clasificar"
    };

    private void lblProblema_Click(object sender, EventArgs e)
    {

    }
}
