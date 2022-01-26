namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Vendors;

/// <summary>
///     Information about the category and items currently sold in that category.
/// </summary>
public class DestinyVendorCategory : IDeepEquatable<DestinyVendorCategory>
{
    /// <summary>
    ///     An index into the DestinyVendorDefinition.displayCategories property, so you can grab the display data for this category.
    /// </summary>
    [JsonPropertyName("displayCategoryIndex")]
    public int DisplayCategoryIndex { get; set; }

    /// <summary>
    ///     An ordered list of indexes into items being sold in this category (DestinyVendorDefinition.itemList) which will contain more information about the items being sold themselves. Can also be used to index into DestinyVendorSaleItemComponent data, if you asked for that data to be returned.
    /// </summary>
    [JsonPropertyName("itemIndexes")]
    public List<int> ItemIndexes { get; set; }

    public bool DeepEquals(DestinyVendorCategory? other)
    {
        return other is not null &&
               DisplayCategoryIndex == other.DisplayCategoryIndex &&
               ItemIndexes.DeepEqualsListNaive(other.ItemIndexes);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyVendorCategory? other)
    {
        if (other is null) return;
        if (DisplayCategoryIndex != other.DisplayCategoryIndex)
        {
            DisplayCategoryIndex = other.DisplayCategoryIndex;
            OnPropertyChanged(nameof(DisplayCategoryIndex));
        }
        if (!ItemIndexes.DeepEqualsListNaive(other.ItemIndexes))
        {
            ItemIndexes = other.ItemIndexes;
            OnPropertyChanged(nameof(ItemIndexes));
        }
    }
}