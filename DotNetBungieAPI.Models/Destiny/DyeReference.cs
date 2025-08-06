namespace DotNetBungieAPI.Models.Destiny;

public sealed class DyeReference
{
    [JsonPropertyName("channelHash")]
    public uint ChannelHash { get; init; }

    [JsonPropertyName("dyeHash")]
    public uint DyeHash { get; init; }
}
