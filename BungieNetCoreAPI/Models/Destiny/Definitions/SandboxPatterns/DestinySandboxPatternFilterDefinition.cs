using NetBungieAPI.Models.Destiny.Definitions.Stats;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.SandboxPatterns
{
    public sealed record DestinySandboxPatternFilterDefinition : IDeepEquatable<DestinySandboxPatternFilterDefinition>
    {
        [JsonPropertyName("arrangementIndexByStatValue")]
        public ReadOnlyDictionary<string, int> ArrangementIndexByStatValue { get; init; }
        [JsonPropertyName("artArrangementRegionHash")]
        public uint ArtArrangementRegionHash { get; init; }
        [JsonPropertyName("artArrangementRegionIndex")]
        public int ArtArrangementRegionIndex { get; init; }
        [JsonPropertyName("statHash")]
        public DefinitionHashPointer<DestinyStatDefinition> Stat { get; init; }

        public bool DeepEquals(DestinySandboxPatternFilterDefinition other)
        {
            return other != null &&
                   ArrangementIndexByStatValue.DeepEqualsReadOnlyDictionaryWithSimpleKeyAndSimpleValue(other.ArrangementIndexByStatValue) &&
                   ArtArrangementRegionHash == other.ArtArrangementRegionHash &&
                   ArtArrangementRegionIndex == other.ArtArrangementRegionIndex &&
                   Stat.DeepEquals(other.Stat);
        }
    }
}
