using NetBungieAPI.Attributes;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.ArtDyeChannels
{
    [DestinyDefinition(DefinitionsEnum.DestinyArtDyeChannelDefinition, DefinitionSources.BungieNet | DefinitionSources.JSON, DefinitionKeyType.UInt)]
    public class DestinyArtDyeChannelDefinition : IDestinyDefinition, IDeepEquatable<DestinyArtDyeChannelDefinition>
    {
        public uint ChannelHash { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyArtDyeChannelDefinition(uint channelHash, bool blacklisted, uint hash, int index, bool redacted)
        {
            ChannelHash = channelHash;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public bool DeepEquals(DestinyArtDyeChannelDefinition other)
        {
            return other != null &&
                   ChannelHash == other.ChannelHash &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
        public void MapValues() { return; }
    }
}
