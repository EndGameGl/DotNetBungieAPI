namespace DotNetBungieAPI.Models.Destiny.Rendering;

public sealed record DestinyGearAssetDefinitionContent
{
    [JsonPropertyName("dye_index_set")]
    public GeometryAndTexturesIndexSet DyeIndexSet { get; init; }

    [JsonPropertyName("female_index_set")]
    public GeometryAndTexturesIndexSet FemaleIndexSet { get; init; }

    [JsonPropertyName("geometry")]
    public ReadOnlyCollection<string> Geometry { get; init; } = ReadOnlyCollection<string>.Empty;

    [JsonPropertyName("male_index_set")]
    public GeometryAndTexturesIndexSet MaleIndexSet { get; init; }

    [JsonPropertyName("platform")]
    public string Platform { get; init; }

    [JsonPropertyName("region_index_sets")]
    public ReadOnlyDictionary<
        int,
        ReadOnlyCollection<GeometryAndTexturesIndexSet>
    > RegionIndexSets { get; init; } =
        ReadOnlyDictionary<int, ReadOnlyCollection<GeometryAndTexturesIndexSet>>.Empty;

    [JsonPropertyName("textures")]
    public ReadOnlyCollection<string> Textures { get; init; } = ReadOnlyCollection<string>.Empty;
}
