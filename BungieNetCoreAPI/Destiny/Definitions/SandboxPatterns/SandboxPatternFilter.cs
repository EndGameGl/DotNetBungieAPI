using BungieNetCoreAPI.Destiny.Definitions.Stats;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Definitions.SandboxPatterns
{
    public class SandboxPatternFilter : IDeepEquatable<SandboxPatternFilter>
    {
        public ReadOnlyDictionary<string, int> ArrangementIndexByStatValue { get; }
        public uint ArtArrangementRegionHash { get; }
        public int ArtArrangementRegionIndex { get; }
        public DefinitionHashPointer<DestinyStatDefinition> Stat { get; }

        [JsonConstructor]
        internal SandboxPatternFilter(Dictionary<string, int> arrangementIndexByStatValue, uint artArrangementRegionHash, int artArrangementRegionIndex, uint statHash)
        {
            ArrangementIndexByStatValue = arrangementIndexByStatValue.AsReadOnlyDictionaryOrEmpty();
            ArtArrangementRegionHash = artArrangementRegionHash;
            ArtArrangementRegionIndex = artArrangementRegionIndex;
            Stat = new DefinitionHashPointer<DestinyStatDefinition>(statHash, DefinitionsEnum.DestinyStatDefinition);
        }

        public bool DeepEquals(SandboxPatternFilter other)
        {
            return other != null &&
                   ArrangementIndexByStatValue.DeepEqualsReadOnlyDictionaryWithSimpleKeyAndSimpleValue(other.ArrangementIndexByStatValue) &&
                   ArtArrangementRegionHash == other.ArtArrangementRegionHash &&
                   ArtArrangementRegionIndex == other.ArtArrangementRegionIndex &&
                   Stat.DeepEquals(other.Stat);
        }
    }
}
