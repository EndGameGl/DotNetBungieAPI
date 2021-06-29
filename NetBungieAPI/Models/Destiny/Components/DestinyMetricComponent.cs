using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Quests;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyMetricComponent
    {
        [JsonPropertyName("invisible")] public bool IsInvisible { get; init; }

        [JsonPropertyName("objectiveProgress")]
        public DestinyObjectiveProgress ObjectiveProgress { get; init; }
    }
}