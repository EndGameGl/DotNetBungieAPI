using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     This Block defines the rendering data associated with the item, if any.
/// </summary>
public sealed class DestinyItemTranslationBlockDefinition
{

    [JsonPropertyName("weaponPatternIdentifier")]
    public string WeaponPatternIdentifier { get; init; }

    [JsonPropertyName("weaponPatternHash")]
    public uint WeaponPatternHash { get; init; }

    [JsonPropertyName("defaultDyes")]
    public List<Destiny.DyeReference> DefaultDyes { get; init; }

    [JsonPropertyName("lockedDyes")]
    public List<Destiny.DyeReference> LockedDyes { get; init; }

    [JsonPropertyName("customDyes")]
    public List<Destiny.DyeReference> CustomDyes { get; init; }

    [JsonPropertyName("arrangements")]
    public List<Destiny.Definitions.DestinyGearArtArrangementReference> Arrangements { get; init; }

    [JsonPropertyName("hasGeometry")]
    public bool HasGeometry { get; init; }
}
