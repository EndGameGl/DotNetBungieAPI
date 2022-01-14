namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Metrics;

public sealed class DestinyMetricComponent
{

    [JsonPropertyName("invisible")]
    public bool Invisible { get; init; }

    [JsonPropertyName("objectiveProgress")]
    public Destiny.Quests.DestinyObjectiveProgress ObjectiveProgress { get; init; }
}
