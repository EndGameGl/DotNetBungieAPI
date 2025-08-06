namespace DotNetBungieAPI.Models.Destiny;

/// <summary>
///     Represents the stats and item state if applicable for progression reward items with socket overrides
/// </summary>
public sealed class DestinyProgressionRewardItemSocketOverrideState
{
    /// <summary>
    ///     Information about the computed stats from socket and plug overrides for this progression, if there is any data for it.
    /// </summary>
    [JsonPropertyName("rewardItemStats")]
    public Dictionary<DefinitionHashPointer<Destiny.Definitions.DestinyStatDefinition>, Destiny.DestinyStat>? RewardItemStats { get; init; }

    /// <summary>
    ///     Information about the item state, specifically deepsight if there is any data for it
    /// </summary>
    [JsonPropertyName("itemState")]
    public Destiny.ItemState ItemState { get; init; }
}
