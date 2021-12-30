using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Milestones;

public sealed class DestinyMilestone
{

    [JsonPropertyName("milestoneHash")]
    public uint MilestoneHash { get; init; }

    [JsonPropertyName("availableQuests")]
    public List<Destiny.Milestones.DestinyMilestoneQuest> AvailableQuests { get; init; }

    [JsonPropertyName("activities")]
    public List<Destiny.Milestones.DestinyMilestoneChallengeActivity> Activities { get; init; }

    [JsonPropertyName("values")]
    public Dictionary<string, float> Values { get; init; }

    [JsonPropertyName("vendorHashes")]
    public List<uint> VendorHashes { get; init; }

    [JsonPropertyName("vendors")]
    public List<Destiny.Milestones.DestinyMilestoneVendor> Vendors { get; init; }

    [JsonPropertyName("rewards")]
    public List<Destiny.Milestones.DestinyMilestoneRewardCategory> Rewards { get; init; }

    [JsonPropertyName("startDate")]
    public DateTime? StartDate { get; init; }

    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; init; }

    [JsonPropertyName("order")]
    public int Order { get; init; }
}
