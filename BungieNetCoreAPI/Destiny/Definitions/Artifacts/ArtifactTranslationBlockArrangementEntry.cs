using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Artifacts
{
    public class ArtifactTranslationBlockArrangementEntry
    {
        public uint ArtArrangementHash { get; }
        public uint ClassHash { get; }

        [JsonConstructor]
        private ArtifactTranslationBlockArrangementEntry(uint artArrangementHash, uint classHash)
        {
            ArtArrangementHash = artArrangementHash;
            ClassHash = classHash;
        }
    }
}
