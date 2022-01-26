namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Collectibles;

public class DestinyCollectibleStateBlock : IDeepEquatable<DestinyCollectibleStateBlock>
{
    [JsonPropertyName("obscuredOverrideItemHash")]
    public uint? ObscuredOverrideItemHash { get; set; }

    [JsonPropertyName("requirements")]
    public Destiny.Definitions.Presentation.DestinyPresentationNodeRequirementsBlock Requirements { get; set; }

    public bool DeepEquals(DestinyCollectibleStateBlock? other)
    {
        return other is not null &&
               ObscuredOverrideItemHash == other.ObscuredOverrideItemHash &&
               (Requirements is not null ? Requirements.DeepEquals(other.Requirements) : other.Requirements is null);
    }
}