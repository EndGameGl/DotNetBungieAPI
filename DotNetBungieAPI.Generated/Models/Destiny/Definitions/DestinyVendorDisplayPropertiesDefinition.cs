using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyVendorDisplayPropertiesDefinition
{

    [JsonPropertyName("largeIcon")]
    public string LargeIcon { get; init; }

    [JsonPropertyName("subtitle")]
    public string Subtitle { get; init; }

    [JsonPropertyName("originalIcon")]
    public string OriginalIcon { get; init; }

    [JsonPropertyName("requirementsDisplay")]
    public List<Destiny.Definitions.DestinyVendorRequirementDisplayEntryDefinition> RequirementsDisplay { get; init; }

    [JsonPropertyName("smallTransparentIcon")]
    public string SmallTransparentIcon { get; init; }

    [JsonPropertyName("mapIcon")]
    public string MapIcon { get; init; }

    [JsonPropertyName("largeTransparentIcon")]
    public string LargeTransparentIcon { get; init; }

    [JsonPropertyName("description")]
    public string Description { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("icon")]
    public string Icon { get; init; }

    [JsonPropertyName("iconSequences")]
    public List<Destiny.Definitions.Common.DestinyIconSequenceDefinition> IconSequences { get; init; }

    [JsonPropertyName("highResIcon")]
    public string HighResIcon { get; init; }

    [JsonPropertyName("hasIcon")]
    public bool HasIcon { get; init; }
}
