using NetBungieAPI.Attributes;
using NetBungieAPI.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Destiny.Definitions.PresentationNodes;
using NetBungieAPI.Destiny.Definitions.Traits;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.Collectibles
{
    [DestinyDefinition(DefinitionsEnum.DestinyCollectibleDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyCollectibleDefinition : IDestinyDefinition, IDeepEquatable<DestinyCollectibleDefinition>
    {
        public CollectibleAcquisitionInfo AcquisitionInfo { get; }
        public CollectiblePresentationInfo PresentationInfo { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; }
        /// <summary>
        /// A quick reference to presentation nodes that have this node as a child. Presentation nodes can be parented under multiple parents.
        /// </summary>
        public ReadOnlyCollection<DefinitionHashPointer<DestinyPresentationNodeDefinition>> ParentNodes { get; }
        public PresentationNodeType PresentationNodeType { get; }
        /// <summary>
        /// Indicates whether the state of this Collectible is determined on a per-character or on an account-wide basis.
        /// </summary>
        public Scope Scope { get; }
        /// <summary>
        /// This is a hash identifier we are building on the BNet side in an attempt to let people group collectibles by similar sources.
        /// </summary>
        public uint? SourceHash { get; }
        /// <summary>
        /// A human readable string for a hint about how to acquire the item.
        /// </summary>
        public string SourceString { get; }
        public CollectibleStateInfo StateInfo { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyTraitDefinition>> Traits { get; }
        public ReadOnlyCollection<string> TraitIds { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyCollectibleDefinition(CollectibleAcquisitionInfo acquisitionInfo, DestinyDefinitionDisplayProperties displayProperties, uint itemHash, uint[] parentNodeHashes,
            PresentationNodeType presentationNodeType, Scope scope, uint? sourceHash, string sourceString, CollectibleStateInfo stateInfo, uint[] traitHashes, string[] traitIds,
            CollectiblePresentationInfo presentationInfo, bool blacklisted, uint hash, int index, bool redacted)
        {
            AcquisitionInfo = acquisitionInfo;
            DisplayProperties = displayProperties;
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            ParentNodes = parentNodeHashes.DefinitionsAsReadOnlyOrEmpty<DestinyPresentationNodeDefinition>(DefinitionsEnum.DestinyPresentationNodeDefinition);
            PresentationNodeType = presentationNodeType;
            Scope = scope;
            SourceHash = sourceHash;
            SourceString = sourceString;
            StateInfo = stateInfo;
            Traits = traitHashes.DefinitionsAsReadOnlyOrEmpty<DestinyTraitDefinition>(DefinitionsEnum.DestinyTraitDefinition);
            TraitIds = traitIds.AsReadOnlyOrEmpty();
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
            PresentationInfo = presentationInfo;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }

        public bool DeepEquals(DestinyCollectibleDefinition other)
        {
            return other != null &&
                   AcquisitionInfo.DeepEquals(other.AcquisitionInfo) &&
                   (PresentationInfo != null ? PresentationInfo.DeepEquals(other.PresentationInfo) : other.PresentationInfo == null) &&
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
        public void MapValues()
        {
            AcquisitionInfo?.AcquireMaterialRequirement.TryMapValue();
            AcquisitionInfo?.AcquireTimestampUnlockValue.TryMapValue();
            if (PresentationInfo != null)
            {
                foreach (var node in PresentationInfo.ParentPresentationNodes)
                {
                    node.TryMapValue();
                }
            }
            Item.TryMapValue();
            foreach (var node in ParentNodes)
            {
                node.TryMapValue();
            }
            StateInfo?.ObscuredOverrideItem.TryMapValue();
            foreach (var trait in Traits)
            {
                trait.TryMapValue();
            }
        }
    }
}
