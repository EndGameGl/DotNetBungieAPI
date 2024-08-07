﻿using DotNetBungieAPI.Models.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;
using DotNetBungieAPI.Models.Destiny.Definitions.Stats;

namespace DotNetBungieAPI.Models.Destiny.Definitions.EnergyTypes;

/// <summary>
///     Represents types of Energy that can be used for costs and payments related to Armor 2.0 mods.
/// </summary>
[DestinyDefinition(DefinitionsEnum.DestinyEnergyTypeDefinition)]
public sealed record DestinyEnergyTypeDefinition
    : IDestinyDefinition,
        IDisplayProperties,
        IDeepEquatable<DestinyEnergyTypeDefinition>
{
    /// <summary>
    ///     The description of the energy type, icon etc...
    /// </summary>
    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    /// <summary>
    ///     A variant of the icon that is transparent and colorless.
    /// </summary>
    [JsonPropertyName("transparentIconPath")]
    public BungieNetResource TransparentIconPath { get; init; }

    /// <summary>
    ///     If TRUE, the game shows this Energy type's icon. Otherwise, it doesn't. Whether you show it or not is up to you.
    /// </summary>
    [JsonPropertyName("showIcon")]
    public bool ShowIcon { get; init; }

    /// <summary>
    ///     We have an enumeration for Energy types for quick reference. This is the current definition's Energy type enum
    ///     value
    /// </summary>
    [JsonPropertyName("enumValue")]
    public DestinyEnergyType EnumValue { get; init; }

    /// <summary>
    ///     If this Energy Type can be used for determining the Type of Energy that an item can consume, this is the hash for
    ///     the DestinyInvestmentStatDefinition that represents the stat which holds the Capacity for that energy type. (Note
    ///     that this is optional because "Any" is a valid cost, but not valid for Capacity - an Armor must have a specific
    ///     Energy Type for determining the energy type that the Armor is restricted to use)
    /// </summary>
    [JsonPropertyName("capacityStatHash")]
    public DefinitionHashPointer<DestinyStatDefinition> CapacityStat { get; init; } =
        DefinitionHashPointer<DestinyStatDefinition>.Empty;

    /// <summary>
    ///     If this Energy Type can be used as a cost to pay for socketing Armor 2.0 items, this is the hash for the
    ///     DestinyInvestmentStatDefinition that stores the plug's raw cost.
    /// </summary>
    [JsonPropertyName("costStatHash")]
    public DefinitionHashPointer<DestinyStatDefinition> CostStat { get; init; } =
        DefinitionHashPointer<DestinyStatDefinition>.Empty;

    public bool DeepEquals(DestinyEnergyTypeDefinition other)
    {
        return other != null
            && DisplayProperties.DeepEquals(other.DisplayProperties)
            && CapacityStat.DeepEquals(other.CapacityStat)
            && CostStat.DeepEquals(other.CostStat)
            && EnumValue == other.EnumValue
            && ShowIcon == other.ShowIcon
            && TransparentIconPath == other.TransparentIconPath
            && Blacklisted == other.Blacklisted
            && Hash == other.Hash
            && Index == other.Index
            && Redacted == other.Redacted;
    }

    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyEnergyTypeDefinition;

    [JsonPropertyName("blacklisted")]
    public bool Blacklisted { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
