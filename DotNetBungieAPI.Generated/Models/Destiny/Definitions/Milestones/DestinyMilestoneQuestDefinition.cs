using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Milestones;

public sealed class DestinyMilestoneQuestDefinition
{

    [JsonPropertyName("questItemHash")]
    public uint QuestItemHash { get; init; }

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("overrideImage")]
    public string OverrideImage { get; init; }

    [JsonPropertyName("questRewards")]
    public Destiny.Definitions.Milestones.DestinyMilestoneQuestRewardsDefinition QuestRewards { get; init; }

    [JsonPropertyName("activities")]
    public Dictionary<uint, Destiny.Definitions.Milestones.DestinyMilestoneActivityDefinition> Activities { get; init; }

    [JsonPropertyName("destinationHash")]
    public uint? DestinationHash { get; init; }
}
