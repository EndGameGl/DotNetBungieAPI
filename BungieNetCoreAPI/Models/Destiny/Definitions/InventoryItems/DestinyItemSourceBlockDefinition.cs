using NetBungieAPI.Models.Destiny.Definitions.RewardSources;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// Data about an item's "sources": ways that the item can be obtained.
    /// </summary>
    public sealed record DestinyItemSourceBlockDefinition : IDeepEquatable<DestinyItemSourceBlockDefinition>
    {
        [JsonPropertyName("sourceHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyRewardSourceDefinition>> RewardSources { get; init; } = Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyRewardSourceDefinition>>();
        [JsonPropertyName("sources")]
        public ReadOnlyCollection<DestinyItemSourceDefinition> Sources { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyItemSourceDefinition>();
        [JsonPropertyName("exclusive")]
        public BungieMembershipType ExclusiveTo { get; init; }
        [JsonPropertyName("vendorSources")]
        public ReadOnlyCollection<DestinyItemVendorSourceReference> VendorSources { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyItemVendorSourceReference>();

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
