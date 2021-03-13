using NetBungieApi.Destiny.Definitions.EquipmentSlots;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// Items that can be equipped define this block. It contains information we need to understand how and when the item can be equipped.
    /// </summary>
    public class InventoryItemEquippingBlock : IDeepEquatable<InventoryItemEquippingBlock>
    {
        /// <summary>
        /// If the item is part of a gearset, this is a reference to that gearset item.
        /// </summary>
        public DefinitionHashPointer<DestinyInventoryItemDefinition> GearsetItem { get; }
        /// <summary>
        /// Ammo type used by a weapon is no longer determined by the bucket in which it is contained. If the item has an ammo type - i.e. if it is a weapon - this will be the type of ammunition expected.
        /// </summary>
        public DestinyAmmoType AmmoType { get; }
        /// <summary>
        /// These are custom attributes on the equippability of the item.
        /// </summary>
        public EquippingBlockAttributes Attributes { get; }
        /// <summary>
        /// These are strings that represent the possible Game/Account/Character state failure conditions that can occur when trying to equip the item. They match up one-to-one with requiredUnlockExpressions.
        /// </summary>
        public ReadOnlyCollection<string> DisplayStrings { get; }
        /// <summary>
        /// An equipped item *must* be equipped in an Equipment Slot.
        /// </summary>
        public DefinitionHashPointer<DestinyEquipmentSlotDefinition> EquipmentSlotType { get; }
        public uint EquippingSoundHash { get; }
        public uint HornSoundHash { get; }
        /// <summary>
        /// If defined, this is the label used to check if the item has other items of matching types already equipped.
        /// <para/>
        /// For instance, when you aren't allowed to equip more than one Exotic Weapon, that's because all exotic weapons have identical uniqueLabels and the game checks the to-be-equipped item's uniqueLabel vs. all other already equipped items (other than the item in the slot that's about to be occupied).
        /// </summary>
        public string UniqueLabel { get; }
        /// <summary>
        /// The hash of that unique label. Does not point to a specific definition.
        /// </summary>
        public uint UniqueLabelHash { get; }

        [JsonConstructor]
        internal InventoryItemEquippingBlock(uint? gearsetItemHash, DestinyAmmoType ammoType, EquippingBlockAttributes attributes, string[] displayStrings, uint equipmentSlotTypeHash,
            uint equippingSoundHash, uint hornSoundHash, uint uniqueLabelHash, string uniqueLabel)
        {
            GearsetItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(gearsetItemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            AmmoType = ammoType;
            Attributes = attributes;
            DisplayStrings = displayStrings.AsReadOnlyOrEmpty();
            EquipmentSlotType = new DefinitionHashPointer<DestinyEquipmentSlotDefinition>(equipmentSlotTypeHash, DefinitionsEnum.DestinyEquipmentSlotDefinition);
            EquippingSoundHash = equippingSoundHash;
            HornSoundHash = hornSoundHash;
            UniqueLabelHash = uniqueLabelHash;
            UniqueLabel = uniqueLabel;
        }

        public bool DeepEquals(InventoryItemEquippingBlock other)
        {
            return other != null &&
                   GearsetItem.DeepEquals(other.GearsetItem) &&
                   AmmoType == other.AmmoType &&
                   Attributes == other.Attributes &&
                   DisplayStrings.DeepEqualsReadOnlySimpleCollection(other.DisplayStrings) &&
                   EquipmentSlotType.DeepEquals(other.EquipmentSlotType) &&
                   EquippingSoundHash == other.EquippingSoundHash &&
                   HornSoundHash == other.HornSoundHash &&
                   UniqueLabel == other.UniqueLabel &&
                   UniqueLabelHash == other.UniqueLabelHash;
        }
    }
}
