using NetBungieAPI.Models.Destiny.Definitions.Milestones;
using NetBungieAPI.Models.Destiny.Definitions.Vendors;
using System;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Milestones
{
    public sealed record DestinyMilestone
    {
        [JsonPropertyName("milestoneHash")]
        public DefinitionHashPointer<DestinyMilestoneDefinition> Milestone { get; init; } = DefinitionHashPointer<DestinyMilestoneDefinition>.Empty;
        [JsonPropertyName("availableQuests")]
        public ReadOnlyCollection<DestinyMilestoneQuest> AvailableQuests { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyMilestoneQuest>();
        [JsonPropertyName("activities")]
        public ReadOnlyCollection<DestinyMilestoneChallengeActivity> Activities { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyMilestoneChallengeActivity>();
        [JsonPropertyName("values")]
        public ReadOnlyDictionary<string, double> Values { get; init; } = Defaults.EmptyReadOnlyDictionary<string, double>();
        [JsonPropertyName("vendorHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyVendorDefinition>> Vendors { get; init; } = Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyVendorDefinition>>();
        [JsonPropertyName("vendors")]
        public ReadOnlyCollection<DestinyMilestoneVendor> VendorsData { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyMilestoneVendor>();
        [JsonPropertyName("rewards")]
        public ReadOnlyCollection<DestinyMilestoneRewardCategory> Rewards { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyMilestoneRewardCategory>();
        [JsonPropertyName("startDate")]
        public DateTime? StartDate { get; init; }
        [JsonPropertyName("endDate")]
        public DateTime? EndDate { get; init; }
        [JsonPropertyName("order")]
        public int Order { get; init; }
    }
}
