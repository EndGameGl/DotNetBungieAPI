namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Items;

/// <summary>
///     Items can have Energy Capacity, and plugs can provide that capacity such as on a piece of Armor in Armor 2.0. This is how much "Energy" can be spent on activating plugs for this item.
/// </summary>
public sealed class DestinyEnergyCapacityEntry
{

    /// <summary>
    ///     How much energy capacity this plug provides.
    /// </summary>
    [JsonPropertyName("capacityValue")]
    public int CapacityValue { get; init; }

    /// <summary>
    ///     Energy provided by a plug is always of a specific type - this is the hash identifier for the energy type for which it provides Capacity.
    /// </summary>
    [JsonPropertyName("energyTypeHash")]
    public uint EnergyTypeHash { get; init; } // DestinyEnergyTypeDefinition

    /// <summary>
    ///     The Energy Type for this energy capacity, in enum form for easy use.
    /// </summary>
    [JsonPropertyName("energyType")]
    public Destiny.DestinyEnergyType EnergyType { get; init; }
}
