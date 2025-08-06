namespace DotNetBungieAPI.Models.Destiny.Definitions;

public sealed class DestinyGearArtArrangementReference
{
    [JsonPropertyName("classHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyClassDefinition> ClassHash { get; init; }

    [JsonPropertyName("artArrangementHash")]
    public uint ArtArrangementHash { get; init; }
}
