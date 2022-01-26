namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Presentation;

public class DestinyPresentationNodeChildEntry : IDeepEquatable<DestinyPresentationNodeChildEntry>
{
    [JsonPropertyName("presentationNodeHash")]
    public uint PresentationNodeHash { get; set; }

    public bool DeepEquals(DestinyPresentationNodeChildEntry? other)
    {
        return other is not null &&
               PresentationNodeHash == other.PresentationNodeHash;
    }
}