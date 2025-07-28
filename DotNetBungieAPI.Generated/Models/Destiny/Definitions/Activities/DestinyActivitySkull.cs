namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Activities;

public class DestinyActivitySkull
{
    [JsonPropertyName("hash")]
    public uint Hash { get; set; }

    [JsonPropertyName("skullIdentifierHash")]
    public uint SkullIdentifierHash { get; set; }

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; set; }

    [JsonPropertyName("skullOptions")]
    public Destiny.Definitions.Activities.DestinyActivitySkullOption[]? SkullOptions { get; set; }

    [JsonPropertyName("dynamicUse")]
    public Destiny.DestinyActivitySkullDynamicUse DynamicUse { get; set; }

    [JsonPropertyName("modifierPowerContribution")]
    public int ModifierPowerContribution { get; set; }

    [JsonPropertyName("modifierMultiplierContribution")]
    public float? ModifierMultiplierContribution { get; set; }

    [Destiny2Definition<Destiny.Definitions.Activities.DestinyActivitySelectableSkullExclusionGroupDefinition>("Destiny.Definitions.Activities.DestinyActivitySelectableSkullExclusionGroupDefinition")]
    [JsonPropertyName("skullExclusionGroupHash")]
    public uint? SkullExclusionGroupHash { get; set; }

    [JsonPropertyName("hasUi")]
    public bool HasUi { get; set; }

    [JsonPropertyName("displayDescriptionOverrideForNavMode")]
    public string DisplayDescriptionOverrideForNavMode { get; set; }

    [JsonPropertyName("activityModifierDisplayCategory")]
    public Destiny.DestinyActivityModifierDisplayCategory ActivityModifierDisplayCategory { get; set; }

    [JsonPropertyName("activityModifierConnotation")]
    public Destiny.DestinyActivityModifierConnotation ActivityModifierConnotation { get; set; }

    [JsonPropertyName("displayInNavMode")]
    public bool DisplayInNavMode { get; set; }

    [JsonPropertyName("displayInActivitySelection")]
    public bool DisplayInActivitySelection { get; set; }
}
