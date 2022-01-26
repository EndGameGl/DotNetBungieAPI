namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Presentation;

public class DestinyPresentationNodeMetricChildEntry : IDeepEquatable<DestinyPresentationNodeMetricChildEntry>
{
    [JsonPropertyName("metricHash")]
    public uint MetricHash { get; set; }

    public bool DeepEquals(DestinyPresentationNodeMetricChildEntry? other)
    {
        return other is not null &&
               MetricHash == other.MetricHash;
    }
}