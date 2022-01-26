namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Common;

public class DestinyIconSequenceDefinition : IDeepEquatable<DestinyIconSequenceDefinition>
{
    [JsonPropertyName("frames")]
    public List<string> Frames { get; set; }

    public bool DeepEquals(DestinyIconSequenceDefinition? other)
    {
        return other is not null &&
               Frames.DeepEqualsListNaive(other.Frames);
    }
}