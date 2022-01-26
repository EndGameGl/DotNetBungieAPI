namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Items;

public class DestinyParentItemOverride : IDeepEquatable<DestinyParentItemOverride>
{
    [JsonPropertyName("additionalEquipRequirementsDisplayStrings")]
    public List<string> AdditionalEquipRequirementsDisplayStrings { get; set; }

    [JsonPropertyName("pipIcon")]
    public string PipIcon { get; set; }

    public bool DeepEquals(DestinyParentItemOverride? other)
    {
        return other is not null &&
               AdditionalEquipRequirementsDisplayStrings.DeepEqualsListNaive(other.AdditionalEquipRequirementsDisplayStrings) &&
               PipIcon == other.PipIcon;
    }
}