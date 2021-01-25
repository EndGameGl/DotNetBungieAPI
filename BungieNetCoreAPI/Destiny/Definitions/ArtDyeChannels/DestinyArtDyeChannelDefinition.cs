using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.ArtDyeChannels
{
    [DestinyDefinition(name: "DestinyArtDyeChannelDefinition", presentInSQLiteDB: false, shouldBeLoaded: true)]
    public class DestinyArtDyeChannelDefinition : IDestinyDefinition
    {
        public uint ChannelHash { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyArtDyeChannelDefinition(uint channelHash, bool blacklisted, uint hash, int index, bool redacted)
        {
            ChannelHash = channelHash;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }
    }
}
