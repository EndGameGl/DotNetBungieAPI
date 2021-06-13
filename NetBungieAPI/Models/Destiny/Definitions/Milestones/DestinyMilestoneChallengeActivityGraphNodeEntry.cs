using NetBungieAPI.Models.Destiny.Definitions.ActivityGraphs;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Milestones
{
    public sealed record DestinyMilestoneChallengeActivityGraphNodeEntry 
        : IDeepEquatable<DestinyMilestoneChallengeActivityGraphNodeEntry>
    {
        [JsonPropertyName("activityGraphHash")]
        public DefinitionHashPointer<DestinyActivityGraphDefinition> ActivityGraph { get; init; } =
            DefinitionHashPointer<DestinyActivityGraphDefinition>.Empty;

        [JsonPropertyName("activityGraphNodeHash")]
        public uint ActivityGraphNodeHash { get; init; }

        public bool DeepEquals(DestinyMilestoneChallengeActivityGraphNodeEntry other)
        {
            return other != null &&
                   ActivityGraph.DeepEquals(other.ActivityGraph) &&
                   ActivityGraphNodeHash == other.ActivityGraphNodeHash;
        }
    }
}