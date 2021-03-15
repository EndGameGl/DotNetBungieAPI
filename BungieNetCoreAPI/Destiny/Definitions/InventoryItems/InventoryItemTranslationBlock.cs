﻿using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// This Block defines the rendering data associated with the item, if any.
    /// </summary>
    public class InventoryItemTranslationBlock : IDeepEquatable<InventoryItemTranslationBlock>
    {
        public ReadOnlyCollection<InventoryItemTranslationBlockArrangement> Arrangements { get; }
        public ReadOnlyCollection<InventoryItemTranslationBlockDye> CustomDyes { get; }
        public ReadOnlyCollection<InventoryItemTranslationBlockDye> DefaultDyes { get; }
        public bool HasGeometry { get; }
        public ReadOnlyCollection<InventoryItemTranslationBlockDye> LockedDyes { get; }
        public uint WeaponPatternHash { get; }
        public string WeaponPatternIdentifier { get; }

        [JsonConstructor]
        internal InventoryItemTranslationBlock(InventoryItemTranslationBlockArrangement[] arrangements, InventoryItemTranslationBlockDye[] customDyes, 
            InventoryItemTranslationBlockDye[] defaultDyes, bool hasGeometry, InventoryItemTranslationBlockDye[] lockedDyes, uint weaponPatternHash,
            string weaponPatternIdentifier)
        {
            Arrangements = arrangements.AsReadOnlyOrEmpty();
            CustomDyes = customDyes.AsReadOnlyOrEmpty();
            DefaultDyes = defaultDyes.AsReadOnlyOrEmpty();
            HasGeometry = hasGeometry;
            LockedDyes = lockedDyes.AsReadOnlyOrEmpty();
            WeaponPatternHash = weaponPatternHash;
            WeaponPatternIdentifier = weaponPatternIdentifier;
        }

        public bool DeepEquals(InventoryItemTranslationBlock other)
        {
            return other != null &&
                   Arrangements.DeepEqualsReadOnlyCollections(other.Arrangements) &&
                   CustomDyes.DeepEqualsReadOnlyCollections(other.CustomDyes) &&
                   DefaultDyes.DeepEqualsReadOnlyCollections(other.DefaultDyes) &&
                   HasGeometry == other.HasGeometry &&
                   LockedDyes.DeepEqualsReadOnlyCollections(other.LockedDyes) &&
                   WeaponPatternHash == other.WeaponPatternHash &&
                   WeaponPatternIdentifier == other.WeaponPatternIdentifier;
        }
    }
}
