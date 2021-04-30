using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny.Definitions.Common;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.EnergyTypes
{
    /// <summary>
    /// Represents types of Energy that can be used for costs and payments related to Armor 2.0 mods.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyEnergyTypeDefinition)]
    public sealed record DestinyEnergyTypeDefinition : IDestinyDefinition, IDeepEquatable<DestinyEnergyTypeDefinition>
    {
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        [JsonPropertyName("transparentIconPath")]
        public string TransparentIconPath { get; init; }
        [JsonPropertyName("showIcon")]
        public bool ShowIcon { get; init; }
        [JsonPropertyName("enumValue")]
        public DestinyEnergyType EnumValue { get; init; }
        /// <summary>
        /// If this Energy Type can be used for determining the Type of Energy that an item can consume, this is the hash for the DestinyInvestmentStatDefinition that represents the stat which holds the Capacity for that energy type. (Note that this is optional because "Any" is a valid cost, but not valid for Capacity - an Armor must have a specific Energy Type for determining the energy type that the Armor is restricted to use)
        /// </summary>
        [JsonPropertyName("capacityStatHash")]
        public uint? CapacityStatHash { get; init; }
        /// <summary>
        /// If this Energy Type can be used as a cost to pay for socketing Armor 2.0 items, this is the hash for the DestinyInvestmentStatDefinition that stores the plug's raw cost.
        /// </summary>
        [JsonPropertyName("costStatHash")]
        public uint CostStatHash { get; init; }
        [JsonPropertyName("blacklisted")]
        public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")]
        public uint Hash { get; init; }
        [JsonPropertyName("index")]
        public int Index { get; init; }
        [JsonPropertyName("redacted")]
        public bool Redacted { get; init; }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }

        public bool DeepEquals(DestinyEnergyTypeDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   CapacityStatHash == other.CapacityStatHash &&
                   CostStatHash == other.CostStatHash &&
                   EnumValue == other.EnumValue &&
                   ShowIcon == other.ShowIcon &&
                   TransparentIconPath == other.TransparentIconPath &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }

        public void MapValues()
        {
            return;
        }
    }
}
