namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Display Categories are different from "categories" in that these are specifically for visual grouping and display of categories in Vendor UI. The "categories" structure is for validation of the contained items, and can be categorized entirely separately from "Display Categories", there need be and often will be no meaningful relationship between the two.
/// </summary>
public class DestinyDisplayCategoryDefinition
{
    [JsonPropertyName("index")]
    public int? Index { get; set; }

    /// <summary>
    ///     A string identifier for the display category.
    /// </summary>
    [JsonPropertyName("identifier")]
    public string? Identifier { get; set; }

    [JsonPropertyName("displayCategoryHash")]
    public uint? DisplayCategoryHash { get; set; }

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; set; }

    /// <summary>
    ///     If true, this category should be displayed in the "Banner" section of the vendor's UI.
    /// </summary>
    [JsonPropertyName("displayInBanner")]
    public bool? DisplayInBanner { get; set; }

    /// <summary>
    ///     If it exists, this is the hash identifier of a DestinyProgressionDefinition that represents the progression to show on this display category.
    /// <para />
    ///     Specific categories can now have thier own distinct progression, apparently. So that's cool.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyProgressionDefinition>("Destiny.Definitions.DestinyProgressionDefinition")]
    [JsonPropertyName("progressionHash")]
    public uint? ProgressionHash { get; set; }

    /// <summary>
    ///     If this category sorts items in a nonstandard way, this will be the way we sort.
    /// </summary>
    [JsonPropertyName("sortOrder")]
    public Destiny.VendorDisplayCategorySortOrder? SortOrder { get; set; }

    /// <summary>
    ///     An indicator of how the category will be displayed in the UI. It's up to you to do something cool or interesting in response to this, or just to treat it as a normal category.
    /// </summary>
    [JsonPropertyName("displayStyleHash")]
    public uint? DisplayStyleHash { get; set; }

    /// <summary>
    ///     An indicator of how the category will be displayed in the UI. It's up to you to do something cool or interesting in response to this, or just to treat it as a normal category.
    /// </summary>
    [JsonPropertyName("displayStyleIdentifier")]
    public string? DisplayStyleIdentifier { get; set; }
}
