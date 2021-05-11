using NetBungieAPI.Models.Destiny.Definitions.Objectives;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.ActivityGraphs
{
    /// <summary>
    /// When a Graph needs to show active Objectives, this defines those objectives as well as an identifier.
    /// </summary>
    public sealed record DestinyActivityGraphDisplayObjectiveDefinition
        : IDeepEquatable<DestinyActivityGraphDisplayObjectiveDefinition>
    {
        /// <summary>
        /// This field is apparently something that CUI uses to manually wire up objectives to display info.
        /// </summary>
        [JsonPropertyName("id")]
        public uint Id { get; init; }

        /// <summary>
        /// The objective being shown on the map.
        /// </summary>
        [JsonPropertyName("objectiveHash")]
        public DefinitionHashPointer<DestinyObjectiveDefinition> Objective { get; init; } =
            DefinitionHashPointer<DestinyObjectiveDefinition>.Empty;

        public bool DeepEquals(DestinyActivityGraphDisplayObjectiveDefinition other)
        {
            return other != null &&
                   Id == other.Id &&
                   Objective.DeepEquals(other.Objective);
        }
    }
}