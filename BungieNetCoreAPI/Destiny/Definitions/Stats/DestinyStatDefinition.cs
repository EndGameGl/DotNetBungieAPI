using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Stats
{
    [DestinyDefinition("DestinyStatDefinition")]
    public class DestinyStatDefinition : DestinyDefinition
    {
        public StatAggregationType AggregationType { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public bool HasComputedBlock { get; }
        public bool Interpolate { get; }
        public StatCategory StatCategory { get; }

        [JsonConstructor]
        private DestinyStatDefinition(StatAggregationType aggregationType, bool hasComputedBlock, bool interpolate, StatCategory statCategory,
            DestinyDefinitionDisplayProperties displayProperties, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            DisplayProperties = displayProperties;
            AggregationType = aggregationType;
            HasComputedBlock = hasComputedBlock;
            Interpolate = interpolate;
            StatCategory = statCategory;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
