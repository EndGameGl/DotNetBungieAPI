using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Stats
{
    public class DestinyStatDefinition : DestinyDefinition
    {
        public int AggregationType { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public bool HasComputedBlock { get; }
        public bool Interpolate { get; }
        public int StatCategory { get; }

        [JsonConstructor]
        private DestinyStatDefinition(int aggregationType, bool hasComputedBlock, bool interpolate, int statCategory,
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
