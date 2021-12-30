using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Quests;

public sealed class DestinyObjectiveProgress
{

    [JsonPropertyName("objectiveHash")]
    public uint ObjectiveHash { get; init; }

    [JsonPropertyName("destinationHash")]
    public uint? DestinationHash { get; init; }

    [JsonPropertyName("activityHash")]
    public uint? ActivityHash { get; init; }

    [JsonPropertyName("progress")]
    public int? Progress { get; init; }

    [JsonPropertyName("completionValue")]
    public int CompletionValue { get; init; }

    [JsonPropertyName("complete")]
    public bool Complete { get; init; }

    [JsonPropertyName("visible")]
    public bool Visible { get; init; }
}
