using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemSetDataBlock
    {
        public uint AbandonmentUnlockHash { get; }
        public List<InventoryItemSetDataBlockItem> ItemList { get; }
        public string QuestLineDescription { get; }
        public string QuestLineName { get; }
        public string QuestStepSummary { get; }
        public bool RequireOrderedSetItemAdd { get; }
        public bool SetIsFeatured { get; }
        public string SetType { get; }
        public uint TrackingUnlockValueHash { get; }

        [JsonConstructor]
        private InventoryItemSetDataBlock(uint abandonmentUnlockHash, List<InventoryItemSetDataBlockItem> itemList, string questLineDescription,
            string questLineName, string questStepSummary, bool requireOrderedSetItemAdd, bool setIsFeatured, string setType, uint trackingUnlockValueHash)
        {
            AbandonmentUnlockHash = abandonmentUnlockHash;
            ItemList = itemList;
            QuestLineDescription = questLineDescription;
            QuestLineName = questLineName;
            QuestStepSummary = questStepSummary;
            RequireOrderedSetItemAdd = requireOrderedSetItemAdd;
            SetIsFeatured = setIsFeatured;
            SetType = setType;
            TrackingUnlockValueHash = trackingUnlockValueHash;
        }
    }
}
