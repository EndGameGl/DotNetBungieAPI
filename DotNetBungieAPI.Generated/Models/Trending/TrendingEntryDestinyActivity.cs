namespace DotNetBungieAPI.Generated.Models.Trending;

public class TrendingEntryDestinyActivity
{
    [JsonPropertyName("activityHash")]
    public uint ActivityHash { get; set; }

    [JsonPropertyName("status")]
    public Destiny.Activities.DestinyPublicActivityStatus? Status { get; set; }
}
