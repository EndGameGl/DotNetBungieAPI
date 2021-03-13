using NetBungieApi.Attributes;
using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.ItemTierTypes
{
    /// <summary>
    /// Defines the tier type of an item. Mostly this provides human readable properties for types like Common, Rare, etc...
    /// <para/>
    /// It also provides some base data for infusion that could be useful.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyItemTierTypeDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyItemTierTypeDefinition : IDestinyDefinition, IDeepEquatable<DestinyItemTierTypeDefinition>
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public ItemTierTypeInfusionProcess InfusionProcess { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyItemTierTypeDefinition(DestinyDefinitionDisplayProperties displayProperties, ItemTierTypeInfusionProcess infusionProcess,
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
