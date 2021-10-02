using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Content
{
    public sealed record ContentRepresentation
    {
        [JsonPropertyName("name")] public string Name { get; init; }

        [JsonPropertyName("path")] public string Path { get; init; }

        [JsonPropertyName("validationString")] public string ValidationString { get; init; }
    }
}