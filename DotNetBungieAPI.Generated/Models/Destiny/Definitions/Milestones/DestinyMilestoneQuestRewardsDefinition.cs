using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Milestones;

public sealed class DestinyMilestoneQuestRewardsDefinition
{

    [JsonPropertyName("items")]
    public List<Destiny.Definitions.Milestones.DestinyMilestoneQuestRewardItem> Items { get; init; }
}
