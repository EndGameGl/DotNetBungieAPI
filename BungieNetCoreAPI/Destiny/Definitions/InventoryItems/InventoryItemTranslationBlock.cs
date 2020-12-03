using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemTranslationBlock
    {
        public List<InventoryItemTranslationBlockArrangement> Arrangements { get; }
        public List<InventoryItemTranslationBlockDye> CustomDyes { get; }
        public List<InventoryItemTranslationBlockDye> DefaultDyes { get; }
        public bool HasGeometry { get; }
        public List<InventoryItemTranslationBlockDye> LockedDyes { get; }
        public uint WeaponPatternHash { get; }

        [JsonConstructor]
        private InventoryItemTranslationBlock(List<InventoryItemTranslationBlockArrangement> arrangements, List<InventoryItemTranslationBlockDye> customDyes, 
            List<InventoryItemTranslationBlockDye> defaultDyes, bool hasGeometry, List<InventoryItemTranslationBlockDye> lockedDyes, uint weaponPatternHash)
        {
            Arrangements = arrangements;
            CustomDyes = customDyes;
            DefaultDyes = defaultDyes;
            HasGeometry = hasGeometry;
            LockedDyes = lockedDyes;
            WeaponPatternHash = weaponPatternHash;
        }
    }
}
