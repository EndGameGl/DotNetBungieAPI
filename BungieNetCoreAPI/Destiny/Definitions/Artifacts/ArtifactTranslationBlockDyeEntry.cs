using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Artifacts
{
    public class ArtifactTranslationBlockDyeEntry
    {
        public uint ChannelHash { get; }
        public uint DyeHash { get; }

        [JsonConstructor]
        private ArtifactTranslationBlockDyeEntry(uint channelHash, uint dyeHash)
        {
            ChannelHash = channelHash;
            DyeHash = dyeHash;
        }
    }
}
