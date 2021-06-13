using NetBungieAPI.Models.Ignores;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Tags
{
    public sealed record TagResponse
    {
        [JsonPropertyName("tagText")]
        public string TagText { get; init; }

        [JsonPropertyName("ignoreStatus")]
        public IgnoreResponse IgnoreStatus { get; init; }
    }
}
