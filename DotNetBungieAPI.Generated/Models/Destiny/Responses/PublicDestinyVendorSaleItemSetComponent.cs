namespace DotNetBungieAPI.Generated.Models.Destiny.Responses;

public class PublicDestinyVendorSaleItemSetComponent : IDeepEquatable<PublicDestinyVendorSaleItemSetComponent>
{
    [JsonPropertyName("saleItems")]
    public Dictionary<int, Destiny.Components.Vendors.DestinyPublicVendorSaleItemComponent> SaleItems { get; set; }

    public bool DeepEquals(PublicDestinyVendorSaleItemSetComponent? other)
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

    public void Update(PublicDestinyVendorSaleItemSetComponent? other)
    {
        if (other is null) return;
        if (!SaleItems.DeepEqualsDictionary(other.SaleItems))
        {
            SaleItems = other.SaleItems;
            OnPropertyChanged(nameof(SaleItems));
        }
    }
}