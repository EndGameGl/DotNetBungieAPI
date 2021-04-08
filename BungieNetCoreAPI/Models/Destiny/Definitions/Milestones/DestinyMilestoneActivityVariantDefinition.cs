using NetBungieAPI.Models.Destiny.Definitions.Activities;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Milestones
{
    public class DestinyMilestoneActivityVariantDefinition : IDeepEquatable<DestinyMilestoneActivityVariantDefinition>
    {
        [JsonPropertyName("activityHash")]
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; } = DefinitionHashPointer<DestinyActivityDefinition>.Empty;

        [JsonPropertyName("order")]
        public int Order { get; init; }

        public bool DeepEquals(DestinyMilestoneActivityVariantDefinition other)
        {
            return other != null &&
                   Activity.DeepEquals(other.Activity) &&
                   Order == other.Order;
        }
    }
}
