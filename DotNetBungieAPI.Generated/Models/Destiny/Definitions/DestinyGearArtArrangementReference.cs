namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinyGearArtArrangementReference : IDeepEquatable<DestinyGearArtArrangementReference>
{
    [JsonPropertyName("classHash")]
    public uint ClassHash { get; set; }

    [JsonPropertyName("artArrangementHash")]
    public uint ArtArrangementHash { get; set; }

    public bool DeepEquals(DestinyGearArtArrangementReference? other)
    {
        return other is not null &&
               ClassHash == other.ClassHash &&
               ArtArrangementHash == other.ArtArrangementHash;
    }
}