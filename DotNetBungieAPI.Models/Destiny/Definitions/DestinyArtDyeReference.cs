namespace DotNetBungieAPI.Models.Destiny.Definitions;

public sealed class DestinyArtDyeReference
{
    [JsonPropertyName("artDyeChannelHash")]
    public uint ArtDyeChannelHash { get; init; }
}
