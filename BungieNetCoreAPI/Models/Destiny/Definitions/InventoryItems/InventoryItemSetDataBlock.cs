using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// Primarily for Quests, this is the definition of properties related to the item if it is a quest and its various quest steps.
    /// </summary>
    public class InventoryItemSetDataBlock : IDeepEquatable<InventoryItemSetDataBlock>
    {     
        /// <summary>
        /// A collection of set items, for items such as Quest Metadata items that possess this data.
        /// </summary>
        public ReadOnlyCollection<InventoryItemSetDataBlockItem> ItemList { get; init; }
        /// <summary>
        /// The description of the quest line that this quest step is a part of.
        /// </summary>
        public string QuestLineDescription { get; init; }
        /// <summary>
        /// The name of the quest line that this quest step is a part of.
        /// </summary>
        public string QuestLineName { get; init; }
        /// <summary>
        /// An additional summary of this step in the quest line.
        /// </summary>
        public string QuestStepSummary { get; init; }
        /// <summary>
        /// If true, items in the set can only be added in increasing order, and adding an item will remove any previous item. For Quests, this is by necessity true. Only one quest step is present at a time, and previous steps are removed as you advance in the quest.
        /// </summary>
        public bool RequireOrderedSetItemAdd { get; init; }
        /// <summary>
        /// If true, the UI should treat this quest as "featured"
        /// </summary>
        public bool SetIsFeatured { get; init; }
        /// <summary>
        /// A string identifier we can use to attempt to identify the category of the Quest.
        /// </summary>
        public string SetType { get; init; }
        public uint TrackingUnlockValueHash { get; init; }
        public uint AbandonmentUnlockHash { get; init; }

        [JsonConstructor]
        internal InventoryItemSetDataBlock(uint abandonmentUnlockHash, InventoryItemSetDataBlockItem[] itemList, string questLineDescription,
            string questLineName, string questStepSummary, bool requireOrderedSetItemAdd, bool setIsFeatured, string setType, uint trackingUnlockValueHash)
        {
            AbandonmentUnlockHash = abandonmentUnlockHash;
            ItemList = itemList.AsReadOnlyOrEmpty();
            QuestLineDescription = questLineDescription;
            QuestLineName = questLineName;
            QuestStepSummary = questStepSummary;
            RequireOrderedSetItemAdd = requireOrderedSetItemAdd;
            SetIsFeatured = setIsFeatured;
            SetType = setType;
            TrackingUnlockValueHash = trackingUnlockValueHash;
        }

        public bool DeepEquals(InventoryItemSetDataBlock other)
        {
            return other != null &&
                   ItemList.DeepEqualsReadOnlyCollections(other.ItemList) &&
                   QuestLineDescription == other.QuestLineDescription &&
                   QuestLineName == other.QuestLineName &&
                   QuestStepSummary == other.QuestStepSummary &&
                   RequireOrderedSetItemAdd == other.RequireOrderedSetItemAdd &&
                   SetIsFeatured == other.SetIsFeatured &&
                   SetType == other.SetType &&
                   TrackingUnlockValueHash == other.TrackingUnlockValueHash &&
                   AbandonmentUnlockHash == other.AbandonmentUnlockHash;
        }
    }
}
