using NetBungieAPI.Destiny.Definitions.RewardSources;
using NetBungieAPI.Destiny.Definitions.Stats;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// Properties of a DestinyInventoryItemDefinition that store all of the information we were able to discern about how the item spawns, and where you can find the item.
    /// <para/>
    /// Items will have many of these sources, one per level at which it spawns, to try and give more granular data about where items spawn for specific level ranges.
    /// </summary>
    public class InventoryItemSourceBlockSource : IDeepEquatable<InventoryItemSourceBlockSource>
    {
        /// <summary>
        /// The level at which the item spawns. Essentially the Primary Key for this source data: there will be multiple of these source entries per item that has source data, grouped by the level at which the item spawns.
        /// </summary>
        public int Level { get; init; }
        /// <summary>
        /// The minimum Quality at which the item spawns for this level. Examine DestinyInventoryItemDefinition for more information about what Quality means. Just don't ask Phaedrus about it, he'll never stop talking and you'll have to write a book about it.
        /// </summary>
        public int MinQuality { get; init; }
        /// <summary>
        /// The maximum quality at which the item spawns for this level.
        /// </summary>
        public int MaxQuality { get; init; }
        /// <summary>
        /// The minimum Character Level required for equipping the item when the item spawns at the item level defined on this DestinyItemSourceDefinition, as far as we saw in our processing.
        /// </summary>
        public int MinLevelRequired { get; init; }
        /// <summary>
        /// The maximum Character Level required for equipping the item when the item spawns at the item level defined on this DestinyItemSourceDefinition, as far as we saw in our processing.
        /// </summary>
        public int MaxLevelRequired { get; init; }
        /// <summary>
        /// The stats computed for this level/quality range.
        /// </summary>
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyStatDefinition>, InventoryItemStatsBlockStat> ComputedStats { get; init; }
        /// <summary>
        /// The DestinyRewardSourceDefinitions found that can spawn the item at this level.
        /// </summary>
        public ReadOnlyCollection<DefinitionHashPointer<DestinyRewardSourceDefinition>> Sources { get; init; }
        [JsonConstructor]
        internal InventoryItemSourceBlockSource(int level, int minQuality, int maxQuality, int minLevelRequired, int maxLevelRequired,
            Dictionary<uint, InventoryItemStatsBlockStat> computedStats, uint[] sourceHashes)
        {
            Level = level;
            MinQuality = minQuality;
            MaxQuality = maxQuality;
            MinLevelRequired = minLevelRequired;
            MaxLevelRequired = maxLevelRequired;
            ComputedStats = computedStats.AsReadOnlyDictionaryWithDefinitionKeyOrEmpty<DestinyStatDefinition, InventoryItemStatsBlockStat>(DefinitionsEnum.DestinyStatDefinition);
            Sources = sourceHashes.DefinitionsAsReadOnlyOrEmpty<DestinyRewardSourceDefinition>(DefinitionsEnum.DestinyRewardSourceDefinition);
        }

        public bool DeepEquals(InventoryItemSourceBlockSource other)
        {
            return other != null &&
                   Level == other.Level &&
                   MinQuality == other.MinQuality &&
                   MaxQuality == other.MaxQuality &&
                   MinLevelRequired == other.MinLevelRequired &&
                   MaxLevelRequired == other.MaxLevelRequired &&
                   ComputedStats.DeepEqualsReadOnlyDictionaryWithDefinitionKeyAndSimpleValue(other.ComputedStats) &&
                   Sources.DeepEqualsReadOnlyCollections(other.Sources);

        }
    }
}
