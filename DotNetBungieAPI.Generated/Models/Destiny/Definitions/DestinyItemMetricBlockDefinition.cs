namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     The metrics available for display and selection on an item.
/// </summary>
public class DestinyItemMetricBlockDefinition
{
    /// <summary>
    ///     Hash identifiers for any DestinyPresentationNodeDefinition entry that can be used to list available metrics. Any metric listed directly below these nodes, or in any of these nodes' children will be made available for selection.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition>("Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition")]
    [JsonPropertyName("availableMetricCategoryNodeHashes")]
    public uint[]? AvailableMetricCategoryNodeHashes { get; set; }
}
