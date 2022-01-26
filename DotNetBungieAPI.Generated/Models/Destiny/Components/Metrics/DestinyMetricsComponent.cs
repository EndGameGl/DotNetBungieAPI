namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Metrics;

public class DestinyMetricsComponent : IDeepEquatable<DestinyMetricsComponent>
{
    [JsonPropertyName("metrics")]
    public Dictionary<uint, Destiny.Components.Metrics.DestinyMetricComponent> Metrics { get; set; }

    [JsonPropertyName("metricsRootNodeHash")]
    public uint MetricsRootNodeHash { get; set; }

    public bool DeepEquals(DestinyMetricsComponent? other)
    {
        return other is not null &&
               Metrics.DeepEqualsDictionary(other.Metrics) &&
               MetricsRootNodeHash == other.MetricsRootNodeHash;
    }
}