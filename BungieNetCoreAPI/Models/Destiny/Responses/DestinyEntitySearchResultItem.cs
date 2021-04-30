using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Definitions.Common;

namespace NetBungieAPI.Models.Destiny.Responses
{
    public sealed record DestinyEntitySearchResultItem
    {
        [JsonPropertyName("hash")]
        public uint Hash { get; init; }
        [JsonPropertyName("entityType")]
        public string EntityType { get; init; }
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        [JsonPropertyName("weight")]
        public double Weight { get; init; }
    }
}
