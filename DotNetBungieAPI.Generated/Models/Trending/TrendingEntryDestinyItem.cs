namespace DotNetBungieAPI.Generated.Models.Trending;

public class TrendingEntryDestinyItem : IDeepEquatable<TrendingEntryDestinyItem>
{
    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; set; }

    public bool DeepEquals(TrendingEntryDestinyItem? other)
    {
        return other is not null &&
               ItemHash == other.ItemHash;
    }
}