using NetBungieAPI.Attributes;
using NetBungieAPI.Destiny.Definitions.TraitCategories;
using Newtonsoft.Json;

namespace NetBungieAPI.Models.Destiny.Definitions.Traits
{
    [DestinyDefinition(DefinitionsEnum.DestinyTraitDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyTraitDefinition : IDestinyDefinition, IDeepEquatable<DestinyTraitDefinition>
    {
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        public string TraitCategoryId { get; init; }
        public DefinitionHashPointer<DestinyTraitCategoryDefinition> TraitCategory { get; init; }
        public bool Blacklisted { get; init; }
        public uint Hash { get; init; }
        public int Index { get; init; }
        public bool Redacted { get; init; }

        [JsonConstructor]
        internal DestinyTraitDefinition(DestinyDisplayPropertiesDefinition displayProperties, uint traitCategoryHash, string traitCategoryId,
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
