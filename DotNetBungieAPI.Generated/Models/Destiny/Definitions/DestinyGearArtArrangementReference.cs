using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyGearArtArrangementReference
{

    [JsonPropertyName("classHash")]
    public uint ClassHash { get; init; }

    [JsonPropertyName("artArrangementHash")]
    public uint ArtArrangementHash { get; init; }
}
