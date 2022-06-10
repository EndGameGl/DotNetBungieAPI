namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Metrics;

public class DestinyMetricsComponent
{
    [JsonPropertyName("metrics")]
    public Dictionary<uint, Destiny.Components.Metrics.DestinyMetricComponent> Metrics { get; set; }

    [JsonPropertyName("metricsRootNodeHash")]
    public uint? MetricsRootNodeHash { get; set; }
}
