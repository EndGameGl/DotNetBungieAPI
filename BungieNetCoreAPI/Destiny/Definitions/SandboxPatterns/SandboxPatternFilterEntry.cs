using BungieNetCoreAPI.Destiny.Definitions.Stats;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.SandboxPatterns
{
    public class SandboxPatternFilterEntry
    {
        public Dictionary<string, int> ArrangementIndexByStatValue { get; }
        public uint ArtArrangementRegionHash { get; }
        public int ArtArrangementRegionIndex { get; }
        public DefinitionHashPointer<DestinyStatDefinition> Stat { get; }

        [JsonConstructor]
        private SandboxPatternFilterEntry(Dictionary<string, int> arrangementIndexByStatValue, uint artArrangementRegionHash, int artArrangementRegionIndex, uint statHash)
        {
            ArrangementIndexByStatValue = arrangementIndexByStatValue;
            ArtArrangementRegionHash = artArrangementRegionHash;
            ArtArrangementRegionIndex = artArrangementRegionIndex;
            Stat = new DefinitionHashPointer<DestinyStatDefinition>(statHash, "DestinyStatDefinition");
        }
    }
}
