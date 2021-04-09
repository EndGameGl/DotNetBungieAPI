using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Milestones
{
    public sealed record DestinyMilestoneActivityPhase
    {
        [JsonPropertyName("complete")]
        public bool IsComplete { get; init; }
        [JsonPropertyName("phaseHash")]
        public uint PhaseHash { get; init; }
    }
}
