using System.Text.Json.Serialization;
using DotNetBungieAPI.OpenApi.Models.ComponentSchemas;

namespace DotNetBungieAPI.OpenApi.Models;

public sealed class OpenApiComponentResponse
{
    [JsonPropertyName("description")]
    public required string Description { get; init; }

    [JsonPropertyName("content")]
    public required Dictionary<string, Dictionary<string, IOpenApiComponentSchema>> Content { get; init; }

    public IOpenApiComponentSchema Schema => Content["application/json"]["schema"];
}
