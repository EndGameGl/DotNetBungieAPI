using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Artifacts
{
    [DestinyDefinition(name: "DestinyArtifactDefinition", presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyArtifactDefinition : IDestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public List<ArtifactTierEntry> Tiers { get; }
        public ArtifactTranslationBlock TranslationBlock { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyArtifactDefinition(DestinyDefinitionDisplayProperties displayProperties, List<ArtifactTierEntry> tiers, ArtifactTranslationBlock translationBlock,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            if (tiers == null)
                Tiers = new List<ArtifactTierEntry>();
            else
                Tiers = tiers;
            TranslationBlock = translationBlock;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
