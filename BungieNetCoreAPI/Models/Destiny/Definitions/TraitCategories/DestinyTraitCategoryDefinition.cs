using NetBungieAPI.Attributes;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Definitions.Traits;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Models.Destiny.Definitions.TraitCategories
{
    [DestinyDefinition(DefinitionsEnum.DestinyTraitCategoryDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public sealed record DestinyTraitCategoryDefinition : IDestinyDefinition, IDeepEquatable<DestinyTraitCategoryDefinition>
    {
        /// <summary>
        /// String for this trait category
        /// </summary>
        [JsonPropertyName("traitCategoryId")]
        public string TraitCategoryId { get; init; }
        /// <summary>
        /// Traits that are in this category
        /// </summary>
        [JsonPropertyName("traitHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyTraitDefinition>> Traits { get; init; } = Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyTraitDefinition>>();
        /// <summary>
        /// Possible trait strings for searching in this category
        /// </summary>
        [JsonPropertyName("traitIds")]
        public ReadOnlyCollection<string> TraitIds { get; init; } = Defaults.EmptyReadOnlyCollection<string>();
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
