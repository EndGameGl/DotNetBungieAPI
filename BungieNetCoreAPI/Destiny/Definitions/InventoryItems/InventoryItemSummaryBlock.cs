﻿using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemSummaryBlock : IDeepEquatable<InventoryItemSummaryBlock>
    {
        public int SortPriority { get; }

        [JsonConstructor]
        internal InventoryItemSummaryBlock(int sortPriority)
        {
            SortPriority = sortPriority;
        }

        public bool DeepEquals(InventoryItemSummaryBlock other)
        {
            return other != null && SortPriority == other.SortPriority;
        }
    }
}