namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     The localized properties of the requirementsDisplay, allowing information about the requirement or item being featured to be seen.
/// </summary>
public class DestinyVendorRequirementDisplayEntryDefinition
{
    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("source")]
    public string Source { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}
