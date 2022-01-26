namespace DotNetBungieAPI.Generated.Models.Destiny.Responses;

public class PersonalDestinyVendorSaleItemSetComponent : IDeepEquatable<PersonalDestinyVendorSaleItemSetComponent>
{
    [JsonPropertyName("saleItems")]
    public Dictionary<int, Destiny.Entities.Vendors.DestinyVendorSaleItemComponent> SaleItems { get; set; }

    public bool DeepEquals(PersonalDestinyVendorSaleItemSetComponent? other)
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

    public void Update(PersonalDestinyVendorSaleItemSetComponent? other)
    {
        if (other is null) return;
        if (!SaleItems.DeepEqualsDictionary(other.SaleItems))
        {
            SaleItems = other.SaleItems;
            OnPropertyChanged(nameof(SaleItems));
        }
    }
}