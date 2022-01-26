namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Presentation;

public class DestinyPresentationNodeCollectibleChildEntry : IDeepEquatable<DestinyPresentationNodeCollectibleChildEntry>
{
    [JsonPropertyName("collectibleHash")]
    public uint CollectibleHash { get; set; }

    public bool DeepEquals(DestinyPresentationNodeCollectibleChildEntry? other)
    {
        return other is not null &&
               CollectibleHash == other.CollectibleHash;
    }
}