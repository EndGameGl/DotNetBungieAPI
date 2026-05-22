namespace DotNetBungieAPI.Models.Destiny.Definitions;

public sealed class DestinyActivitySelectableSkullCollections
{
    [JsonPropertyName("selectableSkullCollectionHash")]
    public uint SelectableSkullCollectionHash { get; init; }

    [JsonPropertyName("minimumTierRank")]
    public int MinimumTierRank { get; init; }

    [JsonPropertyName("maximumTierRank")]
    public int MaximumTierRank { get; init; }
}
