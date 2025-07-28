namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Items that can be equipped define this block. It contains information we need to understand how and when the item can be equipped.
/// </summary>
public class DestinyEquippingBlockDefinition
{
    /// <summary>
    ///     If the item is part of a gearset, this is a reference to that gearset item.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyInventoryItemDefinition>("Destiny.Definitions.DestinyInventoryItemDefinition")]
    [JsonPropertyName("gearsetItemHash")]
    public uint? GearsetItemHash { get; set; }

    /// <summary>
    ///     If defined, this is the label used to check if the item has other items of matching types already equipped. 
    /// <para />
    ///     For instance, when you aren't allowed to equip more than one Exotic Weapon, that's because all exotic weapons have identical uniqueLabels and the game checks the to-be-equipped item's uniqueLabel vs. all other already equipped items (other than the item in the slot that's about to be occupied).
    /// </summary>
    [JsonPropertyName("uniqueLabel")]
    public string UniqueLabel { get; set; }

    /// <summary>
    ///     The hash of that unique label. Does not point to a specific definition.
    /// </summary>
    [JsonPropertyName("uniqueLabelHash")]
    public uint UniqueLabelHash { get; set; }

    /// <summary>
    ///     An equipped item *must* be equipped in an Equipment Slot. This is the hash identifier of the DestinyEquipmentSlotDefinition into which it must be equipped.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyEquipmentSlotDefinition>("Destiny.Definitions.DestinyEquipmentSlotDefinition")]
    [JsonPropertyName("equipmentSlotTypeHash")]
    public uint EquipmentSlotTypeHash { get; set; }

    /// <summary>
    ///     These are custom attributes on the equippability of the item.
    /// <para />
    ///     For now, this can only be "equip on acquire", which would mean that the item will be automatically equipped as soon as you pick it up.
    /// </summary>
    [JsonPropertyName("attributes")]
    public Destiny.EquippingItemBlockAttributes Attributes { get; set; }

    /// <summary>
    ///     Ammo type used by a weapon is no longer determined by the bucket in which it is contained. If the item has an ammo type - i.e. if it is a weapon - this will be the type of ammunition expected.
    /// </summary>
    [JsonPropertyName("ammoType")]
    public Destiny.DestinyAmmunitionType AmmoType { get; set; }

    /// <summary>
    ///     These are strings that represent the possible Game/Account/Character state failure conditions that can occur when trying to equip the item. They match up one-to-one with requiredUnlockExpressions.
    /// </summary>
    [JsonPropertyName("displayStrings")]
    public string[]? DisplayStrings { get; set; }

    /// <summary>
    ///     If this item is part of an item set with bonus perks, this will the hash of that set.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.Items.DestinyEquipableItemSetDefinition>("Destiny.Definitions.Items.DestinyEquipableItemSetDefinition")]
    [JsonPropertyName("equipableItemSetHash")]
    public uint? EquipableItemSetHash { get; set; }
}
