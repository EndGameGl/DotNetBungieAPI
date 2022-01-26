namespace DotNetBungieAPI.Generated.Models.Destiny.Responses;

/// <summary>
///     A response containing all valid components for the public Vendors endpoint.
/// <para />
///      It is a decisively smaller subset of data compared to what we can get when we know the specific user making the request.
/// <para />
///      If you want any of the other data - item details, whether or not you can buy it, etc... you'll have to call in the context of a character. I know, sad but true.
/// </summary>
public class DestinyPublicVendorsResponse : IDeepEquatable<DestinyPublicVendorsResponse>
{
    /// <summary>
    ///     For Vendors being returned, this will give you the information you need to group them and order them in the same way that the Bungie Companion app performs grouping. It will automatically be returned if you request the Vendors component.
    /// <para />
    ///     COMPONENT TYPE: Vendors
    /// </summary>
    [JsonPropertyName("vendorGroups")]
    public SingleComponentResponseOfDestinyVendorGroupComponent VendorGroups { get; set; }

    /// <summary>
    ///     The base properties of the vendor. These are keyed by the Vendor Hash, so you will get one Vendor Component per vendor returned.
    /// <para />
    ///     COMPONENT TYPE: Vendors
    /// </summary>
    [JsonPropertyName("vendors")]
    public DictionaryComponentResponseOfuint32AndDestinyPublicVendorComponent Vendors { get; set; }

    /// <summary>
    ///     Categories that the vendor has available, and references to the sales therein. These are keyed by the Vendor Hash, so you will get one Categories Component per vendor returned.
    /// <para />
    ///     COMPONENT TYPE: VendorCategories
    /// </summary>
    [JsonPropertyName("categories")]
    public DictionaryComponentResponseOfuint32AndDestinyVendorCategoriesComponent Categories { get; set; }

    /// <summary>
    ///     Sales, keyed by the vendorItemIndex of the item being sold. These are keyed by the Vendor Hash, so you will get one Sale Item Set Component per vendor returned.
    /// <para />
    ///     Note that within the Sale Item Set component, the sales are themselves keyed by the vendorSaleIndex, so you can relate it to the corrent sale item definition within the Vendor's definition.
    /// <para />
    ///     COMPONENT TYPE: VendorSales
    /// </summary>
    [JsonPropertyName("sales")]
    public DictionaryComponentResponseOfuint32AndPublicDestinyVendorSaleItemSetComponent Sales { get; set; }

    /// <summary>
    ///     A set of string variable values by hash for a public vendors context.
    /// <para />
    ///     COMPONENT TYPE: StringVariables
    /// </summary>
    [JsonPropertyName("stringVariables")]
    public SingleComponentResponseOfDestinyStringVariablesComponent StringVariables { get; set; }

    public bool DeepEquals(DestinyPublicVendorsResponse? other)
    {
        return other is not null &&
               (VendorGroups is not null ? VendorGroups.DeepEquals(other.VendorGroups) : other.VendorGroups is null) &&
               (Vendors is not null ? Vendors.DeepEquals(other.Vendors) : other.Vendors is null) &&
               (Categories is not null ? Categories.DeepEquals(other.Categories) : other.Categories is null) &&
               (Sales is not null ? Sales.DeepEquals(other.Sales) : other.Sales is null) &&
               (StringVariables is not null ? StringVariables.DeepEquals(other.StringVariables) : other.StringVariables is null);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyPublicVendorsResponse? other)
    {
        if (other is null) return;
        if (!VendorGroups.DeepEquals(other.VendorGroups))
        {
            VendorGroups.Update(other.VendorGroups);
            OnPropertyChanged(nameof(VendorGroups));
        }
        if (!Vendors.DeepEquals(other.Vendors))
        {
            Vendors.Update(other.Vendors);
            OnPropertyChanged(nameof(Vendors));
        }
        if (!Categories.DeepEquals(other.Categories))
        {
            Categories.Update(other.Categories);
            OnPropertyChanged(nameof(Categories));
        }
        if (!Sales.DeepEquals(other.Sales))
        {
            Sales.Update(other.Sales);
            OnPropertyChanged(nameof(Sales));
        }
        if (!StringVariables.DeepEquals(other.StringVariables))
        {
            StringVariables.Update(other.StringVariables);
            OnPropertyChanged(nameof(StringVariables));
        }
    }
}