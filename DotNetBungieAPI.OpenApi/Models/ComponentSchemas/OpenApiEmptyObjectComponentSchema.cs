using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models.ComponentSchemas;

public class OpenApiEmptyObjectComponentSchema : IOpenApiComponentSchema
{
    [JsonPropertyName("type")]
    public required string Type { get; init; }
}