using NetBungieAPI.Models.Destiny.Definitions.EquipmentSlots;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// Items that can be equipped define this block. It contains information we need to understand how and when the item can be equipped.
    /// </summary>
    public sealed record DestinyEquippingBlockDefinition : IDeepEquatable<DestinyEquippingBlockDefinition>
    {
        /// <summary>
        /// If the item is part of a gearset, this is a reference to that gearset item.
        /// </summary>
        [JsonPropertyName("gearsetItemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> GearsetItem { get; init; }
        /// <summary>
        /// Ammo type used by a weapon is no longer determined by the bucket in which it is contained. If the item has an ammo type - i.e. if it is a weapon - this will be the type of ammunition expected.
        /// </summary>
        [JsonPropertyName("ammoType")]
        public DestinyAmmunitionType AmmoType { get; init; }
        /// <summary>
        /// These are custom attributes on the equippability of the item.
        /// </summary>
        [JsonPropertyName("attributes")]
        public EquippingItemBlockAttributes Attributes { get; init; }
        /// <summary>
        /// These are strings that represent the possible Game/Account/Character state failure conditions that can occur when trying to equip the item. They match up one-to-one with requiredUnlockExpressions.
        /// </summary>
        [JsonPropertyName("displayStrings")]
        public ReadOnlyCollection<string> DisplayStrings { get; init; } = Defaults.EmptyReadOnlyCollection<string>();
        /// <summary>
        /// An equipped item *must* be equipped in an Equipment Slot.
        /// </summary>
        [JsonPropertyName("equipmentSlotTypeHash")]
        public DefinitionHashPointer<DestinyEquipmentSlotDefinition> EquipmentSlotType { get; init; }
        [JsonPropertyName("equippingSoundHash")]
        public uint EquippingSoundHash { get; init; }
        [JsonPropertyName("hornSoundHash")]
        public uint HornSoundHash { get; init; }
        /// <summary>
        /// If defined, this is the label used to check if the item has other items of matching types already equipped.
        /// <para/>
        /// For instance, when you aren't allowed to equip more than one Exotic Weapon, that's because all exotic weapons have identical uniqueLabels and the game checks the to-be-equipped item's uniqueLabel vs. all other already equipped items (other than the item in the slot that's about to be occupied).
        /// </summary>
        [JsonPropertyName("uniqueLabel")]
        public string UniqueLabel { get; init; }
        /// <summary>
        /// The hash of that unique label. Does not point to a specific definition.
        /// </summary>
        [JsonPropertyName("uniqueLabelHash")]
        public uint UniqueLabelHash { get; init; }

        public bool DeepEquals(DestinyEquippingBlockDefinition other)
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
