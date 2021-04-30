using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Responses
{
    public sealed record DestinyEntitySearchResult
    {
        [JsonPropertyName("suggestedWords")]
        public ReadOnlyCollection<string> SuggestedWords { get; init; } = Defaults.EmptyReadOnlyCollection<string>();
        [JsonPropertyName("results")]
        public SearchResultOfDestinyEntitySearch Results { get; init; }
    }
}
