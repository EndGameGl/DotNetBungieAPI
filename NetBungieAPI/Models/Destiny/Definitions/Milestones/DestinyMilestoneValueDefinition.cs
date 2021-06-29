using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Definitions.Common;

namespace NetBungieAPI.Models.Destiny.Definitions.Milestones
{
    /// <summary>
    ///     The definition for information related to a key/value pair that is relevant for a particular Milestone or component
    ///     within the Milestone.
    ///     <para />
    ///     This lets us more flexibly pass up information that's useful to someone, even if it's not necessarily us.
    /// </summary>
    public sealed record DestinyMilestoneValueDefinition : IDeepEquatable<DestinyMilestoneValueDefinition>
    {
        [JsonPropertyName("key")] public string Key { get; init; }

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