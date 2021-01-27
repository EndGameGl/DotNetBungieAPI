using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.ArtDyeReferences
{
    [DestinyDefinition(type: DefinitionsEnum.DestinyArtDyeReferenceDefinition, presentInSQLiteDB: false, shouldBeLoaded: true)]
    public class DestinyArtDyeReferenceDefinition : IDestinyDefinition
    {
        public uint ArtDyeHash { get; }
        public uint DyeManifestHash { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyArtDyeReferenceDefinition(uint artDyeHash, uint dyeManifestHash, bool blacklisted, uint hash, int index, bool redacted)
        {
            ArtDyeHash = artDyeHash;
            DyeManifestHash = dyeManifestHash;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }
    }
}
