namespace DotNetBungieAPI.Generated.Models.Destiny;

public class DyeReference : IDeepEquatable<DyeReference>
{
    [JsonPropertyName("channelHash")]
    public uint ChannelHash { get; set; }

    [JsonPropertyName("dyeHash")]
    public uint DyeHash { get; set; }

    public bool DeepEquals(DyeReference? other)
    {
        return other is not null &&
               ChannelHash == other.ChannelHash &&
               DyeHash == other.DyeHash;
    }
}