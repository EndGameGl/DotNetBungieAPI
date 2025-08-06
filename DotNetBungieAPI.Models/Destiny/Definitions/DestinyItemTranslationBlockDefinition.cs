namespace DotNetBungieAPI.Models.Destiny.Definitions;

/// <summary>
///     This Block defines the rendering data associated with the item, if any.
/// </summary>
public sealed class DestinyItemTranslationBlockDefinition
{
    [JsonPropertyName("weaponPatternIdentifier")]
    public string WeaponPatternIdentifier { get; init; }

    [JsonPropertyName("weaponPatternHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinySandboxPatternDefinition> WeaponPatternHash { get; init; }

    [JsonPropertyName("defaultDyes")]
    public Destiny.DyeReference[]? DefaultDyes { get; init; }

    [JsonPropertyName("lockedDyes")]
    public Destiny.DyeReference[]? LockedDyes { get; init; }

    [JsonPropertyName("customDyes")]
    public Destiny.DyeReference[]? CustomDyes { get; init; }

    [JsonPropertyName("arrangements")]
    public Destiny.Definitions.DestinyGearArtArrangementReference[]? Arrangements { get; init; }

    [JsonPropertyName("hasGeometry")]
    public bool HasGeometry { get; init; }
}
