using DotNetBungieAPI.Models.Ignores;

namespace DotNetBungieAPI.Models.Tags
{
    public sealed record TagResponse
    {
        [JsonPropertyName("tagText")] public string TagText { get; init; }

        [JsonPropertyName("ignoreStatus")] public IgnoreResponse IgnoreStatus { get; init; }
    }
}