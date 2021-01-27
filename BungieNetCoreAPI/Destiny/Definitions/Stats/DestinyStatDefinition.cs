using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Stats
{
    [DestinyDefinition(type: DefinitionsEnum.DestinyStatDefinition, presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyStatDefinition : IDestinyDefinition
    {
        public StatAggregationType AggregationType { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public bool HasComputedBlock { get; }
        public bool Interpolate { get; }
        public StatCategory StatCategory { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyStatDefinition(StatAggregationType aggregationType, bool hasComputedBlock, bool interpolate, StatCategory statCategory,
            DestinyDefinitionDisplayProperties displayProperties, bool blacklisted, uint hash, int index, bool redacted)
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
    }
}
