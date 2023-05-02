using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models;

public class OpenApiPathMethodInfoRequestContent
{
    [JsonPropertyName("schema")]
    public OpenApiComponentSchema Schema { get; set; }
}
