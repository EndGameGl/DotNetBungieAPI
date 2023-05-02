using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models;

public class OpenApiPath
{
    [JsonPropertyName("summary")]
    public string Summary { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("get")]
    public OpenApiPathMethodInfo? Get { get; set; }

    [JsonPropertyName("post")]
    public OpenApiPathMethodInfo? Post { get; set; }
}