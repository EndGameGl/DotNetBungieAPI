using NetBungieApi.Destiny.Definitions.Milestones;
using NetBungieApi.Destiny.Definitions.Vendors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Profile.Components.Contracts
{
    public class DestinyMilestone
    {
        public DefinitionHashPointer<DestinyMilestoneDefinition> Milestone { get; }
        public ReadOnlyCollection<DestinyMilestoneQuest> AvailableQuests { get; }
        public ReadOnlyCollection<DestinyMilestoneChallengeActivity> Activities { get; }
        public ReadOnlyDictionary<string, double> Values { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyVendorDefinition>> Vendors { get; }
        public ReadOnlyCollection<DestinyMilestoneVendor> VendorsData { get; }
        public ReadOnlyCollection<DestinyMilestoneRewardCategory> Rewards { get; }
        public DateTime? StartDate { get; }
        public DateTime? EndDate { get; }
        public int Order { get; }

        [JsonConstructor]
        internal DestinyMilestone(uint milestoneHash, DestinyMilestoneQuest[] availableQuests, DestinyMilestoneChallengeActivity[] activities,
            Dictionary<string, double> values, uint[] vendorHashes, DestinyMilestoneVendor[] vendors, DestinyMilestoneRewardCategory[] rewards,
            DateTime? startDate, DateTime? endDate, int order)
        {
            Milestone = new DefinitionHashPointer<DestinyMilestoneDefinition>(milestoneHash, DefinitionsEnum.DestinyMilestoneDefinition);
            AvailableQuests = availableQuests.AsReadOnlyOrEmpty();
            Activities = activities.AsReadOnlyOrEmpty();
            Values = values.AsReadOnlyDictionaryOrEmpty();
            Vendors = vendorHashes.DefinitionsAsReadOnlyOrEmpty<DestinyVendorDefinition>(DefinitionsEnum.DestinyVendorDefinition);
            VendorsData = vendors.AsReadOnlyOrEmpty();
            Rewards = rewards.AsReadOnlyOrEmpty();
            StartDate = startDate;
            EndDate = endDate;
            Order = order;
        }
    }
}
