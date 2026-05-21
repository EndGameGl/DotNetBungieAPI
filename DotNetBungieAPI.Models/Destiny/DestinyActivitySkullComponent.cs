namespace DotNetBungieAPI.Models.Destiny;

public sealed class DestinyActivitySkullComponent
{
    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("skullIdentifierHash")]
    public uint SkullIdentifierHash { get; init; }

    [JsonPropertyName("isEnabled")]
    public bool IsEnabled { get; init; }
}
