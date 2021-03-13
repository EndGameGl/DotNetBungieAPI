using NetBungieApi.Attributes;
using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.EnergyTypes
{
    /// <summary>
    /// Represents types of Energy that can be used for costs and payments related to Armor 2.0 mods.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyEnergyTypeDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyEnergyTypeDefinition : IDestinyDefinition, IDeepEquatable<DestinyEnergyTypeDefinition>
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        /// <summary>
        /// If this Energy Type can be used for determining the Type of Energy that an item can consume, this is the hash for the DestinyInvestmentStatDefinition that represents the stat which holds the Capacity for that energy type. (Note that this is optional because "Any" is a valid cost, but not valid for Capacity - an Armor must have a specific Energy Type for determining the energy type that the Armor is restricted to use)
        /// </summary>
        public uint? CapacityStatHash { get; }
        /// <summary>
        /// If this Energy Type can be used as a cost to pay for socketing Armor 2.0 items, this is the hash for the DestinyInvestmentStatDefinition that stores the plug's raw cost.
        /// </summary>
        public uint CostStatHash { get; }
        public DestinyEnergyType EnumValue { get; }
        public bool ShowIcon { get; }
        public string TransparentIconPath { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyEnergyTypeDefinition(DestinyDefinitionDisplayProperties displayProperties, uint? capacityStatHash, uint costStatHash, DestinyEnergyType enumValue,
            bool showIcon, string transparentIconPath, bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            CapacityStatHash = capacityStatHash;
            CostStatHash = costStatHash;
            EnumValue = enumValue;
            ShowIcon = showIcon;
            TransparentIconPath = transparentIconPath;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }
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
