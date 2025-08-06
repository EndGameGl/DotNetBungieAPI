namespace DotNetBungieAPI.Models.Destiny.Definitions.Presentation;

public sealed class DestinyPresentationNodeMetricChildEntry
{
    [JsonPropertyName("metricHash")]
    public DefinitionHashPointer<Destiny.Definitions.Metrics.DestinyMetricDefinition> MetricHash { get; init; }

    /// <summary>
    ///     Use this value to sort the presentation node children in ascending order.
    /// </summary>
    [JsonPropertyName("nodeDisplayPriority")]
    public uint NodeDisplayPriority { get; init; }
}
