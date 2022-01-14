namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Metrics;

public sealed class DestinyMetricsComponent
{

    [JsonPropertyName("metrics")]
    public Dictionary<uint, Destiny.Components.Metrics.DestinyMetricComponent> Metrics { get; init; }

    [JsonPropertyName("metricsRootNodeHash")]
    public uint MetricsRootNodeHash { get; init; } // DestinyPresentationNodeDefinition
}
