using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models.ComponentSchemas;

public class OpenApiObjectMultiTypeComponentSchema : IOpenApiComponentSchema, IHasDescription
{
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    [JsonPropertyName("allOf")]
    public required IOpenApiComponentSchema[] AllOf { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("x-destiny-component-type-dependency")]
    public string? DestinyComponentTypeDependency { get; init; }
}
