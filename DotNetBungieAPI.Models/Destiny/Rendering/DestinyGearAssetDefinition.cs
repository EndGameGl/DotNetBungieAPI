namespace DotNetBungieAPI.Models.Destiny.Rendering;

public sealed record DestinyGearAssetDefinition
{
    [JsonPropertyName("content")]
    public ReadOnlyCollection<DestinyGearAssetDefinitionContent> Content { get; init; } =
        ReadOnlyCollections<DestinyGearAssetDefinitionContent>.Empty;

    [JsonPropertyName("gear")]
    public ReadOnlyCollection<string> Gear { get; init; } = ReadOnlyCollections<string>.Empty;
}
