using BungieNetCoreAPI.Destiny.Definitions.StatGroups;
using BungieNetCoreAPI.Destiny.Definitions.Stats;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemStatsBlock
    {
        public bool DisablePrimaryStatDisplay { get; }
        public bool HasDisplayableStats { get; }
        public DefinitionHashPointer<DestinyStatDefinition> PrimaryBaseStat { get; }
        public DefinitionHashPointer<DestinyStatGroupDefinition> StatGroup { get; }
        public Dictionary<DefinitionHashPointer<DestinyStatDefinition>, InventoryItemStatsBlockStat> Stats { get; }

        [JsonConstructor]
        private InventoryItemStatsBlock(bool disablePrimaryStatDisplay, bool hasDisplayableStats, uint primaryBaseStatHash, uint statGroupHash, 
            Dictionary<uint, InventoryItemStatsBlockStat> stats)
        {
            DisablePrimaryStatDisplay = disablePrimaryStatDisplay;
            HasDisplayableStats = hasDisplayableStats;
            PrimaryBaseStat = new DefinitionHashPointer<DestinyStatDefinition>(primaryBaseStatHash, "DestinyStatDefinition");
            StatGroup = new DefinitionHashPointer<DestinyStatGroupDefinition>(statGroupHash, "DestinyStatGroupDefinition");
            Stats = new Dictionary<DefinitionHashPointer<DestinyStatDefinition>, InventoryItemStatsBlockStat>();
            if (stats != null)
            {
                foreach (var statPair in stats)
                {
                    Stats.Add(new DefinitionHashPointer<DestinyStatDefinition>(statPair.Key, "DestinyStatDefinition"), statPair.Value);
                }
            }
        }

    }
}
