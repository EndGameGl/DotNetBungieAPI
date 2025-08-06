namespace DotNetBungieAPI.Models.Destiny.Definitions.Items;

public sealed class DestinyParentItemOverride
{
    [JsonPropertyName("additionalEquipRequirementsDisplayStrings")]
    public string[]? AdditionalEquipRequirementsDisplayStrings { get; init; }

    [JsonPropertyName("pipIcon")]
    public string PipIcon { get; init; }
}
