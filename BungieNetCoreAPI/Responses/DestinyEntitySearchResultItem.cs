using NetBungieApi.Destiny.Definitions;
using Newtonsoft.Json;

namespace NetBungieApi.Responses
{
    public class DestinyEntitySearchResultItem
    {
        public uint Hash { get; }
        public string EntityType { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public double Weight { get; }

        [JsonConstructor]
        internal DestinyEntitySearchResultItem(uint hash, string entityType, DestinyDefinitionDisplayProperties displayProperties, double weight)
        {
            Hash = hash;
            EntityType = entityType;
            DisplayProperties = displayProperties;
            Weight = weight;
        }
    }
}
