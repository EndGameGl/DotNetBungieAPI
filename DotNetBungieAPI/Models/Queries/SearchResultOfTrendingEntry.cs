using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Defaults;
using DotNetBungieAPI.Models.Trending;

namespace DotNetBungieAPI.Models.Queries
{
    public sealed record SearchResultOfTrendingEntry : SearchResultBase
    {
        [JsonPropertyName("results")]
        public ReadOnlyCollection<TrendingEntry> Results { get; init; } = ReadOnlyCollections<TrendingEntry>.Empty;
    }
}