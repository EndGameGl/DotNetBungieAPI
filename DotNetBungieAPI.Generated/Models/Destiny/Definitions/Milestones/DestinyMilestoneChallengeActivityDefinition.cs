using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Milestones;

public sealed class DestinyMilestoneChallengeActivityDefinition
{

    [JsonPropertyName("activityHash")]
    public uint ActivityHash { get; init; }

    [JsonPropertyName("challenges")]
    public List<Destiny.Definitions.Milestones.DestinyMilestoneChallengeDefinition> Challenges { get; init; }

    [JsonPropertyName("activityGraphNodes")]
    public List<Destiny.Definitions.Milestones.DestinyMilestoneChallengeActivityGraphNodeEntry> ActivityGraphNodes { get; init; }

    [JsonPropertyName("phases")]
    public List<Destiny.Definitions.Milestones.DestinyMilestoneChallengeActivityPhase> Phases { get; init; }
}
