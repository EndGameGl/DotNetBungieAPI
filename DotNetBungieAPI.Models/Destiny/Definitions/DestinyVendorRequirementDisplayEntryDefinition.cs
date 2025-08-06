namespace DotNetBungieAPI.Models.Destiny.Definitions;

/// <summary>
///     The localized properties of the requirementsDisplay, allowing information about the requirement or item being featured to be seen.
/// </summary>
public sealed class DestinyVendorRequirementDisplayEntryDefinition
{
    [JsonPropertyName("icon")]
    public string Icon { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("source")]
    public string Source { get; init; }

    [JsonPropertyName("type")]
    public string Type { get; init; }
}
