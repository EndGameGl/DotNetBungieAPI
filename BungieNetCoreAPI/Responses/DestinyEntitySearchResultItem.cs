using NetBungieAPI.Destiny.Definitions;
using Newtonsoft.Json;

namespace NetBungieAPI.Responses
{
    public class DestinyEntitySearchResultItem
    {
        public uint Hash { get; init; }
        public string EntityType { get; init; }
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        public double Weight { get; init; }

        [JsonConstructor]
        internal DestinyEntitySearchResultItem(uint hash, string entityType, DestinyDisplayPropertiesDefinition displayProperties, double weight)
        {
            Hash = hash;
            EntityType = entityType;
            DisplayProperties = displayProperties;
            Weight = weight;
        }
    }
}
