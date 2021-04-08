using NetBungieAPI.Attributes;
using Newtonsoft.Json;

namespace NetBungieAPI.Models.Destiny.Definitions.ItemTierTypes
{
    /// <summary>
    /// Defines the tier type of an item. Mostly this provides human readable properties for types like Common, Rare, etc...
    /// <para/>
    /// It also provides some base data for infusion that could be useful.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyItemTierTypeDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyItemTierTypeDefinition : IDestinyDefinition, IDeepEquatable<DestinyItemTierTypeDefinition>
    {
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        public ItemTierTypeInfusionProcess InfusionProcess { get; init; }
        public bool Blacklisted { get; init; }
        public uint Hash { get; init; }
        public int Index { get; init; }
        public bool Redacted { get; init; }

        [JsonConstructor]
        internal DestinyItemTierTypeDefinition(DestinyDisplayPropertiesDefinition displayProperties, ItemTierTypeInfusionProcess infusionProcess,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            InfusionProcess = infusionProcess;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }

        public bool DeepEquals(DestinyItemTierTypeDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   InfusionProcess.DeepEquals(other.InfusionProcess) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
        public void MapValues() { return; }
    }
}
