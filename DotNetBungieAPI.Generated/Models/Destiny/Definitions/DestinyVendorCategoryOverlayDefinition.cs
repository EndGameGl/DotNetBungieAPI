using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     The details of an overlay prompt to show to a user. They are all fairly self-explanatory localized strings that can be shown.
/// </summary>
public sealed class DestinyVendorCategoryOverlayDefinition
{

    [JsonPropertyName("choiceDescription")]
    public string ChoiceDescription { get; init; }

    [JsonPropertyName("description")]
    public string Description { get; init; }

    [JsonPropertyName("icon")]
    public string Icon { get; init; }

    [JsonPropertyName("title")]
    public string Title { get; init; }

    /// <summary>
    ///     If this overlay has a currency item that it features, this is said featured item.
    /// </summary>
    [JsonPropertyName("currencyItemHash")]
    public uint? CurrencyItemHash { get; init; } // DestinyInventoryItemDefinition
}
