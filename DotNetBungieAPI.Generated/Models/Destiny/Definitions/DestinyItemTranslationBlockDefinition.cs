namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     This Block defines the rendering data associated with the item, if any.
/// </summary>
public class DestinyItemTranslationBlockDefinition
{
    [JsonPropertyName("weaponPatternIdentifier")]
    public string WeaponPatternIdentifier { get; set; }

    [Destiny2Definition<Destiny.Definitions.DestinySandboxPatternDefinition>("Destiny.Definitions.DestinySandboxPatternDefinition")]
    [JsonPropertyName("weaponPatternHash")]
    public uint WeaponPatternHash { get; set; }

    [JsonPropertyName("defaultDyes")]
    public Destiny.DyeReference[]? DefaultDyes { get; set; }

    [JsonPropertyName("lockedDyes")]
    public Destiny.DyeReference[]? LockedDyes { get; set; }

    [JsonPropertyName("customDyes")]
    public Destiny.DyeReference[]? CustomDyes { get; set; }

    [JsonPropertyName("arrangements")]
    public Destiny.Definitions.DestinyGearArtArrangementReference[]? Arrangements { get; set; }

    [JsonPropertyName("hasGeometry")]
    public bool HasGeometry { get; set; }
}
