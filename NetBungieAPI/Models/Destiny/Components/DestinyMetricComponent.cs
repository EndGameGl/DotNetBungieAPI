using NetBungieAPI.Models.Destiny.Quests;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyMetricComponent
    {
        [JsonPropertyName("invisible")]
        public bool IsInvisible { get; init; }
        [JsonPropertyName("objectiveProgress")]
        public DestinyObjectiveProgress ObjectiveProgress { get; init; }
    }
}
