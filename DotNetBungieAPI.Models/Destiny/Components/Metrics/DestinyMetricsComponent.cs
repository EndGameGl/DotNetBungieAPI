namespace DotNetBungieAPI.Models.Destiny.Components.Metrics;

public sealed class DestinyMetricsComponent
{
    [JsonPropertyName("metrics")]
    public Dictionary<uint, Destiny.Components.Metrics.DestinyMetricComponent>? Metrics { get; init; }

    [JsonPropertyName("metricsRootNodeHash")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition> MetricsRootNodeHash { get; init; }
}
