using DotNetBungieAPI.Models.Destiny.Definitions.RewardSources;

namespace DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems
{
    /// <summary>
    ///     Data about an item's "sources": ways that the item can be obtained.
    /// </summary>
    public sealed record DestinyItemSourceBlockDefinition : IDeepEquatable<DestinyItemSourceBlockDefinition>
    {
        /// <summary>
        ///     DestinyRewardSourceDefinitions for Reward Sources that hint where the item can be found
        /// </summary>
        [JsonPropertyName("sourceHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyRewardSourceDefinition>> RewardSources { get; init; } =
            ReadOnlyCollections<DefinitionHashPointer<DestinyRewardSourceDefinition>>.Empty;

        /// <summary>
        ///     A collection of details about the stats that were computed for the ways we found that the item could be spawned.
        /// </summary>
        [JsonPropertyName("sources")]
        public ReadOnlyCollection<DestinyItemSourceDefinition> Sources { get; init; } =
            ReadOnlyCollections<DestinyItemSourceDefinition>.Empty;

        /// <summary>
        ///     If we found that this item is exclusive to a specific platform, this will be set to the BungieMembershipType
        ///     enumeration that matches that platform.
        /// </summary>
        [JsonPropertyName("exclusive")]
        public BungieMembershipType ExclusiveTo { get; init; }

        /// <summary>
        ///     A denormalized reference back to vendors that potentially sell this item.
        /// </summary>
        [JsonPropertyName("vendorSources")]
        public ReadOnlyCollection<DestinyItemVendorSourceReference> VendorSources { get; init; } =
            ReadOnlyCollections<DestinyItemVendorSourceReference>.Empty;

        public bool DeepEquals(DestinyItemSourceBlockDefinition other)
        {
            return other != null &&
                   RewardSources.DeepEqualsReadOnlyCollections(other.RewardSources) &&
                   Sources.DeepEqualsReadOnlyCollections(other.Sources) &&
                   ExclusiveTo == other.ExclusiveTo &&
                   VendorSources.DeepEqualsReadOnlyCollections(other.VendorSources);
        }
    }
}