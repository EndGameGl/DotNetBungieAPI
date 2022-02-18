namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     If the item can exist in an inventory - the overwhelming majority of them can and do - then this is the basic properties regarding the item's relationship with the inventory.
/// </summary>
public class DestinyItemInventoryBlockDefinition : IDeepEquatable<DestinyItemInventoryBlockDefinition>
{
    /// <summary>
    ///     If this string is populated, you can't have more than one stack with this label in a given inventory. Note that this is different from the equipping block's unique label, which is used for equipping uniqueness.
    /// </summary>
    [JsonPropertyName("stackUniqueLabel")]
    public string StackUniqueLabel { get; set; }

    /// <summary>
    ///     The maximum quantity of this item that can exist in a stack.
    /// </summary>
    [JsonPropertyName("maxStackSize")]
    public int MaxStackSize { get; set; }

    /// <summary>
    ///     The hash identifier for the DestinyInventoryBucketDefinition to which this item belongs. I should have named this "bucketHash", but too many things refer to it now. Sigh.
    /// </summary>
    [JsonPropertyName("bucketTypeHash")]
    public uint BucketTypeHash { get; set; }

    /// <summary>
    ///     If the item is picked up by the lost loot queue, this is the hash identifier for the DestinyInventoryBucketDefinition into which it will be placed. Again, I should have named this recoveryBucketHash instead.
    /// </summary>
    [JsonPropertyName("recoveryBucketTypeHash")]
    public uint RecoveryBucketTypeHash { get; set; }

    /// <summary>
    ///     The hash identifier for the Tier Type of the item, use to look up its DestinyItemTierTypeDefinition if you need to show localized data for the item's tier.
    /// </summary>
    [JsonPropertyName("tierTypeHash")]
    public uint TierTypeHash { get; set; }

    /// <summary>
    ///     If TRUE, this item is instanced. Otherwise, it is a generic item that merely has a quantity in a stack (like Glimmer).
    /// </summary>
    [JsonPropertyName("isInstanceItem")]
    public bool IsInstanceItem { get; set; }

    /// <summary>
    ///     The localized name of the tier type, which is a useful shortcut so you don't have to look up the definition every time. However, it's mostly a holdover from days before we had a DestinyItemTierTypeDefinition to refer to.
    /// </summary>
    [JsonPropertyName("tierTypeName")]
    public string TierTypeName { get; set; }

    /// <summary>
    ///     The enumeration matching the tier type of the item to known values, again for convenience sake.
    /// </summary>
    [JsonPropertyName("tierType")]
    public Destiny.TierType TierType { get; set; }

    /// <summary>
    ///     The tooltip message to show, if any, when the item expires.
    /// </summary>
    [JsonPropertyName("expirationTooltip")]
    public string ExpirationTooltip { get; set; }

    /// <summary>
    ///     If the item expires while playing in an activity, we show a different message.
    /// </summary>
    [JsonPropertyName("expiredInActivityMessage")]
    public string ExpiredInActivityMessage { get; set; }

    /// <summary>
    ///     If the item expires in orbit, we show a... more different message. ("Consummate V's, consummate!")
    /// </summary>
    [JsonPropertyName("expiredInOrbitMessage")]
    public string ExpiredInOrbitMessage { get; set; }

    [JsonPropertyName("suppressExpirationWhenObjectivesComplete")]
    public bool SuppressExpirationWhenObjectivesComplete { get; set; }

    /// <summary>
    ///     A reference to the associated crafting 'recipe' item definition, if this item can be crafted.
    /// </summary>
    [JsonPropertyName("recipeItemHash")]
    public uint? RecipeItemHash { get; set; }

    public bool DeepEquals(DestinyItemInventoryBlockDefinition? other)
    {
        return other is not null &&
               StackUniqueLabel == other.StackUniqueLabel &&
               MaxStackSize == other.MaxStackSize &&
               BucketTypeHash == other.BucketTypeHash &&
               RecoveryBucketTypeHash == other.RecoveryBucketTypeHash &&
               TierTypeHash == other.TierTypeHash &&
               IsInstanceItem == other.IsInstanceItem &&
               TierTypeName == other.TierTypeName &&
               TierType == other.TierType &&
               ExpirationTooltip == other.ExpirationTooltip &&
               ExpiredInActivityMessage == other.ExpiredInActivityMessage &&
               ExpiredInOrbitMessage == other.ExpiredInOrbitMessage &&
               SuppressExpirationWhenObjectivesComplete == other.SuppressExpirationWhenObjectivesComplete &&
               RecipeItemHash == other.RecipeItemHash;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyItemInventoryBlockDefinition? other)
    {
        if (other is null) return;
        if (StackUniqueLabel != other.StackUniqueLabel)
        {
            StackUniqueLabel = other.StackUniqueLabel;
            OnPropertyChanged(nameof(StackUniqueLabel));
        }
        if (MaxStackSize != other.MaxStackSize)
        {
            MaxStackSize = other.MaxStackSize;
            OnPropertyChanged(nameof(MaxStackSize));
        }
        if (BucketTypeHash != other.BucketTypeHash)
        {
            BucketTypeHash = other.BucketTypeHash;
            OnPropertyChanged(nameof(BucketTypeHash));
        }
        if (RecoveryBucketTypeHash != other.RecoveryBucketTypeHash)
        {
            RecoveryBucketTypeHash = other.RecoveryBucketTypeHash;
            OnPropertyChanged(nameof(RecoveryBucketTypeHash));
        }
        if (TierTypeHash != other.TierTypeHash)
        {
            TierTypeHash = other.TierTypeHash;
            OnPropertyChanged(nameof(TierTypeHash));
        }
        if (IsInstanceItem != other.IsInstanceItem)
        {
            IsInstanceItem = other.IsInstanceItem;
            OnPropertyChanged(nameof(IsInstanceItem));
        }
        if (TierTypeName != other.TierTypeName)
        {
            TierTypeName = other.TierTypeName;
            OnPropertyChanged(nameof(TierTypeName));
        }
        if (TierType != other.TierType)
        {
            TierType = other.TierType;
            OnPropertyChanged(nameof(TierType));
        }
        if (ExpirationTooltip != other.ExpirationTooltip)
        {
            ExpirationTooltip = other.ExpirationTooltip;
            OnPropertyChanged(nameof(ExpirationTooltip));
        }
        if (ExpiredInActivityMessage != other.ExpiredInActivityMessage)
        {
            ExpiredInActivityMessage = other.ExpiredInActivityMessage;
            OnPropertyChanged(nameof(ExpiredInActivityMessage));
        }
        if (ExpiredInOrbitMessage != other.ExpiredInOrbitMessage)
        {
            ExpiredInOrbitMessage = other.ExpiredInOrbitMessage;
            OnPropertyChanged(nameof(ExpiredInOrbitMessage));
        }
        if (SuppressExpirationWhenObjectivesComplete != other.SuppressExpirationWhenObjectivesComplete)
        {
            SuppressExpirationWhenObjectivesComplete = other.SuppressExpirationWhenObjectivesComplete;
            OnPropertyChanged(nameof(SuppressExpirationWhenObjectivesComplete));
        }
        if (RecipeItemHash != other.RecipeItemHash)
        {
            RecipeItemHash = other.RecipeItemHash;
            OnPropertyChanged(nameof(RecipeItemHash));
        }
    }
}