using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.Queries;

namespace NetBungieAPI.Models.Destiny.Responses
{
    public sealed record SearchResultOfDestinyEntitySearch : SearchResultBase
    {
        [JsonPropertyName("results")]
        public ReadOnlyCollection<DestinyEntitySearchResultItem> Results { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyEntitySearchResultItem>();
    }
}
