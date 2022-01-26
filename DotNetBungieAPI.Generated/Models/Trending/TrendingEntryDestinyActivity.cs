namespace DotNetBungieAPI.Generated.Models.Trending;

public class TrendingEntryDestinyActivity : IDeepEquatable<TrendingEntryDestinyActivity>
{
    [JsonPropertyName("activityHash")]
    public uint ActivityHash { get; set; }

    [JsonPropertyName("status")]
    public Destiny.Activities.DestinyPublicActivityStatus Status { get; set; }

    public bool DeepEquals(TrendingEntryDestinyActivity? other)
    {
        return other is not null &&
               ActivityHash == other.ActivityHash &&
               (Status is not null ? Status.DeepEquals(other.Status) : other.Status is null);
    }
}