namespace DotNetBungieAPI.Models.Trending;

public sealed class TrendingEntryDestinyActivity
{
    [JsonPropertyName("activityHash")]
    public uint ActivityHash { get; init; }

    [JsonPropertyName("status")]
    public Destiny.Activities.DestinyPublicActivityStatus? Status { get; init; }
}
