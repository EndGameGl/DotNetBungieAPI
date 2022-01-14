namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyGearArtArrangementReference
{

    [JsonPropertyName("classHash")]
    public uint ClassHash { get; init; } // DestinyClassDefinition

    [JsonPropertyName("artArrangementHash")]
    public uint ArtArrangementHash { get; init; }
}
