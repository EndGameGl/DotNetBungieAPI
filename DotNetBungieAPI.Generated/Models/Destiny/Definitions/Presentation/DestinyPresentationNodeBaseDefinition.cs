using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Presentation;

public sealed class DestinyPresentationNodeBaseDefinition
{

    [JsonPropertyName("presentationNodeType")]
    public Destiny.DestinyPresentationNodeType PresentationNodeType { get; init; }

    [JsonPropertyName("traitIds")]
    public List<string> TraitIds { get; init; }

    [JsonPropertyName("traitHashes")]
    public List<uint> TraitHashes { get; init; }

    [JsonPropertyName("parentNodeHashes")]
    public List<uint> ParentNodeHashes { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
