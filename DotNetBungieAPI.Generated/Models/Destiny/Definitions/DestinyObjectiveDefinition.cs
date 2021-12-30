using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyObjectiveDefinition
{

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("completionValue")]
    public int CompletionValue { get; init; }

    [JsonPropertyName("scope")]
    public Destiny.DestinyGatingScope Scope { get; init; }

    [JsonPropertyName("locationHash")]
    public uint LocationHash { get; init; }

    [JsonPropertyName("allowNegativeValue")]
    public bool AllowNegativeValue { get; init; }

    [JsonPropertyName("allowValueChangeWhenCompleted")]
    public bool AllowValueChangeWhenCompleted { get; init; }

    [JsonPropertyName("isCountingDownward")]
    public bool IsCountingDownward { get; init; }

    [JsonPropertyName("valueStyle")]
    public Destiny.DestinyUnlockValueUIStyle ValueStyle { get; init; }

    [JsonPropertyName("progressDescription")]
    public string ProgressDescription { get; init; }

    [JsonPropertyName("perks")]
    public Destiny.Definitions.DestinyObjectivePerkEntryDefinition Perks { get; init; }

    [JsonPropertyName("stats")]
    public Destiny.Definitions.DestinyObjectiveStatEntryDefinition Stats { get; init; }

    [JsonPropertyName("minimumVisibilityThreshold")]
    public int MinimumVisibilityThreshold { get; init; }

    [JsonPropertyName("allowOvercompletion")]
    public bool AllowOvercompletion { get; init; }

    [JsonPropertyName("showValueOnComplete")]
    public bool ShowValueOnComplete { get; init; }

    [JsonPropertyName("completedValueStyle")]
    public Destiny.DestinyUnlockValueUIStyle CompletedValueStyle { get; init; }

    [JsonPropertyName("inProgressValueStyle")]
    public Destiny.DestinyUnlockValueUIStyle InProgressValueStyle { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
