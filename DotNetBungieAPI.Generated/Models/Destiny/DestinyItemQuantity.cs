namespace DotNetBungieAPI.Generated.Models.Destiny;

/// <summary>
///     Used in a number of Destiny contracts to return data about an item stack and its quantity. Can optionally return an itemInstanceId if the item is instanced - in which case, the quantity returned will be 1. If it's not... uh, let me know okay? Thanks.
/// </summary>
public class DestinyItemQuantity : IDeepEquatable<DestinyItemQuantity>
{
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

    public bool DeepEquals(DestinyItemQuantity? other)
    {
        return other is not null &&
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

    public void Update(DestinyItemQuantity? other)
    {
        if (other is null) return;
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