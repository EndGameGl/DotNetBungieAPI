namespace DotNetBungieAPI.Models.Destiny.Definitions.Activities;

public sealed class DestinyActivitySkull : IDisplayProperties
{
    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("skullIdentifierHash")]
    public uint SkullIdentifierHash { get; init; }

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; init; }

    [JsonPropertyName("skullOptions")]
    public Destiny.Definitions.Activities.DestinyActivitySkullOption[]? SkullOptions { get; init; }

    [JsonPropertyName("dynamicUse")]
    public Destiny.DestinyActivitySkullDynamicUse DynamicUse { get; init; }

    [JsonPropertyName("modifierPowerContribution")]
    public int ModifierPowerContribution { get; init; }

    [JsonPropertyName("modifierMultiplierContribution")]
    public float? ModifierMultiplierContribution { get; init; }

    [JsonPropertyName("skullExclusionGroupHash")]
    public DefinitionHashPointer<Destiny.Definitions.Activities.DestinyActivitySelectableSkullExclusionGroupDefinition>? SkullExclusionGroupHash { get; init; }

    [JsonPropertyName("hasUi")]
    public bool HasUi { get; init; }

    [JsonPropertyName("displayDescriptionOverrideForNavMode")]
    public string DisplayDescriptionOverrideForNavMode { get; init; }

    [JsonPropertyName("activityModifierDisplayCategory")]
    public Destiny.DestinyActivityModifierDisplayCategory ActivityModifierDisplayCategory { get; init; }

    [JsonPropertyName("activityModifierConnotation")]
    public Destiny.DestinyActivityModifierConnotation ActivityModifierConnotation { get; init; }

    [JsonPropertyName("displayInNavMode")]
    public bool DisplayInNavMode { get; init; }

    [JsonPropertyName("displayInActivitySelection")]
    public bool DisplayInActivitySelection { get; init; }
}
