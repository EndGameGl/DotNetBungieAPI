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
        public DefinitionHashPointer<DestinyMilestoneDefinition> Milestone { get; init; }
        public ReadOnlyCollection<DestinyPublicMilestoneQuest> AvailableQuests { get; init; }
        public ReadOnlyCollection<DestinyPublicMilestoneChallengeActivity> Activities { get; init; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyVendorDefinition>> VendorPointers { get; init; }
        public ReadOnlyCollection<DestinyPublicMilestoneVendor> Vendors { get; init; }
        public DateTime? StartDate { get; init; }
        public DateTime? EndDate { get; init; }
        public int Order { get; init; }

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
