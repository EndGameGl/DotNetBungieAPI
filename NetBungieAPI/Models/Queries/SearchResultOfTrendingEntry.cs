using NetBungieAPI.Models.Trending;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Queries
{
    public sealed record SearchResultOfTrendingEntry : SearchResultBase
    {
        [JsonPropertyName("results")]
        public ReadOnlyCollection<TrendingEntry> Results { get; init; } = Defaults.EmptyReadOnlyCollection<TrendingEntry>();
    }
}
