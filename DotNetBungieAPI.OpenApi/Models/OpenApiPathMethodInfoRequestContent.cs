using System.Text.Json.Serialization;
using DotNetBungieAPI.OpenApi.Models.ComponentSchemas;

namespace DotNetBungieAPI.OpenApi.Models;

public class OpenApiPathMethodInfoRequestContent
{
    [JsonPropertyName("schema")]
    public required IOpenApiComponentSchema Schema { get; init; }
}
