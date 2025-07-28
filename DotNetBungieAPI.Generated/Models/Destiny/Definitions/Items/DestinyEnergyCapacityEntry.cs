namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Items;

/// <summary>
///     Items can have Energy Capacity, and plugs can provide that capacity such as on a piece of Armor in Armor 2.0. This is how much "Energy" can be spent on activating plugs for this item.
/// </summary>
public class DestinyEnergyCapacityEntry
{
    /// <summary>
    ///     How much energy capacity this plug provides.
    /// </summary>
    [JsonPropertyName("capacityValue")]
    public int CapacityValue { get; set; }

    /// <summary>
    ///     Energy provided by a plug is always of a specific type - this is the hash identifier for the energy type for which it provides Capacity.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.EnergyTypes.DestinyEnergyTypeDefinition>("Destiny.Definitions.EnergyTypes.DestinyEnergyTypeDefinition")]
    [JsonPropertyName("energyTypeHash")]
    public uint EnergyTypeHash { get; set; }

    /// <summary>
    ///     The Energy Type for this energy capacity, in enum form for easy use.
    /// </summary>
    [JsonPropertyName("energyType")]
    public Destiny.DestinyEnergyType EnergyType { get; set; }
}
