namespace DotNetBungieAPI.Generated.Models.Trending;

public class TrendingDetail
{
    [JsonPropertyName("identifier")]
    public string Identifier { get; set; }

    [JsonPropertyName("entityType")]
    public Trending.TrendingEntryType EntityType { get; set; }

    [JsonPropertyName("news")]
    public Trending.TrendingEntryNews? News { get; set; }

    [JsonPropertyName("support")]
    public Trending.TrendingEntrySupportArticle? Support { get; set; }

    [JsonPropertyName("destinyItem")]
    public Trending.TrendingEntryDestinyItem? DestinyItem { get; set; }

    [JsonPropertyName("destinyActivity")]
    public Trending.TrendingEntryDestinyActivity? DestinyActivity { get; set; }

    [JsonPropertyName("destinyRitual")]
    public Trending.TrendingEntryDestinyRitual? DestinyRitual { get; set; }

    [JsonPropertyName("creation")]
    public Trending.TrendingEntryCommunityCreation? Creation { get; set; }
}
