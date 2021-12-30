using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Presentation;

public sealed class DestinyPresentationNodeComponent
{

    [JsonPropertyName("state")]
    public Destiny.DestinyPresentationNodeState State { get; init; }

    [JsonPropertyName("objective")]
    public Destiny.Quests.DestinyObjectiveProgress Objective { get; init; }

    [JsonPropertyName("progressValue")]
    public int ProgressValue { get; init; }

    [JsonPropertyName("completionValue")]
    public int CompletionValue { get; init; }

    [JsonPropertyName("recordCategoryScore")]
    public int? RecordCategoryScore { get; init; }
}
