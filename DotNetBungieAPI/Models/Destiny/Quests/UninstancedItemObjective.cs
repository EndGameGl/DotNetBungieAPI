using DotNetBungieAPI.Models.Destiny.Definitions.Objectives;

namespace DotNetBungieAPI.Models.Destiny.Quests;

public sealed record UninstancedItemObjective
{
    [JsonPropertyName("objectiveHash")]
    public DefinitionHashPointer<DestinyObjectiveDefinition> Objective { get; init; } =
        DefinitionHashPointer<DestinyObjectiveDefinition>.Empty;

    [JsonPropertyName("progress")] public double Progress { get; init; }

    [JsonPropertyName("completionValue")] public double CompletionValue { get; init; }

    [JsonPropertyName("complete")] public bool IsComplete { get; init; }

    [JsonPropertyName("visible")] public bool IsVisible { get; init; }
}