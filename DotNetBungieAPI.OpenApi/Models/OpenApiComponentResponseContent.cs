using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models;

public sealed class OpenApiComponentResponseContent
{
    [JsonPropertyName("application/json")]
    public Dictionary<string, OpenApiComponentSchema> Data { get; init; }

    public OpenApiComponentSchema Schema => Data["schema"];
}