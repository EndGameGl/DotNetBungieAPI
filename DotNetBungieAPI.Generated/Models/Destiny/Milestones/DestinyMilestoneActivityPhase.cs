using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Milestones;

public sealed class DestinyMilestoneActivityPhase
{

    [JsonPropertyName("complete")]
    public bool Complete { get; init; }

    [JsonPropertyName("phaseHash")]
    public uint PhaseHash { get; init; }
}
