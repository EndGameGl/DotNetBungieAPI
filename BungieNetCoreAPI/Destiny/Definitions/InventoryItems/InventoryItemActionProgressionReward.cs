using NetBungieApi.Destiny.Definitions.ProgressionMappings;
using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// Inventory Items can reward progression when actions are performed on them. A common example of this in Destiny 1 was Bounties, which would reward Experience on your Character and the like when you completed the bounty.
    /// </summary>
    public class InventoryItemActionProgressionReward : IDeepEquatable<InventoryItemActionProgressionReward>
    {
        public DefinitionHashPointer<DestinyProgressionMappingDefinition> ProgressionMapping { get; }
        /// <summary>
        /// The amount of experience to give to each of the mapped progressions.
        /// </summary>
        public int Amount { get; }
        /// <summary>
        /// If true, the game's internal mechanisms to throttle progression should be applied.
        /// </summary>
        public bool ApplyThrottles { get; }

        [JsonConstructor]
        internal InventoryItemActionProgressionReward(uint progressionMappingHash, int amount, bool applyThrottles)
        {
            ProgressionMapping = new DefinitionHashPointer<DestinyProgressionMappingDefinition>(progressionMappingHash, DefinitionsEnum.DestinyProgressionMappingDefinition);
            Amount = amount;
            ApplyThrottles = applyThrottles;
        }

        public bool DeepEquals(InventoryItemActionProgressionReward other)
        {
            return other != null &&
                   ProgressionMapping.DeepEquals(other.ProgressionMapping) &&
                   Amount == other.Amount &&
                   ApplyThrottles == other.ApplyThrottles;
        }
    }
}
