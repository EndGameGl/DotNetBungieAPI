namespace DotNetBungieAPI.Generated.Models.Destiny.Responses;

/// <summary>
///     A response containing all of the components for all requested vendors.
/// </summary>
public class DestinyVendorsResponse
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
    public DictionaryComponentResponseOfuint32AndDestinyVendorComponent Vendors { get; set; }

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
    public DictionaryComponentResponseOfuint32AndPersonalDestinyVendorSaleItemSetComponent Sales { get; set; }

    /// <summary>
    ///     The set of item detail components, one set of item components per Vendor. These are keyed by the Vendor Hash, so you will get one Item Component Set per vendor returned.
    /// <para />
    ///     The components contained inside are themselves keyed by the vendorSaleIndex, and will have whatever item-level components you requested (Sockets, Stats, Instance data etc...) per item being sold by the vendor.
    /// </summary>
    [JsonPropertyName("itemComponents")]
    public Dictionary<uint, DestinyItemComponentSetOfint32> ItemComponents { get; set; }

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
}
