namespace DotNetBungieAPI.Generated.Models.Destiny.Character;

/// <summary>
///     Raw data about the customization options chosen for a character's face and appearance.
/// <para />
///     You can look up the relevant class/race/gender combo in DestinyCharacterCustomizationOptionDefinition for the character, and then look up these values within the CustomizationOptions found to pull some data about their choices. Warning: not all of that data is meaningful. Some data has useful icons. Others have nothing, and are only meant for 3D rendering purposes (which we sadly do not expose yet)
/// </summary>
public class DestinyCharacterCustomization
{
    [JsonPropertyName("personality")]
    public uint Personality { get; set; }

    [JsonPropertyName("face")]
    public uint Face { get; set; }

    [JsonPropertyName("skinColor")]
    public uint SkinColor { get; set; }

    [JsonPropertyName("lipColor")]
    public uint LipColor { get; set; }

    [JsonPropertyName("eyeColor")]
    public uint EyeColor { get; set; }

    [JsonPropertyName("hairColors")]
    public List<uint> HairColors { get; set; }

    [JsonPropertyName("featureColors")]
    public List<uint> FeatureColors { get; set; }

    [JsonPropertyName("decalColor")]
    public uint DecalColor { get; set; }

    [JsonPropertyName("wearHelmet")]
    public bool WearHelmet { get; set; }

    [JsonPropertyName("hairIndex")]
    public int HairIndex { get; set; }

    [JsonPropertyName("featureIndex")]
    public int FeatureIndex { get; set; }

    [JsonPropertyName("decalIndex")]
    public int DecalIndex { get; set; }
}
