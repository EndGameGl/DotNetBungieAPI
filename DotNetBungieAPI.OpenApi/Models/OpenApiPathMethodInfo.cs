using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models;

public class OpenApiPathMethodInfo
{
    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("operationId")]
    public string OperationId { get; set; }

    [JsonPropertyName("parameters")]
    public List<OpenApiPathMethodParameterInfo> Parameters { get; set; }

    [JsonPropertyName("requestBody")]
    public OpenApiPathMethodInfoRequest? RequestBody { get; set; }

    [JsonPropertyName("responses")]
    public Dictionary<string, OpenApiComponentSchema> Responses { get; set; }

    [JsonPropertyName("security")]
    public List<OpenApiPathMethodSecurity> Security { get; set; }
}
