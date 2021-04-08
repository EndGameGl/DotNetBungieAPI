using NetBungieAPI.Destiny.Definitions.Milestones;
using NetBungieAPI.Destiny.Definitions.Vendors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyMilestone
    {
        public DefinitionHashPointer<DestinyMilestoneDefinition> Milestone { get; init; }
        public ReadOnlyCollection<DestinyMilestoneQuest> AvailableQuests { get; init; }
        public ReadOnlyCollection<DestinyMilestoneChallengeActivity> Activities { get; init; }
        public ReadOnlyDictionary<string, double> Values { get; init; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyVendorDefinition>> Vendors { get; init; }
        public ReadOnlyCollection<DestinyMilestoneVendor> VendorsData { get; init; }
        public ReadOnlyCollection<DestinyMilestoneRewardCategory> Rewards { get; init; }
        public DateTime? StartDate { get; init; }
        public DateTime? EndDate { get; init; }
        public int Order { get; init; }

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
