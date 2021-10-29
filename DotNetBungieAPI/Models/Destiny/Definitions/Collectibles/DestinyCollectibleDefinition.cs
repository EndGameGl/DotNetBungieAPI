using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Attributes;
using DotNetBungieAPI.Defaults;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;
using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using DotNetBungieAPI.Models.Destiny.Definitions.PresentationNodes;
using DotNetBungieAPI.Models.Destiny.Definitions.Traits;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Collectibles
{
    [DestinyDefinition(DefinitionsEnum.DestinyCollectibleDefinition)]
    public sealed record DestinyCollectibleDefinition : IDestinyDefinition, IDeepEquatable<DestinyCollectibleDefinition>
    {
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

        /// <summary>
        ///     Indicates whether the state of this Collectible is determined on a per-character or on an account-wide basis.
        /// </summary>
        [JsonPropertyName("scope")]
        public DestinyScope Scope { get; init; }

        /// <summary>
        ///     A human readable string for a hint about how to acquire the item.
        /// </summary>
        [JsonPropertyName("sourceString")]
        public string SourceString { get; init; }

        /// <summary>
        ///     This is a hash identifier we are building on the BNet side in an attempt to let people group collectibles by
        ///     similar sources.
        /// </summary>
        [JsonPropertyName("sourceHash")]
        public uint? SourceHash { get; init; }

        [JsonPropertyName("itemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; init; } =
            DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

        [JsonPropertyName("acquisitionInfo")] public DestinyCollectibleAcquisitionBlock AcquisitionInfo { get; init; }
        [JsonPropertyName("stateInfo")] public DestinyCollectibleStateBlock StateInfo { get; init; }
        [JsonPropertyName("presentationInfo")] public DestinyPresentationChildBlock PresentationInfo { get; init; }

        [JsonPropertyName("presentationNodeType")]
        public DestinyPresentationNodeType PresentationNodeType { get; init; }

        [JsonPropertyName("traitIds")]
        public ReadOnlyCollection<string> TraitIds { get; init; } = ReadOnlyCollections<string>.Empty;

        [JsonPropertyName("traitHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyTraitDefinition>> Traits { get; init; } =
            ReadOnlyCollections<DefinitionHashPointer<DestinyTraitDefinition>>.Empty;

        /// <summary>
        ///     A quick reference to presentation nodes that have this node as a child. Presentation nodes can be parented under
        ///     multiple parents.
        /// </summary>
        [JsonPropertyName("parentNodeHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyPresentationNodeDefinition>> ParentNodes { get; init; } =
            ReadOnlyCollections<DefinitionHashPointer<DestinyPresentationNodeDefinition>>.Empty;

        public bool DeepEquals(DestinyCollectibleDefinition other)
        {
            return other != null &&
                   AcquisitionInfo.DeepEquals(other.AcquisitionInfo) &&
                   (PresentationInfo != null
                       ? PresentationInfo.DeepEquals(other.PresentationInfo)
                       : other.PresentationInfo == null) &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   Item.DeepEquals(other.Item) &&
                   ParentNodes.DeepEqualsReadOnlyCollections(other.ParentNodes) &&
                   PresentationNodeType == other.PresentationNodeType &&
                   Scope == other.Scope &&
                   SourceHash == other.SourceHash &&
                   SourceString == other.SourceString &&
                   StateInfo.DeepEquals(other.StateInfo) &&
                   Traits.DeepEqualsReadOnlyCollections(other.Traits) &&
                   TraitIds.DeepEqualsReadOnlySimpleCollection(other.TraitIds) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }

        public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyCollectibleDefinition;
        [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")] public uint Hash { get; init; }
        [JsonPropertyName("index")] public int Index { get; init; }
        [JsonPropertyName("redacted")] public bool Redacted { get; init; }

        public void MapValues()
        {
            AcquisitionInfo?.AcquireMaterialRequirement.TryMapValue();
            AcquisitionInfo?.AcquireTimestampUnlockValue.TryMapValue();
            if (PresentationInfo != null)
                foreach (var node in PresentationInfo.ParentPresentationNodes)
                    node.TryMapValue();

            Item.TryMapValue();
            foreach (var node in ParentNodes) node.TryMapValue();

            StateInfo?.ObscuredOverrideItem.TryMapValue();
            foreach (var trait in Traits) trait.TryMapValue();
        }

        public void SetPointerLocales(BungieLocales locale)
        {
            AcquisitionInfo?.AcquireMaterialRequirement.SetLocale(locale);
            AcquisitionInfo?.AcquireTimestampUnlockValue.SetLocale(locale);
            if (PresentationInfo != null)
                foreach (var node in PresentationInfo.ParentPresentationNodes)
                    node.SetLocale(locale);

            Item.SetLocale(locale);
            foreach (var node in ParentNodes) node.SetLocale(locale);

            StateInfo?.ObscuredOverrideItem.SetLocale(locale);
            foreach (var trait in Traits) trait.SetLocale(locale);
        }
    }
}