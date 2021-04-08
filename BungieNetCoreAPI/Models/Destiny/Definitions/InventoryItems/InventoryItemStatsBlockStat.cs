using NetBungieAPI.Destiny.Definitions.Stats;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// Defines a specific stat value on an item, and the minimum/maximum range that we could compute for the item based on our heuristics for how the item might be generated.
    /// <para/>
    /// Not guaranteed to match real-world instances of the item, but should hopefully at least be close.If it's not close, let us know on the Bungie API forums.
    /// </summary>
    public class InventoryItemStatsBlockStat : IDeepEquatable<InventoryItemStatsBlockStat>
    {
        /// <summary>
        /// The maximum possible value for the stat as shown in the UI, if it is being shown somewhere that reveals maximum in the UI (such as a bar chart-style view).
        /// <para/>
        /// This is pulled directly from the item's DestinyStatGroupDefinition, and placed here for convenience.
        /// <para/>
        /// If not returned, there is no maximum to use(and thus the stat should not be shown in a way that assumes there is a limit to the stat)
        /// </summary>
        public int? DisplayMaximum { get; init; }
        /// <summary>
        /// The maximum possible value for this stat that we think the item can roll.
        /// </summary>
        public int Maximum { get; init; }
        /// <summary>
        /// The minimum possible value for this stat that we think the item can roll.
        /// </summary>
        public int Minimum { get; init; }
        public DefinitionHashPointer<DestinyStatDefinition> Stat { get; init; }
        /// <summary>
        /// This value represents the stat value assuming the minimum possible roll but accounting for any mandatory bonuses that should be applied to the stat on item creation.
        /// <para/>
        /// In Destiny 1, this was different from the "minimum" value because there were certain conditions where an item could be theoretically lower level/value than the initial roll.
        /// <para/>
        /// In Destiny 2, this is not possible unless Talent Grids begin to be used again for these purposes or some other system change occurs... thus in practice, value and minimum should be the same in Destiny 2. Good riddance.
        /// </summary>
        public int Value { get; init; }

        [JsonConstructor]
        internal InventoryItemStatsBlockStat(int? displayMaximum, int maximum, int minimum, uint statHash, int value)
        {
            DisplayMaximum = displayMaximum;
            Maximum = maximum;
            Minimum = minimum;
            Stat = new DefinitionHashPointer<DestinyStatDefinition>(statHash, DefinitionsEnum.DestinyStatDefinition);
            Value = value;
        }

        public bool DeepEquals(InventoryItemStatsBlockStat other)
        {
            return other != null &&
                   DisplayMaximum == other.DisplayMaximum &&
                   Maximum == other.Maximum &&
                   Minimum == other.Minimum &&
                   Stat.DeepEquals(other.Stat) &&
                   Value == other.Value;
        }
    }
}
