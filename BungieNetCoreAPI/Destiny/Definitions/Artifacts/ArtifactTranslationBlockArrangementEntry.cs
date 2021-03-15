using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Artifacts
{
    public class ArtifactTranslationBlockArrangementEntry : IDeepEquatable<ArtifactTranslationBlockArrangementEntry>
    {
        public uint ArtArrangementHash { get; }
        public uint ClassHash { get; }

        [JsonConstructor]
        internal ArtifactTranslationBlockArrangementEntry(uint artArrangementHash, uint classHash)
        {
            ArtArrangementHash = artArrangementHash;
            ClassHash = classHash;
        }

        public bool DeepEquals(ArtifactTranslationBlockArrangementEntry other)
        {
            return other != null &&
                ArtArrangementHash == other.ArtArrangementHash &&
                ClassHash == other.ClassHash;
        }
    }
}
