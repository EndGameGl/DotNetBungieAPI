using NetBungieAPI.Attributes;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.Artifacts
{
    /// <summary>
    /// Represents known info about a Destiny Artifact.
    /// <para/>
    /// We cannot guarantee that artifact definitions will be immutable between seasons - in fact, we've been told that they will be replaced between seasons. But this definition is built both to minimize the amount of lookups for related data that have to occur, and is built in hope that, if this plan changes, we will be able to accommodate it more easily.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyArtifactDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyArtifactDefinition : IDestinyDefinition, IDeepEquatable<DestinyArtifactDefinition>
    {
        /// <summary>
        /// Any basic display info we know about the Artifact. Currently sourced from a related inventory item, but the source of this data is subject to change.
        /// </summary>
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        /// <summary>
        /// Any Tier/Rank data related to this artifact, listed in display order. Currently sourced from a Vendor, but this source is subject to change.
        /// </summary>
        public ReadOnlyCollection<ArtifactTierEntry> Tiers { get; }
        /// <summary>
        /// Any Geometry/3D info we know about the Artifact. Currently sourced from a related inventory item's gearset information, but the source of this data is subject to change.
        /// </summary>
        public ArtifactTranslationBlock TranslationBlock { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyArtifactDefinition(DestinyDefinitionDisplayProperties displayProperties, ArtifactTierEntry[] tiers, ArtifactTranslationBlock translationBlock,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            Tiers = tiers.AsReadOnlyOrEmpty();
            TranslationBlock = translationBlock;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }

        public bool DeepEquals(DestinyArtifactDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   Tiers.DeepEqualsReadOnlyCollections(other.Tiers) &&
                   TranslationBlock.DeepEquals(other.TranslationBlock) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }

        public void MapValues()
        {
            foreach (var tier in Tiers)
            {
                foreach (var tierItems in tier.Items)
                {
                    tierItems.Item.TryMapValue();
                }
            }
        }
    }
}
