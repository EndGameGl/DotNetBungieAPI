using DotNetBungieAPI.Models.Destiny.Definitions.Metrics;

namespace DotNetBungieAPI.Models.Destiny.Definitions.PresentationNodes;

public sealed record DestinyPresentationNodeMetricChildEntry : 
    IDeepEquatable<DestinyPresentationNodeMetricChildEntry>
{
    [JsonPropertyName("metricHash")]
    public DefinitionHashPointer<DestinyMetricDefinition> Metric { get; init; } =
        DefinitionHashPointer<DestinyMetricDefinition>.Empty;
    
    /// <summary>
    ///     Use this value to sort the presentation node children in ascending order.
    /// </summary>
    [JsonPropertyName("nodeDisplayPriority")]
    public uint NodeDisplayPriority { get; init; }

    public bool DeepEquals(DestinyPresentationNodeMetricChildEntry other)
    {
        return other != null && 
               Metric.DeepEquals(other.Metric) &&
               NodeDisplayPriority == other.NodeDisplayPriority;
    }
}