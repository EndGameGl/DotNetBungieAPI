namespace DotNetBungieAPI.Models.Destiny.Rendering;

public sealed record ArtContentSetArrangement
{
    [JsonPropertyName("hash")]
    public uint Hash { get; init; }
    
    [JsonPropertyName("gear_set")]
    public GearSet GearSet { get; init; }
}