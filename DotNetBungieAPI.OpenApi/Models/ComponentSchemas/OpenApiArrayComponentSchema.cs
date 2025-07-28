using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models.ComponentSchemas;

public class OpenApiArrayComponentSchema : IOpenApiComponentSchema, IHasDescription, IMappedDefinition
{
    [JsonPropertyName("type")]
    public required string Type { get; init; }
    
    [JsonPropertyName("items")]
    public required IOpenApiComponentSchema Items { get; init; }
    
    [JsonPropertyName("description")]
    public string? Description { get; init; }
    
    [JsonPropertyName("x-mapped-definition")]
    public OpenApiComponentReference? MappedDefinition { get; init; }
}