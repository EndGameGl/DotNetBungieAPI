using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Milestones;

public sealed class DestinyMilestoneRewardEntryDefinition
{

    [JsonPropertyName("rewardEntryHash")]
    public uint RewardEntryHash { get; init; }

    [JsonPropertyName("rewardEntryIdentifier")]
    public string RewardEntryIdentifier { get; init; }

    [JsonPropertyName("items")]
    public List<Destiny.DestinyItemQuantity> Items { get; init; }

    [JsonPropertyName("vendorHash")]
    public uint? VendorHash { get; init; }

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("order")]
    public int Order { get; init; }
}
