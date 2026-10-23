using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace AgentFrameworkApp.Services;

public enum EstadoJev
{
    Seguro,
    Sospechoso,
    Inseguro
}

public class JevResult
{
    public EstadoJev Estado { get; set; }
    public int NivelConfianza { get; set; }
    public string LogOperacion { get; set; } = string.Empty;
    public string Explicacion { get; set; } = string.Empty;
}

public class PhishingAgentOrchestrator
{
    private readonly AIAgent _jevAgent;
    private readonly List<string> _historialJev = new();

    public IReadOnlyList<string> LogsJev => _historialJev;

    public PhishingAgentOrchestrator(
        string openCodeKey,
        string instrucciones)
    {
        _jevAgent = new ChatClientAgent(
            new JevChatClient(openCodeKey),
            instructions: instrucciones,
            name: "JevPhishingInspector",
            description: "Clasifica correos por riesgo de phishing usando Jev.");
    }

    public void LimpiarSesion()
    {
        _historialJev.Clear();
    }

    public async Task<JevResult> EvaluarConJevAsync(string contenidoCorreo)
    {
        var log = new StringBuilder();
        log.AppendLine($"=== [JEV · REGISTRO DE ANÁLISIS] INICIO [{DateTime.Now:HH:mm:ss}] ===");

        // Herramienta nativa de C#
        var reporte = EmailRiskInspectorTool.AnalizarCorreo(contenidoCorreo);
        log.AppendLine($"[TOOL LOCAL] URLs encontradas: {reporte.UrlsDetectadas.Count}");
        log.AppendLine($"[TOOL LOCAL] Riesgo estático calculado: {reporte.PuntuacionRiesgoTotal}/100");

        foreach (var ind in reporte.Indicadores)
        {
            log.AppendLine($"  - [{ind.Tipo}] {ind.Detalle} (Riesgo: {ind.NivelRiesgo}/10)");
        }

        int scoreFinal = reporte.PuntuacionRiesgoTotal;
        string explicacion = reporte.Resumen;

        string? errorJev = null;
        try
        {
            string prompt = $"Evalúa si este correo presenta phishing, fraude o una solicitud engañosa que requiere verificación independiente. Considera remitente, enlaces, premios, urgencia y contexto. Devuelve solo un JSON con la propiedad sospechoso (boolean) y probabilidad (número entre 0 y 1).\nSEÑALES LOCALES: {reporte.Resumen}\nCORREO:\n{contenidoCorreo}";
            string respuesta = (await _jevAgent.RunAsync(prompt)).Text;
            using var doc = JsonDocument.Parse(respuesta);
            double probabilidad = doc.RootElement.GetProperty("probabilidad").GetDouble();
            if (!double.IsFinite(probabilidad) || probabilidad < 0 || probabilidad > 1)
                throw new JsonException("Jev devolvió una probabilidad fuera del rango esperado.");

            int riesgoJev = (int)Math.Round(probabilidad * 100);
            scoreFinal = Math.Max(scoreFinal, riesgoJev);
            explicacion = $"{reporte.Resumen} Jev estimó {riesgoJev}% de probabilidad de que el correo requiera verificación.";
            log.AppendLine($"[OPENCODE ZEN · JEV] Probabilidad de sospecha: {riesgoJev}%.");
        }
        catch (Exception ex)
        {
            errorJev = ex.Message;
            log.AppendLine($"[AVISO] No se pudo evaluar con Jev ({errorJev}). Se conservan las señales locales.");
            scoreFinal = Math.Max(scoreFinal, 40);
            explicacion = $"Jev no respondió: {errorJev} {reporte.Resumen} Revisa el correo manualmente.";
        }

        // Clasificación de Estados
        EstadoJev estado;
        if (scoreFinal < 40)
        {
            estado = EstadoJev.Seguro;
        }
        else if (scoreFinal <= 85)
        {
            estado = EstadoJev.Sospechoso;
        }
        else
        {
            estado = EstadoJev.Inseguro;
        }

        log.AppendLine($"[VEREDICTO JEV] Nivel de Riesgo: {scoreFinal}% | Estado resultante: {estado}");
        log.AppendLine($"=== FIN AUDITORÍA JEV ===\n");
        _historialJev.Add(log.ToString());

        return new JevResult
        {
            Estado = estado,
            NivelConfianza = scoreFinal,
            LogOperacion = log.ToString(),
            Explicacion = explicacion
        };
    }

    private sealed class JevChatClient(string apiKey) : IChatClient
    {
        private readonly HttpClient _httpClient = new();

        public ChatClientMetadata Metadata { get; } = new("opencode-zen", new Uri("https://opencode.ai/zen/v1"));

        public async Task<ChatResponse> GetResponseAsync(
            IEnumerable<ChatMessage> messages,
            ChatOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new InvalidOperationException("Falta OPENCODE_API_KEY en .env.");

            string state = string.Join("\n", messages.SelectMany(m => m.Contents).OfType<Microsoft.Extensions.AI.TextContent>().Select(c => c.Text));
            using var request = new HttpRequestMessage(HttpMethod.Post, "https://opencode.ai/zen/v1/systemone");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            request.Content = new StringContent(JsonSerializer.Serialize(new
            {
                model = "jev-1.13-free",
                state,
                questions = new
                {
                    resultado = new
                    {
                        type = "noul",
                        instructions = "¿Este correo presenta señales de phishing, fraude o una solicitud engañosa que requiere verificación independiente? Considera remitente, enlaces, premios, urgencia y contexto."
                    }
                }
            }), Encoding.UTF8, "application/json");

            using var response = await _httpClient.SendAsync(request, cancellationToken);
            response.EnsureSuccessStatusCode();
            using var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync(cancellationToken));
            JsonElement answer = doc.RootElement.GetProperty("answers").GetProperty("resultado");
            double probability = answer.GetProperty("noul").GetDouble();
            string result = JsonSerializer.Serialize(new { sospechoso = probability >= 0.5, probabilidad = probability, criterio = answer.ToString() });
            return new ChatResponse(new ChatMessage(ChatRole.Assistant, result));
        }

        public async IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(
            IEnumerable<ChatMessage> messages,
            ChatOptions? options = null,
            [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            ChatResponse response = await GetResponseAsync(messages, options, cancellationToken);
            foreach (ChatResponseUpdate update in response.ToChatResponseUpdates())
                yield return update;
        }

        public object? GetService(Type serviceType, object? serviceKey = null) =>
            serviceType == typeof(ChatClientMetadata) ? Metadata : null;

        public void Dispose() => _httpClient.Dispose();
    }
}
