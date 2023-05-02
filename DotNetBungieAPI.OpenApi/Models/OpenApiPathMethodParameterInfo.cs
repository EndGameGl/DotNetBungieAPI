using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models;

public class OpenApiPathMethodParameterInfo
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("in")]
    public string In { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("required")]
    public bool Required { get; set; }

    [JsonPropertyName("schema")]
    public OpenApiComponentSchema Schema { get; set; }
}
