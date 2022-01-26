namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Metrics;

public class DestinyMetricComponent : IDeepEquatable<DestinyMetricComponent>
{
    [JsonPropertyName("invisible")]
    public bool Invisible { get; set; }

    [JsonPropertyName("objectiveProgress")]
    public Destiny.Quests.DestinyObjectiveProgress ObjectiveProgress { get; set; }

    public bool DeepEquals(DestinyMetricComponent? other)
    {
        return other is not null &&
               Invisible == other.Invisible &&
               (ObjectiveProgress is not null ? ObjectiveProgress.DeepEquals(other.ObjectiveProgress) : other.ObjectiveProgress is null);
    }
}