using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.ArtDyeChannels
{
    [DestinyDefinition("DestinyArtDyeChannelDefinition", ignoreLoad: true)]
    public class DestinyArtDyeChannelDefinition : DestinyDefinition
    {
        public uint ChannelHash { get; }

        [JsonConstructor]
        private DestinyArtDyeChannelDefinition(uint channelHash, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            ChannelHash = channelHash;
        }
    }
}
