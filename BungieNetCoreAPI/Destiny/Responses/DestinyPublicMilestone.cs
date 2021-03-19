using NetBungieAPI.Destiny.Definitions.Milestones;
using NetBungieAPI.Destiny.Definitions.Vendors;
using NetBungieAPI.Destiny.Profile.Components.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Responses
{
    public class DestinyPublicMilestone
    {
        public DefinitionHashPointer<DestinyMilestoneDefinition> Milestone { get; }
        public ReadOnlyCollection<DestinyPublicMilestoneQuest> AvailableQuests { get; }
        public ReadOnlyCollection<DestinyPublicMilestoneChallengeActivity> Activities { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyVendorDefinition>> VendorPointers { get; }
        public ReadOnlyCollection<DestinyPublicMilestoneVendor> Vendors { get; }
        public DateTime? StartDate { get; }
        public DateTime? EndDate { get; }
        public int Order { get; }

        [JsonConstructor]
        internal DestinyPublicMilestone(uint milestoneHash, DestinyPublicMilestoneQuest[] availableQuests, DestinyPublicMilestoneChallengeActivity[] activities,
             uint[] vendorHashes, DestinyPublicMilestoneVendor[] vendors, DateTime? startDate, DateTime? endDate, int order)
        {
            Milestone = new DefinitionHashPointer<DestinyMilestoneDefinition>(milestoneHash, DefinitionsEnum.DestinyMilestoneDefinition);
            AvailableQuests = availableQuests.AsReadOnlyOrEmpty();
            Activities = activities.AsReadOnlyOrEmpty();
            VendorPointers = vendorHashes.DefinitionsAsReadOnlyOrEmpty<DestinyVendorDefinition>(DefinitionsEnum.DestinyVendorDefinition);
            Vendors = vendors.AsReadOnlyOrEmpty();
            StartDate = startDate;
            EndDate = endDate;
            Order = order;
        }
    }
}
