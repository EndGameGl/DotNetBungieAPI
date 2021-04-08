using NetBungieAPI.Attributes;
using NetBungieAPI.Destiny.Definitions.Traits;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Models.Destiny.Definitions.TraitCategories
{
    [DestinyDefinition(DefinitionsEnum.DestinyTraitCategoryDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyTraitCategoryDefinition : IDestinyDefinition, IDeepEquatable<DestinyTraitCategoryDefinition>
    {
        /// <summary>
        /// String for this trait category
        /// </summary>
        public string TraitCategoryId { get; init; }
        /// <summary>
        /// Traits that are in this category
        /// </summary>
        public ReadOnlyCollection<DefinitionHashPointer<DestinyTraitDefinition>> Traits { get; init; }
        /// <summary>
        /// Possible trait strings for searching in this category
        /// </summary>
        public ReadOnlyCollection<string> TraitIds { get; init; }
        public bool Blacklisted { get; init; }
        public uint Hash { get; init; }
        public int Index { get; init; }
        public bool Redacted { get; init; }


        [JsonConstructor]
        internal DestinyTraitCategoryDefinition(string traitCategoryId, uint[] traitHashes, string[] traitIds, bool blacklisted, uint hash, int index, bool redacted)
        {
            TraitCategoryId = traitCategoryId;
            Traits = traitHashes.DefinitionsAsReadOnlyOrEmpty<DestinyTraitDefinition>(DefinitionsEnum.DestinyTraitDefinition);
            TraitIds = traitIds.AsReadOnlyOrEmpty();
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {TraitCategoryId}";
        }

        public void MapValues()
        {
            foreach (var trait in Traits)
            {
                trait.TryMapValue();
            }
        }

        public bool DeepEquals(DestinyTraitCategoryDefinition other)
        {
            return other != null &&
                   TraitCategoryId == other.TraitCategoryId &&
                   Traits.DeepEqualsReadOnlyCollections(other.Traits) &&
                   TraitIds.DeepEqualsReadOnlySimpleCollection(other.TraitIds) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
    }
}
