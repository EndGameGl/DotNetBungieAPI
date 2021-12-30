using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

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
