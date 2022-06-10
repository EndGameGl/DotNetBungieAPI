namespace DotNetBungieAPI.Generated.Models.Destiny.Responses;

/// <summary>
///     A response containing all of the components for a vendor.
/// </summary>
public class DestinyVendorResponse
{
    /// <summary>
    ///     The base properties of the vendor.
    /// <para />
    ///     COMPONENT TYPE: Vendors
    /// </summary>
    [JsonPropertyName("vendor")]
    public object Vendor { get; set; }

    /// <summary>
    ///     Categories that the vendor has available, and references to the sales therein.
    /// <para />
    ///     COMPONENT TYPE: VendorCategories
    /// </summary>
    [JsonPropertyName("categories")]
    public object Categories { get; set; }

    /// <summary>
    ///     Sales, keyed by the vendorItemIndex of the item being sold.
    /// <para />
    ///     COMPONENT TYPE: VendorSales
    /// </summary>
    [JsonPropertyName("sales")]
    public object Sales { get; set; }

    /// <summary>
    ///     Item components, keyed by the vendorItemIndex of the active sale items.
    /// <para />
    ///     COMPONENT TYPE: [See inside the DestinyItemComponentSet contract for component types.]
    /// </summary>
    [JsonPropertyName("itemComponents")]
    public object ItemComponents { get; set; }

    /// <summary>
    ///     A "lookup" convenience component that can be used to quickly check if the character has access to items that can be used for purchasing.
    /// <para />
    ///     COMPONENT TYPE: CurrencyLookups
    /// </summary>
    [JsonPropertyName("currencyLookups")]
    public object CurrencyLookups { get; set; }

    /// <summary>
    ///     A map of string variable values by hash for this character context.
    /// <para />
    ///     COMPONENT TYPE: StringVariables
    /// </summary>
    [JsonPropertyName("stringVariables")]
    public object StringVariables { get; set; }
}
