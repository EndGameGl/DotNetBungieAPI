using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Milestones;

public sealed class DestinyPublicMilestone
{

    [JsonPropertyName("milestoneHash")]
    public uint MilestoneHash { get; init; }

    [JsonPropertyName("availableQuests")]
    public List<Destiny.Milestones.DestinyPublicMilestoneQuest> AvailableQuests { get; init; }

    [JsonPropertyName("activities")]
    public List<Destiny.Milestones.DestinyPublicMilestoneChallengeActivity> Activities { get; init; }

    [JsonPropertyName("vendorHashes")]
    public List<uint> VendorHashes { get; init; }

    [JsonPropertyName("vendors")]
    public List<Destiny.Milestones.DestinyPublicMilestoneVendor> Vendors { get; init; }

    [JsonPropertyName("startDate")]
    public DateTime? StartDate { get; init; }

    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; init; }

    [JsonPropertyName("order")]
    public int Order { get; init; }
}
