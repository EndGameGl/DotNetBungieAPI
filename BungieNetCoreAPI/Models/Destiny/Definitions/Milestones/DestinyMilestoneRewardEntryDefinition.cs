using NetBungieAPI.Models.Destiny.Definitions.Common;
using NetBungieAPI.Models.Destiny.Definitions.Vendors;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Milestones
{
    public sealed record DestinyMilestoneRewardEntryDefinition : IDeepEquatable<DestinyMilestoneRewardEntryDefinition>
    {
        /// <summary>
        /// The identifier for this reward entry. Runtime data will refer to reward entries by this hash. Only guaranteed unique within the specific Milestone.
        /// </summary>
        [JsonPropertyName("rewardEntryHash")]
        public uint RewardEntryHash { get; init; }
        /// <summary>
        /// The string identifier, if you care about it. Only guaranteed unique within the specific Milestone.
        /// </summary>
        [JsonPropertyName("rewardEntryIdentifier")]
        public string RewardEntryIdentifier { get; init; }
        /// <summary>
        /// The items you will get as rewards, and how much of it you'll get.
        /// </summary>
        [JsonPropertyName("items")]
        public ReadOnlyCollection<DestinyItemQuantity> Items { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyItemQuantity>();
        [JsonPropertyName("vendorHash")]
        public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; init; } = DefinitionHashPointer<DestinyVendorDefinition>.Empty;
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        /// <summary>
        /// If you want to follow BNet's ordering of these rewards, use this number within a given category to order the rewards.
        /// </summary>
        [JsonPropertyName("order")]
        public int Order { get; init; }

        public bool DeepEquals(DestinyMilestoneRewardEntryDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   Items.DeepEqualsReadOnlyCollections(other.Items) &&
                   Order == other.Order &&
                   RewardEntryHash == other.RewardEntryHash &&
                   RewardEntryIdentifier == other.RewardEntryIdentifier &&
                   Vendor.DeepEquals(other.Vendor);
        }
    }
}
