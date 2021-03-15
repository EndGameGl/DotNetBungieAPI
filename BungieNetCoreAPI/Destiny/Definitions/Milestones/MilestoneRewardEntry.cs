using NetBungieAPI.Destiny.Definitions.Vendors;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.Milestones
{
    public class MilestoneRewardEntry : IDeepEquatable<MilestoneRewardEntry>
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        /// <summary>
        /// The items you will get as rewards, and how much of it you'll get.
        /// </summary>
        public ReadOnlyCollection<MilestoneItem> Items { get; }
        /// <summary>
        /// If you want to follow BNet's ordering of these rewards, use this number within a given category to order the rewards.
        /// </summary>
        public int Order { get; }
        /// <summary>
        /// The identifier for this reward entry. Runtime data will refer to reward entries by this hash. Only guaranteed unique within the specific Milestone.
        /// </summary>
        public uint RewardEntryHash { get; }
        /// <summary>
        /// The string identifier, if you care about it. Only guaranteed unique within the specific Milestone.
        /// </summary>
        public string RewardEntryIdentifier { get; }
        public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; }

        [JsonConstructor]
        internal MilestoneRewardEntry(DestinyDefinitionDisplayProperties displayProperties, MilestoneItem[] items, int order, uint rewardEntryHash, 
            string rewardEntryIdentifier, uint? vendorHash)
        {
            DisplayProperties = displayProperties;
            Items = items.AsReadOnlyOrEmpty();
            Order = order;
            RewardEntryHash = rewardEntryHash;
            RewardEntryIdentifier = rewardEntryIdentifier;
            Vendor = new DefinitionHashPointer<DestinyVendorDefinition>(vendorHash, DefinitionsEnum.DestinyVendorDefinition);
        }

        public bool DeepEquals(MilestoneRewardEntry other)
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
