using DotNetBungieAPI.Models.Destiny.Quests;

namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DestinyMetricComponent
{
    [JsonPropertyName("invisible")]
    public bool IsInvisible { get; init; }

    [JsonPropertyName("objectiveProgress")]
    public DestinyObjectiveProgress ObjectiveProgress { get; init; }
}
