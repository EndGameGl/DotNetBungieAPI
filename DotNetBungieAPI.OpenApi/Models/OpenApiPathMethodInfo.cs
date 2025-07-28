using System.Text.Json.Serialization;
using DotNetBungieAPI.OpenApi.Models.ComponentSchemas;

namespace DotNetBungieAPI.OpenApi.Models;

public class OpenApiPathMethodInfo
{
    [JsonPropertyName("tags")]
    public required string[] Tags { get; init; }

    [JsonPropertyName("description")]
    public required string Description { get; init; }

    [JsonPropertyName("operationId")]
    public required string OperationId { get; init; }

    [JsonPropertyName("parameters")]
    public required OpenApiPathMethodParameterInfo[] Parameters { get; init; }

    [JsonPropertyName("requestBody")]
    public OpenApiPathMethodInfoRequest? RequestBody { get; init; }

    [JsonPropertyName("responses")]
    public required Dictionary<string, IOpenApiComponentSchema> Responses { get; init; }

    [JsonPropertyName("security")]
    public OpenApiPathMethodSecurity[]? Security { get; init; }
    
    [JsonPropertyName("deprecated")]
    public required bool Deprecated { get; init; }
    
    [JsonPropertyName("x-preview")]
    public bool? IsPreview { get; init; }
}
