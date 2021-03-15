using NetBungieAPI.Bungie;
using NetBungieAPI.Destiny.Definitions.RewardSources;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// Data about an item's "sources": ways that the item can be obtained.
    /// </summary>
    public class InventoryItemSourceBlock : IDeepEquatable<InventoryItemSourceBlock>
    {
        public ReadOnlyCollection<DefinitionHashPointer<DestinyRewardSourceDefinition>> RewardSources { get; }
        public ReadOnlyCollection<InventoryItemSourceBlockSource> Sources { get; }
        public BungieMembershipType ExclusiveTo { get; }
        public ReadOnlyCollection<InventoryItemSourceBlockVendorSource> VendorSources { get; }

        [JsonConstructor]
        internal InventoryItemSourceBlock(uint[] sourceHashes, BungieMembershipType exclusive, InventoryItemSourceBlockSource[] sources,
            InventoryItemSourceBlockVendorSource[] vendorSources)
        {
            RewardSources = sourceHashes.DefinitionsAsReadOnlyOrEmpty<DestinyRewardSourceDefinition>(DefinitionsEnum.DestinyRewardSourceDefinition);
            ExclusiveTo = exclusive;
            Sources = sources.AsReadOnlyOrEmpty();
            VendorSources = vendorSources.AsReadOnlyOrEmpty();
        }

        public bool DeepEquals(InventoryItemSourceBlock other)
        {
            return other != null &&
                   RewardSources.DeepEqualsReadOnlyCollections(other.RewardSources) &&
                   Sources.DeepEqualsReadOnlyCollections(other.Sources) &&
                   ExclusiveTo == other.ExclusiveTo &&
                   VendorSources.DeepEqualsReadOnlyCollections(other.VendorSources);
        }
    }
}
