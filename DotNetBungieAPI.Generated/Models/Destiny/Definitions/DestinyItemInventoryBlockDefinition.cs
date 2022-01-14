namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     If the item can exist in an inventory - the overwhelming majority of them can and do - then this is the basic properties regarding the item's relationship with the inventory.
/// </summary>
public sealed class DestinyItemInventoryBlockDefinition
{

    /// <summary>
    ///     If this string is populated, you can't have more than one stack with this label in a given inventory. Note that this is different from the equipping block's unique label, which is used for equipping uniqueness.
    /// </summary>
    [JsonPropertyName("stackUniqueLabel")]
    public string StackUniqueLabel { get; init; }

    /// <summary>
    ///     The maximum quantity of this item that can exist in a stack.
    /// </summary>
    [JsonPropertyName("maxStackSize")]
    public int MaxStackSize { get; init; }

    /// <summary>
    ///     The hash identifier for the DestinyInventoryBucketDefinition to which this item belongs. I should have named this "bucketHash", but too many things refer to it now. Sigh.
    /// </summary>
    [JsonPropertyName("bucketTypeHash")]
    public uint BucketTypeHash { get; init; } // DestinyInventoryBucketDefinition

    /// <summary>
    ///     If the item is picked up by the lost loot queue, this is the hash identifier for the DestinyInventoryBucketDefinition into which it will be placed. Again, I should have named this recoveryBucketHash instead.
    /// </summary>
    [JsonPropertyName("recoveryBucketTypeHash")]
    public uint RecoveryBucketTypeHash { get; init; } // DestinyInventoryBucketDefinition

    /// <summary>
    ///     The hash identifier for the Tier Type of the item, use to look up its DestinyItemTierTypeDefinition if you need to show localized data for the item's tier.
    /// </summary>
    [JsonPropertyName("tierTypeHash")]
    public uint TierTypeHash { get; init; } // DestinyItemTierTypeDefinition

    /// <summary>
    ///     If TRUE, this item is instanced. Otherwise, it is a generic item that merely has a quantity in a stack (like Glimmer).
    /// </summary>
    [JsonPropertyName("isInstanceItem")]
    public bool IsInstanceItem { get; init; }

    /// <summary>
    ///     The localized name of the tier type, which is a useful shortcut so you don't have to look up the definition every time. However, it's mostly a holdover from days before we had a DestinyItemTierTypeDefinition to refer to.
    /// </summary>
    [JsonPropertyName("tierTypeName")]
    public string TierTypeName { get; init; }

    /// <summary>
    ///     The enumeration matching the tier type of the item to known values, again for convenience sake.
    /// </summary>
    [JsonPropertyName("tierType")]
    public Destiny.TierType TierType { get; init; }

    /// <summary>
    ///     The tooltip message to show, if any, when the item expires.
    /// </summary>
    [JsonPropertyName("expirationTooltip")]
    public string ExpirationTooltip { get; init; }

    /// <summary>
    ///     If the item expires while playing in an activity, we show a different message.
    /// </summary>
    [JsonPropertyName("expiredInActivityMessage")]
    public string ExpiredInActivityMessage { get; init; }

    /// <summary>
    ///     If the item expires in orbit, we show a... more different message. ("Consummate V's, consummate!")
    /// </summary>
    [JsonPropertyName("expiredInOrbitMessage")]
    public string ExpiredInOrbitMessage { get; init; }

    [JsonPropertyName("suppressExpirationWhenObjectivesComplete")]
    public bool SuppressExpirationWhenObjectivesComplete { get; init; }
}
