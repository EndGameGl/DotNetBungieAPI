using NetBungieApi.Destiny.Definitions.Stats;
using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// Represents a "raw" investment stat, before calculated stats are calculated and before any DestinyStatGroupDefinition is applied to transform the stat into something closer to what you see in-game.
    /// <para/>
    /// Because these won't match what you see in-game, consider carefully whether you really want to use these stats. I have left them in case someone can do something useful or interesting with the pre-processed statistics.
    /// </summary>
    public class InventoryItemInvestmentStat : IDeepEquatable<InventoryItemInvestmentStat>
    {
        public bool IsConditionallyActive { get; }
        public DefinitionHashPointer<DestinyStatDefinition> StatType { get; }
        public int Value { get; }

        [JsonConstructor]
        internal InventoryItemInvestmentStat(bool isConditionallyActive, uint statTypeHash, int value)
        {
            IsConditionallyActive = isConditionallyActive;
            StatType = new DefinitionHashPointer<DestinyStatDefinition>(statTypeHash, DefinitionsEnum.DestinyStatDefinition);
            Value = value;
        }

        public bool DeepEquals(InventoryItemInvestmentStat other)
        {
            return other != null &&
                   IsConditionallyActive == other.IsConditionallyActive &&
                   StatType.DeepEquals(other.StatType) &&
                   Value == other.Value;
        }
    }
}
