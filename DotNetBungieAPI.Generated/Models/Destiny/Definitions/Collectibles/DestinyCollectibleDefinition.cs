using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Collectibles;

public sealed class DestinyCollectibleDefinition
{

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("scope")]
    public Destiny.DestinyScope Scope { get; init; }

    [JsonPropertyName("sourceString")]
    public string SourceString { get; init; }

    [JsonPropertyName("sourceHash")]
    public uint? SourceHash { get; init; }

    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; init; }

    [JsonPropertyName("acquisitionInfo")]
    public Destiny.Definitions.Collectibles.DestinyCollectibleAcquisitionBlock AcquisitionInfo { get; init; }

    [JsonPropertyName("stateInfo")]
    public Destiny.Definitions.Collectibles.DestinyCollectibleStateBlock StateInfo { get; init; }

    [JsonPropertyName("presentationInfo")]
    public Destiny.Definitions.Presentation.DestinyPresentationChildBlock PresentationInfo { get; init; }

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
