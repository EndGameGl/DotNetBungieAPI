using System.Diagnostics;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models.ComponentSchemas;

[DebuggerDisplay("Enum: {EnumReference} ({Type}:{Format})")]
public class OpenApiEnumReferenceComponentSchema : IOpenApiComponentSchema, IHasDescription, ICanBeNullable
{
    [JsonPropertyName("type")]
    public required string Type { get; init; }
    
    [JsonPropertyName("description")]
    public string? Description { get; init; }
    
    [JsonPropertyName("format")]
    public string? Format { get; init; }
    
    [JsonPropertyName("x-enum-reference")]
    public required IOpenApiComponentSchema EnumReference { get; init; }
    
    [JsonPropertyName("x-enum-is-bitmask")]
    public required bool EnumIsBitmask { get; init; }
    
    [JsonPropertyName("nullable")]
    public bool? Nullable { get; init; }
}