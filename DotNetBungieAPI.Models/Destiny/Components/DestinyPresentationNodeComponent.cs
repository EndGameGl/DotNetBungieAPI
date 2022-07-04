using DotNetBungieAPI.Models.Destiny.Quests;

namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DestinyPresentationNodeComponent
{
    [JsonPropertyName("state")] public DestinyPresentationNodeState State { get; init; }

    /// <summary>
    ///     An optional property: presentation nodes MAY have objectives, which can be used to infer more human readable data
    ///     about the progress. However, progressValue and completionValue ought to be considered the canonical values for
    ///     progress on Progression Nodes.
    /// </summary>
    [JsonPropertyName("objective")]
    public DestinyObjectiveProgress Objective { get; init; }

    /// <summary>
    ///     How much of the presentation node is considered to be completed so far by the given character/profile.
    /// </summary>
    [JsonPropertyName("progressValue")]
    public int ProgressValue { get; init; }

    /// <summary>
    ///     The value at which the presentation node is considered to be completed.
    /// </summary>
    [JsonPropertyName("completionValue")]
    public int CompletionValue { get; init; }

    /// <summary>
    ///     If available, this is the current score for the record category that this node represents.
    /// </summary>
    [JsonPropertyName("recordCategoryScore")]
    public int? RecordCategoryScore { get; init; }
}