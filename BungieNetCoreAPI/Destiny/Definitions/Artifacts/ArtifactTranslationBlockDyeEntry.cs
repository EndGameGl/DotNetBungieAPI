using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Artifacts
{
    public class ArtifactTranslationBlockDyeEntry : IDeepEquatable<ArtifactTranslationBlockDyeEntry>
    {
        public uint ChannelHash { get; }
        public uint DyeHash { get; }

        [JsonConstructor]
        internal ArtifactTranslationBlockDyeEntry(uint channelHash, uint dyeHash)
        {
            ChannelHash = channelHash;
            DyeHash = dyeHash;
        }

        public bool DeepEquals(ArtifactTranslationBlockDyeEntry other)
        {
            return other != null &&
                ChannelHash == other.ChannelHash &&
                DyeHash == other.DyeHash;
        }
    }
}
