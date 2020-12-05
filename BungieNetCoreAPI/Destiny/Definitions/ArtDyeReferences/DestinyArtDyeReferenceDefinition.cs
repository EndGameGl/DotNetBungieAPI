using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.ArtDyeReferences
{
    [DestinyDefinition(name: "DestinyArtDyeReferenceDefinition", ignoreLoad: true)]
    public class DestinyArtDyeReferenceDefinition : DestinyDefinition
    {
        public uint ArtDyeHash { get; }
        public uint DyeManifestHash { get; }

        [JsonConstructor]
        private DestinyArtDyeReferenceDefinition(uint artDyeHash, uint dyeManifestHash, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            ArtDyeHash = artDyeHash;
            DyeManifestHash = dyeManifestHash;
        }
    }
}
