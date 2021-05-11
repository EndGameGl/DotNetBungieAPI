using NetBungieAPI.Models.Destiny.Definitions.ProgressionMappings;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// Inventory Items can reward progression when actions are performed on them. A common example of this in Destiny 1 was Bounties, which would reward Experience on your Character and the like when you completed the bounty.
    /// </summary>
    public sealed record DestinyProgressionRewardDefinition : IDeepEquatable<DestinyProgressionRewardDefinition>
    {
        /// <summary>
        /// DestinyProgressionMappingDefinition that contains the progressions for which experience should be applied.
        /// </summary>
        [JsonPropertyName("progressionMappingHash")]
        public DefinitionHashPointer<DestinyProgressionMappingDefinition> ProgressionMapping { get; init; } =
            DefinitionHashPointer<DestinyProgressionMappingDefinition>.Empty;

        /// <summary>
        /// The amount of experience to give to each of the mapped progressions.
        /// </summary>
        [JsonPropertyName("amount")]
        public int Amount { get; init; }

        /// <summary>
        /// If true, the game's internal mechanisms to throttle progression should be applied.
        /// </summary>
        [JsonPropertyName("applyThrottles")]
        public bool ApplyThrottles { get; init; }

        public bool DeepEquals(DestinyProgressionRewardDefinition other)
        {
            return other != null &&
                   ProgressionMapping.DeepEquals(other.ProgressionMapping) &&
                   Amount == other.Amount &&
                   ApplyThrottles == other.ApplyThrottles;
        }
    }
}