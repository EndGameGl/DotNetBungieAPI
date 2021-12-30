using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Items;

public sealed class DestinyParentItemOverride
{

    [JsonPropertyName("additionalEquipRequirementsDisplayStrings")]
    public List<string> AdditionalEquipRequirementsDisplayStrings { get; init; }

    [JsonPropertyName("pipIcon")]
    public string PipIcon { get; init; }
}
