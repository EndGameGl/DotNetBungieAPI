using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Presentation;

public sealed class DestinyPresentationNodesComponent
{

    [JsonPropertyName("nodes")]
    public Dictionary<uint, Destiny.Components.Presentation.DestinyPresentationNodeComponent> Nodes { get; init; }
}
