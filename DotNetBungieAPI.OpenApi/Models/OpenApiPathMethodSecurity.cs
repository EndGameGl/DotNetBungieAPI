using System.Diagnostics;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models;

[DebuggerDisplay("{Oauth2[0]}")]
public class OpenApiPathMethodSecurity
{
    [JsonPropertyName("oauth2")]
    public List<string> Oauth2 { get; set; }
}
