using NetBungieAPI.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace NetBungieAPI.Models.Destiny.Definitions.Stats
{
    [DestinyDefinition(DefinitionsEnum.DestinyStatDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyStatDefinition : IDestinyDefinition, IDeepEquatable<DestinyStatDefinition>
    {
        public StatAggregationType AggregationType { get; init; }
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        public bool HasComputedBlock { get; init; }
        public bool Interpolate { get; init; }
        public StatCategory StatCategory { get; init; }
        public bool Blacklisted { get; init; }
        public uint Hash { get; init; }
        public int Index { get; init; }
        public bool Redacted { get; init; }

        [JsonConstructor]
        internal DestinyStatDefinition(StatAggregationType aggregationType, bool hasComputedBlock, bool interpolate, StatCategory statCategory,
            DestinyDisplayPropertiesDefinition displayProperties, bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            AggregationType = aggregationType;
            HasComputedBlock = hasComputedBlock;
            Interpolate = interpolate;
            StatCategory = statCategory;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }

        public void MapValues()
        {
            return;
        }
        public bool DeepEquals(DestinyStatDefinition other)
        {
            return other != null &&
                   AggregationType == other.AggregationType &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   HasComputedBlock == other.HasComputedBlock &&
                   Interpolate == other.Interpolate &&
                   StatCategory == other.StatCategory &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
    }
}
