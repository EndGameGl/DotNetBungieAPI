namespace DotNetBungieAPI.Models.Destiny.Rendering;

public sealed record ArtArrangement
{
    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("geometry_hashes")]
    public ReadOnlyCollection<string> GeometryHashes { get; init; } =
        ReadOnlyCollection<string>.Empty;
}
