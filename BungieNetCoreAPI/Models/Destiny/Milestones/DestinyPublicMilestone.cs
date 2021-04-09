using NetBungieAPI.Models.Destiny.Definitions.Milestones;
using NetBungieAPI.Models.Destiny.Definitions.Vendors;
using System;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Milestones
{
    public sealed record DestinyPublicMilestone
    {
        [JsonPropertyName("milestoneHash")]
        public DefinitionHashPointer<DestinyMilestoneDefinition> Milestone { get; init; } = DefinitionHashPointer<DestinyMilestoneDefinition>.Empty;
        [JsonPropertyName("availableQuests")]
        public ReadOnlyCollection<DestinyPublicMilestoneQuest> AvailableQuests { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyPublicMilestoneQuest>();
        [JsonPropertyName("activities")]
        public ReadOnlyCollection<DestinyPublicMilestoneChallengeActivity> Activities { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyPublicMilestoneChallengeActivity>();
        [JsonPropertyName("vendorHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyVendorDefinition>> VendorPointers { get; init; } = Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyVendorDefinition>>();
        [JsonPropertyName("vendors")]
        public ReadOnlyCollection<DestinyPublicMilestoneVendor> Vendors { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyPublicMilestoneVendor>();
        [JsonPropertyName("startDate")]
        public DateTime? StartDate { get; init; }
        [JsonPropertyName("endDate")]
        public DateTime? EndDate { get; init; }
        [JsonPropertyName("order")]
        public int Order { get; init; }
    }
}
