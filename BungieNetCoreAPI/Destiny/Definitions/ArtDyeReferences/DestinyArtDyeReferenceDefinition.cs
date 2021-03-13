using NetBungieApi.Attributes;
using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.ArtDyeReferences
{
    [DestinyDefinition(DefinitionsEnum.DestinyArtDyeReferenceDefinition, DefinitionSources.BungieNet | DefinitionSources.JSON, DefinitionKeyType.UInt)]
    public class DestinyArtDyeReferenceDefinition : IDestinyDefinition, IDeepEquatable<DestinyArtDyeReferenceDefinition>
    {
        public uint ArtDyeHash { get; }
        public uint DyeManifestHash { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyArtDyeReferenceDefinition(uint artDyeHash, uint dyeManifestHash, bool blacklisted, uint hash, int index, bool redacted)
        {
            ArtDyeHash = artDyeHash;
            DyeManifestHash = dyeManifestHash;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public bool DeepEquals(DestinyArtDyeReferenceDefinition other)
        {
            return other != null &&
                   ArtDyeHash == other.ArtDyeHash &&
                   DyeManifestHash == other.DyeManifestHash &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
        public void MapValues() { return; }
    }
}
