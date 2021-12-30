using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

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

    [JsonPropertyName("currencyItemHash")]
    public uint? CurrencyItemHash { get; init; }
}
