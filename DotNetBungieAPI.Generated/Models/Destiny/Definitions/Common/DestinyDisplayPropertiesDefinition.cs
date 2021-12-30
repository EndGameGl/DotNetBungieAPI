using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Common;

public sealed class DestinyDisplayPropertiesDefinition
{

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
