namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.EnergyTypes;

/// <summary>
///     Represents types of Energy that can be used for costs and payments related to Armor 2.0 mods.
/// </summary>
public class DestinyEnergyTypeDefinition
{
    /// <summary>
    ///     The description of the energy type, icon etc...
    /// </summary>
    [JsonPropertyName("displayProperties")]
    public object DisplayProperties { get; set; }

    /// <summary>
    ///     A variant of the icon that is transparent and colorless.
    /// </summary>
    [JsonPropertyName("transparentIconPath")]
    public string TransparentIconPath { get; set; }

    /// <summary>
    ///     If TRUE, the game shows this Energy type's icon. Otherwise, it doesn't. Whether you show it or not is up to you.
    /// </summary>
    [JsonPropertyName("showIcon")]
    public bool ShowIcon { get; set; }

    /// <summary>
    ///     We have an enumeration for Energy types for quick reference. This is the current definition's Energy type enum value.
    /// </summary>
    [JsonPropertyName("enumValue")]
    public Destiny.DestinyEnergyType EnumValue { get; set; }

    /// <summary>
    ///     If this Energy Type can be used for determining the Type of Energy that an item can consume, this is the hash for the DestinyInvestmentStatDefinition that represents the stat which holds the Capacity for that energy type. (Note that this is optional because "Any" is a valid cost, but not valid for Capacity - an Armor must have a specific Energy Type for determining the energy type that the Armor is restricted to use)
    /// </summary>
    [JsonPropertyName("capacityStatHash")]
    public uint CapacityStatHash { get; set; }

    /// <summary>
    ///     If this Energy Type can be used as a cost to pay for socketing Armor 2.0 items, this is the hash for the DestinyInvestmentStatDefinition that stores the plug's raw cost.
    /// </summary>
    [JsonPropertyName("costStatHash")]
    public uint CostStatHash { get; set; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; set; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; set; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool Redacted { get; set; }
}
