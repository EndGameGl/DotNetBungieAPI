namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinyGearArtArrangementReference
{
    [Destiny2Definition<Destiny.Definitions.DestinyClassDefinition>("Destiny.Definitions.DestinyClassDefinition")]
    [JsonPropertyName("classHash")]
    public uint ClassHash { get; set; }

    [JsonPropertyName("artArrangementHash")]
    public uint ArtArrangementHash { get; set; }
}
