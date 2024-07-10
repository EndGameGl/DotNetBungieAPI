namespace DotNetBungieAPI.Models.Destiny.Rendering;

public sealed record GearSet
{
    [JsonPropertyName("regions")]
    public ReadOnlyCollection<GearSetRegion> Regions = ReadOnlyCollections<GearSetRegion>.Empty;

    [JsonPropertyName("base_art_arrangement")]
    public ArtArrangement BaseArtArrangement { get; init; }

    [JsonPropertyName("female_override_art_arrangement")]
    public ArtArrangement FemaleOverrideArtArrangement { get; init; }
}
