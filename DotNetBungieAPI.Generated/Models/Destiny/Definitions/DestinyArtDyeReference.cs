namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinyArtDyeReference : IDeepEquatable<DestinyArtDyeReference>
{
    [JsonPropertyName("artDyeChannelHash")]
    public uint ArtDyeChannelHash { get; set; }

    public bool DeepEquals(DestinyArtDyeReference? other)
    {
        return other is not null &&
               ArtDyeChannelHash == other.ArtDyeChannelHash;
    }
}