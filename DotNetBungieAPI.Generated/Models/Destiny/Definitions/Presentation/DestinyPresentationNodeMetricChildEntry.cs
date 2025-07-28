namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Presentation;

public class DestinyPresentationNodeMetricChildEntry
{
    [Destiny2Definition<Destiny.Definitions.Metrics.DestinyMetricDefinition>("Destiny.Definitions.Metrics.DestinyMetricDefinition")]
    [JsonPropertyName("metricHash")]
    public uint MetricHash { get; set; }

    /// <summary>
    ///     Use this value to sort the presentation node children in ascending order.
    /// </summary>
    [JsonPropertyName("nodeDisplayPriority")]
    public uint NodeDisplayPriority { get; set; }
}
