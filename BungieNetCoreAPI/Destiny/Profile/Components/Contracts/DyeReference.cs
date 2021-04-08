using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DyeReference
    {
        public uint ChannelHash { get; init; }
        public uint DyeHash { get; init; }

        [JsonConstructor]
        internal DyeReference(uint channelHash, uint dyeHash)
        {
            ChannelHash = channelHash;
            DyeHash = dyeHash;
        }
    }
}
