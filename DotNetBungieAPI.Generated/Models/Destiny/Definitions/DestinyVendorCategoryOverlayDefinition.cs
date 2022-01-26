namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     The details of an overlay prompt to show to a user. They are all fairly self-explanatory localized strings that can be shown.
/// </summary>
public class DestinyVendorCategoryOverlayDefinition : IDeepEquatable<DestinyVendorCategoryOverlayDefinition>
{
    [JsonPropertyName("choiceDescription")]
    public string ChoiceDescription { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    /// <summary>
    ///     If this overlay has a currency item that it features, this is said featured item.
    /// </summary>
    [JsonPropertyName("currencyItemHash")]
    public uint? CurrencyItemHash { get; set; }

    public bool DeepEquals(DestinyVendorCategoryOverlayDefinition? other)
    {
        return other is not null &&
               ChoiceDescription == other.ChoiceDescription &&
               Description == other.Description &&
               Icon == other.Icon &&
               Title == other.Title &&
               CurrencyItemHash == other.CurrencyItemHash;
    }
}