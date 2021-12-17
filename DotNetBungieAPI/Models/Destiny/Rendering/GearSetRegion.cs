namespace DotNetBungieAPI.Models.Destiny.Rendering;

public sealed record GearSetRegion
{
    [JsonPropertyName("region_index")]
    public int RegionIndex { get; init; }

    [JsonPropertyName("pattern_list")]
    public ReadOnlyCollection<ArtArrangement> PatternList { get; init; } = ReadOnlyCollections<ArtArrangement>.Empty;
}