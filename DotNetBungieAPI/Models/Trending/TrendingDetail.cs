using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Trending
{
    public sealed record TrendingDetail
    {
        [JsonPropertyName("identifier")] public string Identifier { get; init; }

        [JsonPropertyName("entityType")] public TrendingEntryType EntityType { get; init; }

        [JsonPropertyName("news")] public TrendingEntryNews News { get; init; }

        [JsonPropertyName("support")] public TrendingEntrySupportArticle Support { get; init; }

        [JsonPropertyName("destinyItem")] public TrendingEntryDestinyItem DestinyItem { get; init; }

        [JsonPropertyName("destinyActivity")] public TrendingEntryDestinyActivity DestinyActivity { get; init; }

        [JsonPropertyName("destinyRitual")] public TrendingEntryDestinyRitual DestinyRitual { get; init; }

        [JsonPropertyName("creation")] public TrendingEntryCommunityCreation Creation { get; init; }
    }
}