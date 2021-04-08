using NetBungieAPI.Destiny.Definitions.Stats;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.SandboxPatterns
{
    public class SandboxPatternFilter : IDeepEquatable<SandboxPatternFilter>
    {
        public ReadOnlyDictionary<string, int> ArrangementIndexByStatValue { get; init; }
        public uint ArtArrangementRegionHash { get; init; }
        public int ArtArrangementRegionIndex { get; init; }
        public DefinitionHashPointer<DestinyStatDefinition> Stat { get; init; }

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
