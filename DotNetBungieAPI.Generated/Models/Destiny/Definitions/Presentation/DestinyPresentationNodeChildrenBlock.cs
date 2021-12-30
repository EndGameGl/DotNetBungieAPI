using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Presentation;

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
