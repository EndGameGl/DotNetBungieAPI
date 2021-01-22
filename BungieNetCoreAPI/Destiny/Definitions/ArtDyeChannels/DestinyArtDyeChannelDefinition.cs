using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.ArtDyeChannels
{
    [DestinyDefinition(name: "DestinyArtDyeChannelDefinition", presentInSQLiteDB: false, shouldBeLoaded: true)]
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
