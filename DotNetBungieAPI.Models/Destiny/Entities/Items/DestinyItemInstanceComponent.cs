namespace DotNetBungieAPI.Models.Destiny.Entities.Items;

/// <summary>
///     If an item is "instanced", this will contain information about the item's instance that doesn't fit easily into other components. One might say this is the "essential" instance data for the item.
/// <para />
///     Items are instanced if they require information or state that can vary. For instance, weapons are Instanced: they are given a unique identifier, uniquely generated stats, and can have their properties altered. Non-instanced items have none of these things: for instance, Glimmer has no unique properties aside from how much of it you own.
/// <para />
///     You can tell from an item's definition whether it will be instanced or not by looking at the DestinyInventoryItemDefinition's definition.inventory.isInstanceItem property.
/// </summary>
public sealed class DestinyItemInstanceComponent
{
    /// <summary>
    ///     If the item has a damage type, this is the item's current damage type.
    /// </summary>
    [JsonPropertyName("damageType")]
    public Destiny.DamageType DamageType { get; init; }

    /// <summary>
    ///     The current damage type's hash, so you can look up localized info and icons for it.
    /// </summary>
    [JsonPropertyName("damageTypeHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyDamageTypeDefinition> DamageTypeHash { get; init; }

    /// <summary>
    ///     The item stat that we consider to be "primary" for the item. For instance, this would be "Attack" for Weapons or "Defense" for armor.
    /// </summary>
    [JsonPropertyName("primaryStat")]
    public Destiny.DestinyStat? PrimaryStat { get; init; }

    /// <summary>
    ///     The Item's "Level" has the most significant bearing on its stats, such as Light and Power.
    /// </summary>
    [JsonPropertyName("itemLevel")]
    public int ItemLevel { get; init; }

    /// <summary>
    ///     The "Quality" of the item has a lesser - but still impactful - bearing on stats like Light and Power.
    /// </summary>
    [JsonPropertyName("quality")]
    public int Quality { get; init; }

    /// <summary>
    ///     Is the item currently equipped on the given character?
    /// </summary>
    [JsonPropertyName("isEquipped")]
    public bool IsEquipped { get; init; }

    /// <summary>
    ///     If this is an equippable item, you can check it here. There are permanent as well as transitory reasons why an item might not be able to be equipped: check cannotEquipReason for details.
    /// </summary>
    [JsonPropertyName("canEquip")]
    public bool CanEquip { get; init; }

    /// <summary>
    ///     If the item cannot be equipped until you reach a certain level, that level will be reflected here.
    /// </summary>
    [JsonPropertyName("equipRequiredLevel")]
    public int EquipRequiredLevel { get; init; }

    /// <summary>
    ///     Sometimes, there are limitations to equipping that are represented by character-level flags called "unlocks".
    /// <para />
    ///     This is a list of flags that they need in order to equip the item that the character has not met. Use these to look up the descriptions to show in your UI by looking up the relevant DestinyUnlockDefinitions for the hashes.
    /// </summary>
    [JsonPropertyName("unlockHashesRequiredToEquip")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyUnlockDefinition>[]? UnlockHashesRequiredToEquip { get; init; }

    /// <summary>
    ///     If you cannot equip the item, this is a flags enum that enumerates all of the reasons why you couldn't equip the item. You may need to refine your UI further by using unlockHashesRequiredToEquip and equipRequiredLevel.
    /// </summary>
    [JsonPropertyName("cannotEquipReason")]
    public Destiny.EquipFailureReason CannotEquipReason { get; init; }

    /// <summary>
    ///     If populated, this item has a breaker type corresponding to the given value. See DestinyBreakerTypeDefinition for more details.
    /// </summary>
    [JsonPropertyName("breakerType")]
    public Destiny.DestinyBreakerType? BreakerType { get; init; }

    /// <summary>
    ///     If populated, this is the hash identifier for the item's breaker type. See DestinyBreakerTypeDefinition for more details.
    /// </summary>
    [JsonPropertyName("breakerTypeHash")]
    public DefinitionHashPointer<Destiny.Definitions.BreakerTypes.DestinyBreakerTypeDefinition> BreakerTypeHash { get; init; }

    /// <summary>
    ///     IF populated, this item supports Energy mechanics (i.e. Armor 2.0), and these are the current details of its energy type and available capacity to spend energy points.
    /// </summary>
    [JsonPropertyName("energy")]
    public Destiny.Entities.Items.DestinyItemInstanceEnergy? Energy { get; init; }

    /// <summary>
    ///     Gear Tier, if applicable, fished up from the unlock value items.gear_tier
    /// </summary>
    [JsonPropertyName("gearTier")]
    public int? GearTier { get; init; }
}
