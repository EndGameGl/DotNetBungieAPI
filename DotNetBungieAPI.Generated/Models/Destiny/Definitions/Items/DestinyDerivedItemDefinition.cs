namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Items;

/// <summary>
///     This is a reference to, and summary data for, a specific item that you can get as a result of Using or Acquiring some other Item (For example, this could be summary information for an Emote that you can get by opening an an Eververse Box) See DestinyDerivedItemCategoryDefinition for more information.
/// </summary>
public class DestinyDerivedItemDefinition : IDeepEquatable<DestinyDerivedItemDefinition>
{
    /// <summary>
    ///     The hash for the DestinyInventoryItemDefinition of this derived item, if there is one. Sometimes we are given this information as a manual override, in which case there won't be an actual DestinyInventoryItemDefinition for what we display, but you can still show the strings from this object itself.
    /// </summary>
    [JsonPropertyName("itemHash")]
    public uint? ItemHash { get; set; }

    /// <summary>
    ///     The name of the derived item.
    /// </summary>
    [JsonPropertyName("itemName")]
    public string ItemName { get; set; }

    /// <summary>
    ///     Additional details about the derived item, in addition to the description.
    /// </summary>
    [JsonPropertyName("itemDetail")]
    public string ItemDetail { get; set; }

    /// <summary>
    ///     A brief description of the item.
    /// </summary>
    [JsonPropertyName("itemDescription")]
    public string ItemDescription { get; set; }

    /// <summary>
    ///     An icon for the item.
    /// </summary>
    [JsonPropertyName("iconPath")]
    public string IconPath { get; set; }

    /// <summary>
    ///     If the item was derived from a "Preview Vendor", this will be an index into the DestinyVendorDefinition's itemList property. Otherwise, -1.
    /// </summary>
    [JsonPropertyName("vendorItemIndex")]
    public int VendorItemIndex { get; set; }

    public bool DeepEquals(DestinyDerivedItemDefinition? other)
    {
        return other is not null &&
               ItemHash == other.ItemHash &&
               ItemName == other.ItemName &&
               ItemDetail == other.ItemDetail &&
               ItemDescription == other.ItemDescription &&
               IconPath == other.IconPath &&
               VendorItemIndex == other.VendorItemIndex;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyDerivedItemDefinition? other)
    {
        if (other is null) return;
        if (ItemHash != other.ItemHash)
        {
            ItemHash = other.ItemHash;
            OnPropertyChanged(nameof(ItemHash));
        }
        if (ItemName != other.ItemName)
        {
            ItemName = other.ItemName;
            OnPropertyChanged(nameof(ItemName));
        }
        if (ItemDetail != other.ItemDetail)
        {
            ItemDetail = other.ItemDetail;
            OnPropertyChanged(nameof(ItemDetail));
        }
        if (ItemDescription != other.ItemDescription)
        {
            ItemDescription = other.ItemDescription;
            OnPropertyChanged(nameof(ItemDescription));
        }
        if (IconPath != other.IconPath)
        {
            IconPath = other.IconPath;
            OnPropertyChanged(nameof(IconPath));
        }
        if (VendorItemIndex != other.VendorItemIndex)
        {
            VendorItemIndex = other.VendorItemIndex;
            OnPropertyChanged(nameof(VendorItemIndex));
        }
    }
}