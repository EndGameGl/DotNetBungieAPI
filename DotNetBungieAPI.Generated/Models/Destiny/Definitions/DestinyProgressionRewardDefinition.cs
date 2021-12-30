using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Inventory Items can reward progression when actions are performed on them. A common example of this in Destiny 1 was Bounties, which would reward Experience on your Character and the like when you completed the bounty.
/// <para />
///     Note that this maps to a DestinyProgressionMappingDefinition, and *not* a DestinyProgressionDefinition directly. This is apparently so that multiple progressions can be granted progression points/experience at the same time.
/// </summary>
public sealed class DestinyProgressionRewardDefinition
{

    /// <summary>
    ///     The hash identifier of the DestinyProgressionMappingDefinition that contains the progressions for which experience should be applied.
    /// </summary>
    [JsonPropertyName("progressionMappingHash")]
    public uint ProgressionMappingHash { get; init; }

    /// <summary>
    ///     The amount of experience to give to each of the mapped progressions.
    /// </summary>
    [JsonPropertyName("amount")]
    public int Amount { get; init; }

    /// <summary>
    ///     If true, the game's internal mechanisms to throttle progression should be applied.
    /// </summary>
    [JsonPropertyName("applyThrottles")]
    public bool ApplyThrottles { get; init; }
}
