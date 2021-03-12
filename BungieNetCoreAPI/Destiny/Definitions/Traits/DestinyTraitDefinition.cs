using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.TraitCategories;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Traits
{
    [DestinyDefinition(DefinitionsEnum.DestinyTraitDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyTraitDefinition : IDestinyDefinition, IDeepEquatable<DestinyTraitDefinition>
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public string TraitCategoryId { get; }
        public DefinitionHashPointer<DestinyTraitCategoryDefinition> TraitCategory { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyTraitDefinition(DestinyDefinitionDisplayProperties displayProperties, uint traitCategoryHash, string traitCategoryId,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            TraitCategory = new DefinitionHashPointer<DestinyTraitCategoryDefinition>(traitCategoryHash, DefinitionsEnum.DestinyTraitCategoryDefinition);
            TraitCategoryId = traitCategoryId;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }

        public void MapValues()
        {
            TraitCategory.TryMapValue();
        }

        public bool DeepEquals(DestinyTraitDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   TraitCategoryId == other.TraitCategoryId &&
                   TraitCategory.DeepEquals(other.TraitCategory) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
    }
}
