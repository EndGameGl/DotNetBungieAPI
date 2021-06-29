using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny.Definitions.Common;

namespace NetBungieAPI.Models.Destiny.Definitions.Artifacts
{
    /// <summary>
    ///     Represents known info about a Destiny Artifact.
    ///     <para />
    ///     We cannot guarantee that artifact definitions will be immutable between seasons - in fact, we've been told that
    ///     they will be replaced between seasons. But this definition is built both to minimize the amount of lookups for
    ///     related data that have to occur, and is built in hope that, if this plan changes, we will be able to accommodate it
    ///     more easily.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyArtifactDefinition)]
    public sealed record DestinyArtifactDefinition : IDestinyDefinition, IDeepEquatable<DestinyArtifactDefinition>
    {
        /// <summary>
        ///     Any basic display info we know about the Artifact. Currently sourced from a related inventory item, but the source
        ///     of this data is subject to change.
        /// </summary>
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

        /// <summary>
        ///     Any Tier/Rank data related to this artifact, listed in display order. Currently sourced from a Vendor, but this
        ///     source is subject to change.
        /// </summary>
        [JsonPropertyName("tiers")]
        public ReadOnlyCollection<DestinyArtifactTierDefinition> Tiers { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyArtifactTierDefinition>();

        /// <summary>
        ///     Any Geometry/3D info we know about the Artifact. Currently sourced from a related inventory item's gearset
        ///     information, but the source of this data is subject to change.
        /// </summary>
        [JsonPropertyName("translationBlock")]
        public DestinyItemTranslationBlockDefinition TranslationBlock { get; init; }

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

        [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }

        [JsonPropertyName("hash")] public uint Hash { get; init; }

        [JsonPropertyName("index")] public int Index { get; init; }

        [JsonPropertyName("redacted")] public bool Redacted { get; init; }

        public void MapValues()
        {
            foreach (var tier in Tiers)
            foreach (var tierItems in tier.Items)
                tierItems.Item.TryMapValue();
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}