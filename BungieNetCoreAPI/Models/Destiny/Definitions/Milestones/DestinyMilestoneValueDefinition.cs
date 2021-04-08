using NetBungieAPI.Models.Destiny.Definitions.Common;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Milestones
{
    public sealed record DestinyMilestoneValueDefinition : IDeepEquatable<DestinyMilestoneValueDefinition>
    {
        [JsonPropertyName("key")]
        public string Key { get; init; }
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

        public bool DeepEquals(DestinyMilestoneValueDefinition other)
        {
            return other != null &&
                   Key == other.Key &&
                   DisplayProperties.DeepEquals(other.DisplayProperties);
        }
    }
}
