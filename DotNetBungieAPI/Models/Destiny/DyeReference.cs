namespace DotNetBungieAPI.Models.Destiny
{
    public sealed record DyeReference : IDeepEquatable<DyeReference>
    {
        [JsonPropertyName("channelHash")] public uint ChannelHash { get; init; }

        [JsonPropertyName("dyeHash")] public uint DyeHash { get; init; }

        public bool DeepEquals(DyeReference other)
        {
            return other != null &&
                   ChannelHash == other.ChannelHash &&
                   DyeHash == other.DyeHash;
        }
    }
}