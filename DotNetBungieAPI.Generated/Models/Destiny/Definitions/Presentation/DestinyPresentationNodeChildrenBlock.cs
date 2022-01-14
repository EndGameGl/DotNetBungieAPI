namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Presentation;

/// <summary>
///     As/if presentation nodes begin to host more entities as children, these lists will be added to. One list property exists per type of entity that can be treated as a child of this presentation node, and each holds the identifier of the entity and any associated information needed to display the UI for that entity (if anything)
/// </summary>
public sealed class DestinyPresentationNodeChildrenBlock
{

    [JsonPropertyName("presentationNodes")]
    public List<Destiny.Definitions.Presentation.DestinyPresentationNodeChildEntry> PresentationNodes { get; init; }

    [JsonPropertyName("collectibles")]
    public List<Destiny.Definitions.Presentation.DestinyPresentationNodeCollectibleChildEntry> Collectibles { get; init; }

    [JsonPropertyName("records")]
    public List<Destiny.Definitions.Presentation.DestinyPresentationNodeRecordChildEntry> Records { get; init; }

    [JsonPropertyName("metrics")]
    public List<Destiny.Definitions.Presentation.DestinyPresentationNodeMetricChildEntry> Metrics { get; init; }
}
