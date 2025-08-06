namespace DotNetBungieAPI.Models.Trending;

public sealed class TrendingDetail
{
    [JsonPropertyName("identifier")]
    public string Identifier { get; init; }

    [JsonPropertyName("entityType")]
    public Trending.TrendingEntryType EntityType { get; init; }

    [JsonPropertyName("news")]
    public Trending.TrendingEntryNews? News { get; init; }

    [JsonPropertyName("support")]
    public Trending.TrendingEntrySupportArticle? Support { get; init; }

    [JsonPropertyName("destinyItem")]
    public Trending.TrendingEntryDestinyItem? DestinyItem { get; init; }

    [JsonPropertyName("destinyActivity")]
    public Trending.TrendingEntryDestinyActivity? DestinyActivity { get; init; }

    [JsonPropertyName("destinyRitual")]
    public Trending.TrendingEntryDestinyRitual? DestinyRitual { get; init; }

    [JsonPropertyName("creation")]
    public Trending.TrendingEntryCommunityCreation? Creation { get; init; }
}
