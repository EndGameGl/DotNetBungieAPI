using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     If an item has a related gearset, this is the list of items in that set, and an unlock expression that evaluates to a number representing the progress toward gearset completion (a very rare use for unlock expressions!)
/// </summary>
public sealed class DestinyItemGearsetBlockDefinition
{

    /// <summary>
    ///     The maximum possible number of items that can be collected.
    /// </summary>
    [JsonPropertyName("trackingValueMax")]
    public int TrackingValueMax { get; init; }

    /// <summary>
    ///     The list of hashes for items in the gearset. Use them to look up DestinyInventoryItemDefinition entries for the items in the set.
    /// </summary>
    [JsonPropertyName("itemList")]
    public List<uint> ItemList { get; init; }
}
