namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     This Block defines the rendering data associated with the item, if any.
/// </summary>
public class DestinyItemTranslationBlockDefinition : IDeepEquatable<DestinyItemTranslationBlockDefinition>
{
    [JsonPropertyName("weaponPatternIdentifier")]
    public string WeaponPatternIdentifier { get; set; }

    [JsonPropertyName("weaponPatternHash")]
    public uint WeaponPatternHash { get; set; }

    [JsonPropertyName("defaultDyes")]
    public List<Destiny.DyeReference> DefaultDyes { get; set; }

    [JsonPropertyName("lockedDyes")]
    public List<Destiny.DyeReference> LockedDyes { get; set; }

    [JsonPropertyName("customDyes")]
    public List<Destiny.DyeReference> CustomDyes { get; set; }

    [JsonPropertyName("arrangements")]
    public List<Destiny.Definitions.DestinyGearArtArrangementReference> Arrangements { get; set; }

    [JsonPropertyName("hasGeometry")]
    public bool HasGeometry { get; set; }

    public bool DeepEquals(DestinyItemTranslationBlockDefinition? other)
    {
        return other is not null &&
               WeaponPatternIdentifier == other.WeaponPatternIdentifier &&
               WeaponPatternHash == other.WeaponPatternHash &&
               DefaultDyes.DeepEqualsList(other.DefaultDyes) &&
               LockedDyes.DeepEqualsList(other.LockedDyes) &&
               CustomDyes.DeepEqualsList(other.CustomDyes) &&
               Arrangements.DeepEqualsList(other.Arrangements) &&
               HasGeometry == other.HasGeometry;
    }
}