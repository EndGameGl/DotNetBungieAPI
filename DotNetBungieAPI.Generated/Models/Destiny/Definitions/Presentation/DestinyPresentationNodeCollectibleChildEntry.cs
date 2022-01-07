using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Presentation;

public sealed class DestinyPresentationNodeCollectibleChildEntry
{

    [JsonPropertyName("collectibleHash")]
    public uint CollectibleHash { get; init; } // DestinyCollectibleDefinition
}
