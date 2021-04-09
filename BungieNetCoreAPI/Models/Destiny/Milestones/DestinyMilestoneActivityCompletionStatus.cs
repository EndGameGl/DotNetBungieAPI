using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Milestones
{
    public sealed record DestinyMilestoneActivityCompletionStatus
    {
        [JsonPropertyName("completed")]
        public bool IsCompleted { get; init; }
        [JsonPropertyName("phases")]
        public ReadOnlyCollection<DestinyMilestoneActivityPhase> Phases { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyMilestoneActivityPhase>();
    }
}
