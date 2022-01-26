namespace DotNetBungieAPI.Generated.Models;

public class DestinyVendorSaleItemSetComponentOfDestinyVendorSaleItemComponent : IDeepEquatable<DestinyVendorSaleItemSetComponentOfDestinyVendorSaleItemComponent>
{
    [JsonPropertyName("saleItems")]
    public Dictionary<int, Destiny.Entities.Vendors.DestinyVendorSaleItemComponent> SaleItems { get; set; }

    public bool DeepEquals(DestinyVendorSaleItemSetComponentOfDestinyVendorSaleItemComponent? other)
    {
        return other is not null &&
               SaleItems.DeepEqualsDictionary(other.SaleItems);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyVendorSaleItemSetComponentOfDestinyVendorSaleItemComponent? other)
    {
        if (other is null) return;
        if (!SaleItems.DeepEqualsDictionary(other.SaleItems))
        {
            SaleItems = other.SaleItems;
            OnPropertyChanged(nameof(SaleItems));
        }
    }
}