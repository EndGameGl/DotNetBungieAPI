using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Milestones;

public sealed class DestinyMilestoneQuestRewardItem
{

    [JsonPropertyName("vendorHash")]
    public uint? VendorHash { get; init; }

    [JsonPropertyName("vendorItemIndex")]
    public int? VendorItemIndex { get; init; }

    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; init; }

    [JsonPropertyName("itemInstanceId")]
    public long? ItemInstanceId { get; init; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; init; }

    [JsonPropertyName("hasConditionalVisibility")]
    public bool HasConditionalVisibility { get; init; }
}
