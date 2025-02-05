namespace DotNetBungieAPI.Models.Destiny.Rendering;

public sealed record DestinyGearAssetDefinitionGear
{
    [JsonPropertyName("default_dyes")]
    public ReadOnlyCollection<DestinyGearAssetDefinitionDye> DefaultDyes { get; init; } =
        ReadOnlyCollection<DestinyGearAssetDefinitionDye>.Empty;

    [JsonPropertyName("locked_dyes")]
    public ReadOnlyCollection<DestinyGearAssetDefinitionDye> LockedDyes { get; init; } =
        ReadOnlyCollection<DestinyGearAssetDefinitionDye>.Empty;

    [JsonPropertyName("custom_dyes")]
    public ReadOnlyCollection<DestinyGearAssetDefinitionDye> CustomDyes { get; init; } =
        ReadOnlyCollection<DestinyGearAssetDefinitionDye>.Empty;

    [JsonPropertyName("art_content_sets")]
    public ReadOnlyCollection<DestinyGearAssetDefinitionArtContentSet> ArtContentSets { get; init; } =
        ReadOnlyCollection<DestinyGearAssetDefinitionArtContentSet>.Empty;
}
