using DotNetBungieAPI.Models.Destiny.Definitions.Stats;
using DotNetBungieAPI.Models.Destiny.Items;

namespace DotNetBungieAPI.Models.Destiny.Progressions;

/// <summary>
///     Represents the stats and item state if applicable for progression reward items with socket overrides
/// </summary>
public sealed record DestinyProgressionRewardItemSocketOverrideState
{
    /// <summary>
    ///     Information about the computed stats from socket and plug overrides for this progression, if there is any data for it.
    /// </summary>
    [JsonPropertyName("rewardItemStats")]
    public ReadOnlyDictionary<
        DefinitionHashPointer<DestinyStatDefinition>,
        DestinyStat
    > RewardItemStats { get; init; } =
        ReadOnlyDictionary<DefinitionHashPointer<DestinyStatDefinition>, DestinyStat>.Empty;

    /// <summary>
    ///     Information about the item state, specifically deepsight if there is any data for it
    /// </summary>
    [JsonPropertyName("itemState")]
    public ItemState ItemState { get; init; }
}
