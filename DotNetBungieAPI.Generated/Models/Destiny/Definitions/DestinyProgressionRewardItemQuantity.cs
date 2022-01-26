namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinyProgressionRewardItemQuantity : IDeepEquatable<DestinyProgressionRewardItemQuantity>
{
    [JsonPropertyName("rewardedAtProgressionLevel")]
    public int RewardedAtProgressionLevel { get; set; }

    [JsonPropertyName("acquisitionBehavior")]
    public Destiny.DestinyProgressionRewardItemAcquisitionBehavior AcquisitionBehavior { get; set; }

    [JsonPropertyName("uiDisplayStyle")]
    public string UiDisplayStyle { get; set; }

    [JsonPropertyName("claimUnlockDisplayStrings")]
    public List<string> ClaimUnlockDisplayStrings { get; set; }

    /// <summary>
    ///     The hash identifier for the item in question. Use it to look up the item's DestinyInventoryItemDefinition.
    /// </summary>
    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; set; }

    /// <summary>
    ///     If this quantity is referring to a specific instance of an item, this will have the item's instance ID. Normally, this will be null.
    /// </summary>
    [JsonPropertyName("itemInstanceId")]
    public long? ItemInstanceId { get; set; }

    /// <summary>
    ///     The amount of the item needed/available depending on the context of where DestinyItemQuantity is being used.
    /// </summary>
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    /// <summary>
    ///     Indicates that this item quantity may be conditionally shown or hidden, based on various sources of state. For example: server flags, account state, or character progress.
    /// </summary>
    [JsonPropertyName("hasConditionalVisibility")]
    public bool HasConditionalVisibility { get; set; }

    public bool DeepEquals(DestinyProgressionRewardItemQuantity? other)
    {
        return other is not null &&
               RewardedAtProgressionLevel == other.RewardedAtProgressionLevel &&
               AcquisitionBehavior == other.AcquisitionBehavior &&
               UiDisplayStyle == other.UiDisplayStyle &&
               ClaimUnlockDisplayStrings.DeepEqualsListNaive(other.ClaimUnlockDisplayStrings) &&
               ItemHash == other.ItemHash &&
               ItemInstanceId == other.ItemInstanceId &&
               Quantity == other.Quantity &&
               HasConditionalVisibility == other.HasConditionalVisibility;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyProgressionRewardItemQuantity? other)
    {
        if (other is null) return;
        if (RewardedAtProgressionLevel != other.RewardedAtProgressionLevel)
        {
            RewardedAtProgressionLevel = other.RewardedAtProgressionLevel;
            OnPropertyChanged(nameof(RewardedAtProgressionLevel));
        }
        if (AcquisitionBehavior != other.AcquisitionBehavior)
        {
            AcquisitionBehavior = other.AcquisitionBehavior;
            OnPropertyChanged(nameof(AcquisitionBehavior));
        }
        if (UiDisplayStyle != other.UiDisplayStyle)
        {
            UiDisplayStyle = other.UiDisplayStyle;
            OnPropertyChanged(nameof(UiDisplayStyle));
        }
        if (!ClaimUnlockDisplayStrings.DeepEqualsListNaive(other.ClaimUnlockDisplayStrings))
        {
            ClaimUnlockDisplayStrings = other.ClaimUnlockDisplayStrings;
            OnPropertyChanged(nameof(ClaimUnlockDisplayStrings));
        }
        if (ItemHash != other.ItemHash)
        {
            ItemHash = other.ItemHash;
            OnPropertyChanged(nameof(ItemHash));
        }
        if (ItemInstanceId != other.ItemInstanceId)
        {
            ItemInstanceId = other.ItemInstanceId;
            OnPropertyChanged(nameof(ItemInstanceId));
        }
        if (Quantity != other.Quantity)
        {
            Quantity = other.Quantity;
            OnPropertyChanged(nameof(Quantity));
        }
        if (HasConditionalVisibility != other.HasConditionalVisibility)
        {
            HasConditionalVisibility = other.HasConditionalVisibility;
            OnPropertyChanged(nameof(HasConditionalVisibility));
        }
    }
}