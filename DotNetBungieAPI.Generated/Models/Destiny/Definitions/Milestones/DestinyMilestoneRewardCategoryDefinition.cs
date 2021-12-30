using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Milestones;

public sealed class DestinyMilestoneRewardCategoryDefinition
{

    [JsonPropertyName("categoryHash")]
    public uint CategoryHash { get; init; }

    [JsonPropertyName("categoryIdentifier")]
    public string CategoryIdentifier { get; init; }

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("rewardEntries")]
    public Dictionary<uint, Destiny.Definitions.Milestones.DestinyMilestoneRewardEntryDefinition> RewardEntries { get; init; }

    [JsonPropertyName("order")]
    public int Order { get; init; }
}
