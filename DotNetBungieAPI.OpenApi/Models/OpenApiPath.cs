using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models;

public class OpenApiPath
{
    [JsonPropertyName("summary")]
    public required string Summary { get; set; }

    [JsonPropertyName("description")]
    public required string Description { get; set; }

    [JsonPropertyName("get")]
    public OpenApiPathMethodInfo? Get { get; set; }

    [JsonPropertyName("post")]
    public OpenApiPathMethodInfo? Post { get; set; }

    public (OpenApiPathMethodInfo, string MethodType) GetMethod()
    {
        return Get is null ? (Post!, "POST") : (Get!, "GET");
    }
}
