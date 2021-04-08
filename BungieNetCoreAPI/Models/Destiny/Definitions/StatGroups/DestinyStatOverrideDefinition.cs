using NetBungieAPI.Models.Destiny.Definitions.Common;
using NetBungieAPI.Models.Destiny.Definitions.Stats;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.StatGroups
{
    public sealed record DestinyStatOverrideDefinition : IDeepEquatable<DestinyStatOverrideDefinition>
    {
        [JsonPropertyName("maximumValue")]
        public DefinitionHashPointer<DestinyStatDefinition> Stat { get; init; } = DefinitionHashPointer<DestinyStatDefinition>.Empty;
        [JsonPropertyName("maximumValue")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

        public bool DeepEquals(DestinyStatOverrideDefinition other)
        {
            return other != null &&
                   Stat.DeepEquals(other.Stat) &&
                   DisplayProperties.DeepEquals(other.DisplayProperties);
        }
    }
}
