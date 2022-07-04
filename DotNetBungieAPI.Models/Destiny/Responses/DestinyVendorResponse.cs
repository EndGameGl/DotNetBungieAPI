using DotNetBungieAPI.Models.Destiny.Components;

namespace DotNetBungieAPI.Models.Destiny.Responses;

/// <summary>
///     A response containing all of the components for a vendor.
/// </summary>
public sealed record DestinyVendorResponse
{
    /// <summary>
    ///     The base properties of the vendor.
    /// </summary>
    [JsonPropertyName("vendor")]
    public SingleComponentResponseOfDestinyVendorComponent Vendor { get; init; }

    /// <summary>
    ///     Categories that the vendor has available, and references to the sales therein.
    /// </summary>
    [JsonPropertyName("categories")]
    public SingleComponentResponseOfDestinyVendorCategoriesComponent Categories { get; init; }

    /// <summary>
    ///     Sales, keyed by the vendorItemIndex of the item being sold.
    /// </summary>
    [JsonPropertyName("sales")]
    public DictionaryComponentResponseOfint32AndDestinyVendorSaleItemComponent Sales { get; init; }

    /// <summary>
    ///     Item components, keyed by the vendorItemIndex of the active sale items.
    /// </summary>
    [JsonPropertyName("itemComponents")]
    public DestinyItemComponentSetOfint32 ItemComponents { get; init; }

    /// <summary>
    ///     A "lookup" convenience component that can be used to quickly check if the character has access to items that can be
    ///     used for purchasing.
    /// </summary>
    [JsonPropertyName("currencyLookups")]
    public SingleComponentResponseOfDestinyCurrenciesComponent CurrencyLookups { get; init; }

    /// <summary>
    ///     A map of string variable values by hash for this character context.
    /// </summary>
    [JsonPropertyName("stringVariables")]
    public SingleComponentResponseOfDestinyStringVariablesComponent StringVariables { get; init; }
}