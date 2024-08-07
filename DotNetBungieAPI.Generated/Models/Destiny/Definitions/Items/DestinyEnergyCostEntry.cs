namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Items;

/// <summary>
///     Some plugs cost Energy, which is a stat on the item that can be increased by other plugs (that, at least in Armor 2.0, have a "masterworks-like" mechanic for upgrading). If a plug has costs, the details of that cost are defined here.
/// </summary>
public class DestinyEnergyCostEntry
{
    /// <summary>
    ///     The Energy cost for inserting this plug.
    /// </summary>
    [JsonPropertyName("energyCost")]
    public int? EnergyCost { get; set; }

    /// <summary>
    ///     The type of energy that this plug costs, as a reference to the DestinyEnergyTypeDefinition of the energy type.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.EnergyTypes.DestinyEnergyTypeDefinition>("Destiny.Definitions.EnergyTypes.DestinyEnergyTypeDefinition")]
    [JsonPropertyName("energyTypeHash")]
    public uint? EnergyTypeHash { get; set; }

    /// <summary>
    ///     The type of energy that this plug costs, in enum form.
    /// </summary>
    [JsonPropertyName("energyType")]
    public Destiny.DestinyEnergyType? EnergyType { get; set; }
}
