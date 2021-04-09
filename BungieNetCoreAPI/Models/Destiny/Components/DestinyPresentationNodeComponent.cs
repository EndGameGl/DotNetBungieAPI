using NetBungieAPI.Models.Destiny.Quests;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyPresentationNodeComponent
    {
        [JsonPropertyName("state")]
        public DestinyPresentationNodeState State { get; init; }
        [JsonPropertyName("objective")]
        public DestinyObjectiveProgress Objective { get; init; }
        [JsonPropertyName("progressValue")]
        public int ProgressValue { get; init; }
        [JsonPropertyName("completionValue")]
        public int CompletionValue { get; init; }
        [JsonPropertyName("recordCategoryScore")]
        public int? RecordCategoryScore { get; init; }
    }
}
