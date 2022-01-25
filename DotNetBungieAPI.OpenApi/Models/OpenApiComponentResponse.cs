using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models;

public sealed class OpenApiComponentResponse
{
    [JsonPropertyName("description")] public string Description { get; init; }
    
    [JsonPropertyName("content")] public OpenApiComponentResponseContent Content { get; init; }
}