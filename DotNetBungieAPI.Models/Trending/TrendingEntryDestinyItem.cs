namespace DotNetBungieAPI.Models.Trending;

public sealed class TrendingEntryDestinyItem
{
    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; init; }
}
