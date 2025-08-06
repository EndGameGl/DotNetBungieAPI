namespace DotNetBungieAPI.Models.Destiny.Responses;

/// <summary>
///     A response containing all of the components for a vendor.
/// </summary>
public sealed class DestinyVendorResponse
{
    /// <summary>
    ///     The base properties of the vendor.
    /// <para />
    ///     COMPONENT TYPE: Vendors
    /// </summary>
    [JsonPropertyName("vendor")]
    public SingleComponentResponseOfDestinyVendorComponent? Vendor { get; init; }

    /// <summary>
    ///     Categories that the vendor has available, and references to the sales therein.
    /// <para />
    ///     COMPONENT TYPE: VendorCategories
    /// </summary>
    [JsonPropertyName("categories")]
    public SingleComponentResponseOfDestinyVendorCategoriesComponent? Categories { get; init; }

    /// <summary>
    ///     Sales, keyed by the vendorItemIndex of the item being sold.
    /// <para />
    ///     COMPONENT TYPE: VendorSales
    /// </summary>
    [JsonPropertyName("sales")]
    public DictionaryComponentResponseOfint32AndDestinyVendorSaleItemComponent? Sales { get; init; }

    /// <summary>
    ///     Item components, keyed by the vendorItemIndex of the active sale items.
    /// <para />
    ///     COMPONENT TYPE: [See inside the DestinyVendorItemComponentSet contract for component types.]
    /// </summary>
    [JsonPropertyName("itemComponents")]
    public DestinyVendorItemComponentSetOfint32? ItemComponents { get; init; }

    /// <summary>
    ///     A "lookup" convenience component that can be used to quickly check if the character has access to items that can be used for purchasing.
    /// <para />
    ///     COMPONENT TYPE: CurrencyLookups
    /// </summary>
    [JsonPropertyName("currencyLookups")]
    public SingleComponentResponseOfDestinyCurrenciesComponent? CurrencyLookups { get; init; }

    /// <summary>
    ///     A map of string variable values by hash for this character context.
    /// <para />
    ///     COMPONENT TYPE: StringVariables
    /// </summary>
    [JsonPropertyName("stringVariables")]
    public SingleComponentResponseOfDestinyStringVariablesComponent? StringVariables { get; init; }
}
