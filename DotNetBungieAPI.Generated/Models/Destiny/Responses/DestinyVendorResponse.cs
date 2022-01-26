namespace DotNetBungieAPI.Generated.Models.Destiny.Responses;

/// <summary>
///     A response containing all of the components for a vendor.
/// </summary>
public class DestinyVendorResponse : IDeepEquatable<DestinyVendorResponse>
{
    /// <summary>
    ///     The base properties of the vendor.
    /// <para />
    ///     COMPONENT TYPE: Vendors
    /// </summary>
    [JsonPropertyName("vendor")]
    public SingleComponentResponseOfDestinyVendorComponent Vendor { get; set; }

    /// <summary>
    ///     Categories that the vendor has available, and references to the sales therein.
    /// <para />
    ///     COMPONENT TYPE: VendorCategories
    /// </summary>
    [JsonPropertyName("categories")]
    public SingleComponentResponseOfDestinyVendorCategoriesComponent Categories { get; set; }

    /// <summary>
    ///     Sales, keyed by the vendorItemIndex of the item being sold.
    /// <para />
    ///     COMPONENT TYPE: VendorSales
    /// </summary>
    [JsonPropertyName("sales")]
    public DictionaryComponentResponseOfint32AndDestinyVendorSaleItemComponent Sales { get; set; }

    /// <summary>
    ///     Item components, keyed by the vendorItemIndex of the active sale items.
    /// <para />
    ///     COMPONENT TYPE: [See inside the DestinyItemComponentSet contract for component types.]
    /// </summary>
    [JsonPropertyName("itemComponents")]
    public DestinyItemComponentSetOfint32 ItemComponents { get; set; }

    /// <summary>
    ///     A "lookup" convenience component that can be used to quickly check if the character has access to items that can be used for purchasing.
    /// <para />
    ///     COMPONENT TYPE: CurrencyLookups
    /// </summary>
    [JsonPropertyName("currencyLookups")]
    public SingleComponentResponseOfDestinyCurrenciesComponent CurrencyLookups { get; set; }

    /// <summary>
    ///     A map of string variable values by hash for this character context.
    /// <para />
    ///     COMPONENT TYPE: StringVariables
    /// </summary>
    [JsonPropertyName("stringVariables")]
    public SingleComponentResponseOfDestinyStringVariablesComponent StringVariables { get; set; }

    public bool DeepEquals(DestinyVendorResponse? other)
    {
        return other is not null &&
               (Vendor is not null ? Vendor.DeepEquals(other.Vendor) : other.Vendor is null) &&
               (Categories is not null ? Categories.DeepEquals(other.Categories) : other.Categories is null) &&
               (Sales is not null ? Sales.DeepEquals(other.Sales) : other.Sales is null) &&
               (ItemComponents is not null ? ItemComponents.DeepEquals(other.ItemComponents) : other.ItemComponents is null) &&
               (CurrencyLookups is not null ? CurrencyLookups.DeepEquals(other.CurrencyLookups) : other.CurrencyLookups is null) &&
               (StringVariables is not null ? StringVariables.DeepEquals(other.StringVariables) : other.StringVariables is null);
    }
}