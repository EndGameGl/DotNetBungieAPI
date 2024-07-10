namespace DotNetBungieAPI.Models.Destiny.Rendering;

public sealed record DestinyGearAssetDefinitionArtContentSet
{
    [JsonPropertyName("classHash")]
    public uint ClassHash { get; init; }

    [JsonPropertyName("arrangement")]
    public ArtContentSetArrangement Arrangement { get; init; }
}
