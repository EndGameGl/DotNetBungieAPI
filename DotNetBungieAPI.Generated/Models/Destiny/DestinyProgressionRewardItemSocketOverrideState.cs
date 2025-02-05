namespace DotNetBungieAPI.Generated.Models.Destiny;

/// <summary>
///     Represents the stats and item state if applicable for progression reward items with socket overrides
/// </summary>
public class DestinyProgressionRewardItemSocketOverrideState
{
    /// <summary>
    ///     Information about the computed stats from socket and plug overrides for this progression, if there is any data for it.
    /// </summary>
    [Destiny2DefinitionDictionaryKey<Destiny.Definitions.DestinyStatDefinition>("Destiny.Definitions.DestinyStatDefinition")]
    [JsonPropertyName("rewardItemStats")]
    public Dictionary<uint, Destiny.DestinyStat> RewardItemStats { get; set; }

    /// <summary>
    ///     Information about the item state, specifically deepsight if there is any data for it
    /// </summary>
    [JsonPropertyName("itemState")]
    public Destiny.ItemState? ItemState { get; set; }
}
