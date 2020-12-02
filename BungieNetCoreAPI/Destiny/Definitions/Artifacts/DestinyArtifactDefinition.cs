using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Artifacts
{
    [DestinyDefinition("DestinyArtifactDefinition")]
    public class DestinyArtifactDefinition : DestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public List<ArtifactTierEntry> Tiers { get; }
        public ArtifactTranslationBlock TranslationBlock { get; }

        [JsonConstructor]
        private DestinyArtifactDefinition(DestinyDefinitionDisplayProperties displayProperties, List<ArtifactTierEntry> tiers, ArtifactTranslationBlock translationBlock,
            bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            DisplayProperties = displayProperties;
            if (tiers == null)
                Tiers = new List<ArtifactTierEntry>();
            else
                Tiers = tiers;
            TranslationBlock = translationBlock;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
