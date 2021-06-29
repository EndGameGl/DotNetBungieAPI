using System.Text.Json.Serialization;
using NetBungieAPI.Models.Ignores;

namespace NetBungieAPI.Models.Tags
{
    public sealed record TagResponse
    {
        [JsonPropertyName("tagText")] public string TagText { get; init; }

        [JsonPropertyName("ignoreStatus")] public IgnoreResponse IgnoreStatus { get; init; }
    }
}