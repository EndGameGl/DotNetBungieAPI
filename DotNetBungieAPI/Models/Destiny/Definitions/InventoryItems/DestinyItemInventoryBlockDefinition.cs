using DotNetBungieAPI.Models.Destiny.Definitions.InventoryBuckets;
using DotNetBungieAPI.Models.Destiny.Definitions.ItemTierTypes;
using DotNetBungieAPI.Models.Destiny.Definitions.UnlockValues;

namespace DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;

/// <summary>
///     If the item can exist in an inventory - the overwhelming majority of them can and do - then this is the basic
///     properties regarding the item's relationship with the inventory.
/// </summary>
public sealed record DestinyItemInventoryBlockDefinition : IDeepEquatable<DestinyItemInventoryBlockDefinition>
{
    /// <summary>
    ///     If this string is populated, you can't have more than one stack with this label in a given inventory. Note that
    ///     this is different from the equipping block's unique label, which is used for equipping uniqueness.
    /// </summary>
    [JsonPropertyName("stackUniqueLabel")]
    public string StackUniqueLabel { get; init; }

    /// <summary>
    ///     The DestinyInventoryBucketDefinition to which this item belongs.
    /// </summary>
    [JsonPropertyName("bucketTypeHash")]
    public DefinitionHashPointer<DestinyInventoryBucketDefinition> BucketType { get; init; } =
        DefinitionHashPointer<DestinyInventoryBucketDefinition>.Empty;

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
    ///     If the item expires in orbit, we show a... more different message.
    /// </summary>
    [JsonPropertyName("expiredInOrbitMessage")]
    public string ExpiredInOrbitMessage { get; init; }

    /// <summary>
    ///     If TRUE, this item is instanced. Otherwise, it is a generic item that merely has a quantity in a stack (like
    ///     Glimmer).
    /// </summary>
    [JsonPropertyName("isInstanceItem")]
    public bool IsInstanceItem { get; init; }

    /// <summary>
    ///     The maximum quantity of this item that can exist in a stack.
    /// </summary>
    [JsonPropertyName("maxStackSize")]
    public int MaxStackSize { get; init; }

    [JsonPropertyName("nonTransferrableOriginal")]
    public bool NonTransferrableOriginal { get; init; }

    /// <summary>
    ///     If the item is picked up by the lost loot queue, this is the DestinyInventoryBucketDefinition into which it will be
    ///     placed.
    /// </summary>
    [JsonPropertyName("recoveryBucketTypeHash")]
    public DefinitionHashPointer<DestinyInventoryBucketDefinition> RecoveryBucketType { get; init; } =
        DefinitionHashPointer<DestinyInventoryBucketDefinition>.Empty;

    [JsonPropertyName("suppressExpirationWhenObjectivesComplete")]
    public bool SuppressExpirationWhenObjectivesComplete { get; init; }
    
    /// <summary>
    ///     A reference to the associated crafting 'recipe' item definition, if this item can be crafted.
    /// </summary>
    [JsonPropertyName("recipeItemHash")]
    public DefinitionHashPointer<DestinyInventoryItemDefinition> RecipeItem { get; init; } 
        = DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

    /// <summary>
    ///     The enumeration matching the tier type of the item to known values, again for convenience sake.
    /// </summary>
    [JsonPropertyName("tierType")]
    public ItemTierType TierTypeEnumValue { get; init; }

    /// <summary>
    ///     Tier Type of the item, use to look up its DestinyItemTierTypeDefinition if you need to show localized data for the
    ///     item's tier.
    /// </summary>
    [JsonPropertyName("tierTypeHash")]
    public DefinitionHashPointer<DestinyItemTierTypeDefinition> TierType { get; init; }
        = DefinitionHashPointer<DestinyItemTierTypeDefinition>.Empty;

    /// <summary>
    ///     The localized name of the tier type, which is a useful shortcut so you don't have to look up the definition every
    ///     time. However, it's mostly a holdover from days before we had a DestinyItemTierTypeDefinition to refer to.
    /// </summary>
    [JsonPropertyName("tierTypeName")]
    public string TierTypeName { get; init; }

    public bool DeepEquals(DestinyItemInventoryBlockDefinition other)
    {
        return other != null &&
               StackUniqueLabel == other.StackUniqueLabel &&
               BucketType.DeepEquals(other.BucketType) &&
               ExpirationTooltip == other.ExpirationTooltip &&
               ExpiredInActivityMessage == other.ExpiredInActivityMessage &&
               ExpiredInOrbitMessage == other.ExpiredInOrbitMessage &&
               IsInstanceItem == other.IsInstanceItem &&
               MaxStackSize == other.MaxStackSize &&
               NonTransferrableOriginal == other.NonTransferrableOriginal &&
               RecoveryBucketType.DeepEquals(other.RecoveryBucketType) &&
               SuppressExpirationWhenObjectivesComplete == other.SuppressExpirationWhenObjectivesComplete &&
               TierTypeEnumValue == other.TierTypeEnumValue &&
               TierType.DeepEquals(other.TierType) &&
               TierTypeName == other.TierTypeName &&
               RecipeItem.DeepEquals(other.RecipeItem);
    }
}