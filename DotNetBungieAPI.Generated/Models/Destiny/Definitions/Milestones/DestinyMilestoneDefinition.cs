using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Milestones;

public sealed class DestinyMilestoneDefinition
{

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("displayPreference")]
    public Destiny.Definitions.Milestones.DestinyMilestoneDisplayPreference DisplayPreference { get; init; }

    [JsonPropertyName("image")]
    public string Image { get; init; }

    [JsonPropertyName("milestoneType")]
    public Destiny.Definitions.Milestones.DestinyMilestoneType MilestoneType { get; init; }

    [JsonPropertyName("recruitable")]
    public bool Recruitable { get; init; }

    [JsonPropertyName("friendlyName")]
    public string FriendlyName { get; init; }

    [JsonPropertyName("showInExplorer")]
    public bool ShowInExplorer { get; init; }

    [JsonPropertyName("showInMilestones")]
    public bool ShowInMilestones { get; init; }

    [JsonPropertyName("explorePrioritizesActivityImage")]
    public bool ExplorePrioritizesActivityImage { get; init; }

    [JsonPropertyName("hasPredictableDates")]
    public bool HasPredictableDates { get; init; }

    [JsonPropertyName("quests")]
    public Dictionary<uint, Destiny.Definitions.Milestones.DestinyMilestoneQuestDefinition> Quests { get; init; }

    [JsonPropertyName("rewards")]
    public Dictionary<uint, Destiny.Definitions.Milestones.DestinyMilestoneRewardCategoryDefinition> Rewards { get; init; }

    [JsonPropertyName("vendorsDisplayTitle")]
    public string VendorsDisplayTitle { get; init; }

    [JsonPropertyName("vendors")]
    public List<Destiny.Definitions.Milestones.DestinyMilestoneVendorDefinition> Vendors { get; init; }

    [JsonPropertyName("values")]
    public Dictionary<string, Destiny.Definitions.Milestones.DestinyMilestoneValueDefinition> Values { get; init; }

    [JsonPropertyName("isInGameMilestone")]
    public bool IsInGameMilestone { get; init; }

    [JsonPropertyName("activities")]
    public List<Destiny.Definitions.Milestones.DestinyMilestoneChallengeActivityDefinition> Activities { get; init; }

    [JsonPropertyName("defaultOrder")]
    public int DefaultOrder { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
