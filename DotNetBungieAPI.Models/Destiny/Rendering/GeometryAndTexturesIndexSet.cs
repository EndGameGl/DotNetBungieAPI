namespace DotNetBungieAPI.Models.Destiny.Rendering;

public sealed record GeometryAndTexturesIndexSet
{
    [JsonPropertyName("geometry")]
    public ReadOnlyCollection<int> Geometry { get; init; } = ReadOnlyCollection<int>.Empty;

    [JsonPropertyName("textures")]
    public ReadOnlyCollection<int> Textures { get; init; } = ReadOnlyCollection<int>.Empty;
}
