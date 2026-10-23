using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AgentFrameworkApp.Services;

public class RiskIndicator
{
    public string Tipo { get; set; } = string.Empty;
    public string Detalle { get; set; } = string.Empty;
    public int NivelRiesgo { get; set; } // 1 a 10
}

public class EmailRiskReport
{
    public List<RiskIndicator> Indicadores { get; set; } = new();
    public List<string> UrlsDetectadas { get; set; } = new();
    public int PuntuacionRiesgoTotal { get; set; } // 0 a 100
    public string Resumen { get; set; } = string.Empty;
}

public static class EmailRiskInspectorTool
{
    private static readonly Regex UrlRegex = new(
        @"https?://[^\s<>""']+|(?<![@\w.-])(?:[A-Z0-9-]+\.)+[A-Z]{2,}(?::\d{2,5})?(?:/[^\s<>""']*)?",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    private static readonly Regex SenderRegex = new(
        @"(?im)^\s*(?:from|de|remitente)\s*:\s*[^\r\n]*?([A-Z0-9._%+-]+@(?<domain>[A-Z0-9.-]+\.[A-Z]{2,}))\s*$|^\s*([A-Z0-9._%+-]+@(?<domain2>[A-Z0-9.-]+\.[A-Z]{2,}))\s*$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    private static readonly string[] DominiosBancariosYServicios = { 
        "paypal", "microsoft", "google", "apple", "banco", "netflix", "amazon", "santander", "bbva", "chase" 
    };

    private static readonly string[] ExtensionesPeligrosas = { 
        ".exe", ".scr", ".vbs", ".bat", ".cmd", ".iso", ".zip", ".rar", ".msi", ".ps1" 
    };

    public static EmailRiskReport AnalizarCorreo(string contenidoCorreo)
    {
        var reporte = new EmailRiskReport();
        var matches = UrlRegex.Matches(contenidoCorreo);

        foreach (Match match in matches)
        {
            string urlTexto = match.Value.TrimEnd('.', ',', ';', ':', '!', '?', ')', ']', '}');
            reporte.UrlsDetectadas.Add(urlTexto);

            string urlParaAnalizar = urlTexto.Contains("://", StringComparison.Ordinal)
                ? urlTexto
                : $"https://{urlTexto}";
            if (Uri.TryCreate(urlParaAnalizar, UriKind.Absolute, out Uri? uri))
            {
                // 1. IP directa en lugar de nombre de dominio
                if (Regex.IsMatch(uri.Host, @"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$"))
                {
                    reporte.Indicadores.Add(new RiskIndicator
                    {
                        Tipo = "Dirección IP Directa",
                        Detalle = $"El enlace usa una dirección IP directa en vez de un dominio registrado: {uri.Host}",
                        NivelRiesgo = 9
                    });
                }

                // 2. Punycode / Homógrafo (ej: xn--)
                if (uri.Host.StartsWith("xn--", StringComparison.OrdinalIgnoreCase))
                {
                    reporte.Indicadores.Add(new RiskIndicator
                    {
                        Tipo = "Dominio Punycode / Homógrafo",
                        Detalle = $"Caracteres internacionales sospechosos que simulan letras normales: {uri.Host}",
                        NivelRiesgo = 9
                    });
                }

                // 3. Typosquatting / Marcas conocidas en subdominios
                string hostLower = uri.Host.ToLowerInvariant();
                foreach (var marca in DominiosBancariosYServicios)
                {
                    if (hostLower.Contains(marca) && !hostLower.EndsWith($".{marca}.com") && hostLower != $"{marca}.com")
                    {
                        reporte.Indicadores.Add(new RiskIndicator
                        {
                            Tipo = "Suplantación de Marca (Typosquatting)",
                            Detalle = $"Se menciona la entidad '{marca}' en un dominio ajeno o subdominio falso: {uri.Host}",
                            NivelRiesgo = 8
                        });
                    }
                }

                // 4. Puertos inusuales
                if (!uri.IsDefaultPort && uri.Port != 80 && uri.Port != 443)
                {
                    reporte.Indicadores.Add(new RiskIndicator
                    {
                        Tipo = "Puerto de Red Inusual",
                        Detalle = $"El enlace redirige al puerto no estándar {uri.Port}",
                        NivelRiesgo = 6
                    });
                }

                // 5. Descargas de archivos ejecutables
                foreach (var ext in ExtensionesPeligrosas)
                {
                    if (uri.AbsolutePath.EndsWith(ext, StringComparison.OrdinalIgnoreCase))
                    {
                        reporte.Indicadores.Add(new RiskIndicator
                        {
                            Tipo = "Archivo Peligroso o Descarga Forzada",
                            Detalle = $"El enlace apunta a un archivo con extensión potencialmente dañina ({ext})",
                            NivelRiesgo = 10
                        });
                    }
                }
            }
        }

        // Un enlace de documentos que no comparte el dominio del remitente
        // puede ser legítimo, pero debe revisarse antes de considerarlo seguro.
        Match remitente = SenderRegex.Match(contenidoCorreo);
        if (remitente.Success && matches.Count > 0)
        {
            string dominioRemitente = remitente.Groups["domain"].Success
                ? remitente.Groups["domain"].Value
                : remitente.Groups["domain2"].Value;

            bool dominiosDiferentes = false;
            foreach (Match match in matches)
            {
                string destino = match.Value.TrimEnd('.', ',', ';', ':', '!', '?', ')', ']', '}');
                string urlParaAnalizar = destino.Contains("://", StringComparison.Ordinal)
                    ? destino
                    : $"https://{destino}";
                if (Uri.TryCreate(urlParaAnalizar, UriKind.Absolute, out Uri? uri) &&
                    !string.Equals(uri.Host, dominioRemitente, StringComparison.OrdinalIgnoreCase))
                {
                    dominiosDiferentes = true;
                    break;
                }
            }

            if (dominiosDiferentes)
            {
                reporte.Indicadores.Add(new RiskIndicator
                {
                    Tipo = "Dominio del remitente distinto al enlace",
                    Detalle = $"El remitente usa '{dominioRemitente}', pero el enlace apunta a otro dominio. Confirma el destino por un canal conocido.",
                    NivelRiesgo = 3
                });
            }
        }

        // 6. Patrones de coacción e ingeniería social
        string textoLower = contenidoCorreo.ToLowerInvariant();
        bool prometePremio = Regex.IsMatch(textoLower,
            @"\b(?:te\s+ganaste|ganaste|has\s+ganado|eres\s+(?:el\s+)?ganador|premio|sorteo|regalo)\b");
        if (prometePremio)
        {
            reporte.Indicadores.Add(new RiskIndicator
            {
                Tipo = "Premio no solicitado",
                Detalle = "El mensaje anuncia un premio o regalo inesperado; conviene verificarlo por un canal conocido.",
                NivelRiesgo = 4
            });

            if (reporte.UrlsDetectadas.Count > 0 &&
                Regex.IsMatch(textoLower, @"\b(?:ingresa|entra|accede|visita|haz\s+clic|pulsa|abre)\b"))
            {
                reporte.Indicadores.Add(new RiskIndicator
                {
                    Tipo = "Enlace para reclamar premio",
                    Detalle = "El correo pide visitar un enlace para obtener el supuesto premio. No abras el enlace sin verificar la oferta.",
                    NivelRiesgo = 3
                });
            }
        }

        if (textoLower.Contains("urgente") || 
            textoLower.Contains("bloqueo de cuenta") || 
            textoLower.Contains("suspensión") || 
            textoLower.Contains("24 horas") ||
            textoLower.Contains("actualice sus datos") ||
            textoLower.Contains("factura vencida") ||
            Regex.IsMatch(textoLower, @"\b(?:hasta|antes de|vence|expira|disponible)\b[^\r\n]{0,100}\b(?:hoy|mañana|\d{1,2}\s*(?:horas?|días?))\b"))
        {
            reporte.Indicadores.Add(new RiskIndicator
            {
                Tipo = "Plazo limitado",
                Detalle = "El correo condiciona el acceso a un plazo próximo; la presión temporal es una señal que conviene verificar.",
                NivelRiesgo = textoLower.Contains("urgente") || textoLower.Contains("bloqueo de cuenta") || textoLower.Contains("suspensión") ? 7 : 2
            });
        }

        // Cálculo acumulado de riesgo
        int suma = 0;
        foreach (var ind in reporte.Indicadores)
        {
            suma += ind.NivelRiesgo * 10;
        }
        reporte.PuntuacionRiesgoTotal = Math.Clamp(suma, 0, 100);
        reporte.Resumen = reporte.Indicadores.Count == 0
            ? "No se identificaron señales de riesgo con las reglas locales; esto no confirma que el correo sea legítimo."
            : $"Se detectaron {reporte.Indicadores.Count} señales: {string.Join("; ", reporte.Indicadores.ConvertAll(ind => ind.Tipo))}.";

        return reporte;
    }
}
