using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.ActivityGraphs
{
    public class DestinyLinkedGraphEntryDefinition : IDeepEquatable<DestinyLinkedGraphEntryDefinition>
    {
        [JsonPropertyName("activityGraphHash")]
        public DefinitionHashPointer<DestinyActivityGraphDefinition> ActivityGraph { get; init; } =
            DefinitionHashPointer<DestinyActivityGraphDefinition>.Empty;

        public bool DeepEquals(DestinyLinkedGraphEntryDefinition other)
        {
            return other != null && ActivityGraph.DeepEquals(other.ActivityGraph);
        }
    }
}