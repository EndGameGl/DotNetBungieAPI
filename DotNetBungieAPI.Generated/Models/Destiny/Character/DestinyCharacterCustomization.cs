namespace DotNetBungieAPI.Generated.Models.Destiny.Character;

/// <summary>
///     Raw data about the customization options chosen for a character's face and appearance.
/// <para />
///     You can look up the relevant class/race/gender combo in DestinyCharacterCustomizationOptionDefinition for the character, and then look up these values within the CustomizationOptions found to pull some data about their choices. Warning: not all of that data is meaningful. Some data has useful icons. Others have nothing, and are only meant for 3D rendering purposes (which we sadly do not expose yet)
/// </summary>
public class DestinyCharacterCustomization : IDeepEquatable<DestinyCharacterCustomization>
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

    public bool DeepEquals(DestinyCharacterCustomization? other)
    {
        return other is not null &&
               Personality == other.Personality &&
               Face == other.Face &&
               SkinColor == other.SkinColor &&
               LipColor == other.LipColor &&
               EyeColor == other.EyeColor &&
               HairColors.DeepEqualsListNaive(other.HairColors) &&
               FeatureColors.DeepEqualsListNaive(other.FeatureColors) &&
               DecalColor == other.DecalColor &&
               WearHelmet == other.WearHelmet &&
               HairIndex == other.HairIndex &&
               FeatureIndex == other.FeatureIndex &&
               DecalIndex == other.DecalIndex;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyCharacterCustomization? other)
    {
        if (other is null) return;
        if (Personality != other.Personality)
        {
            Personality = other.Personality;
            OnPropertyChanged(nameof(Personality));
        }
        if (Face != other.Face)
        {
            Face = other.Face;
            OnPropertyChanged(nameof(Face));
        }
        if (SkinColor != other.SkinColor)
        {
            SkinColor = other.SkinColor;
            OnPropertyChanged(nameof(SkinColor));
        }
        if (LipColor != other.LipColor)
        {
            LipColor = other.LipColor;
            OnPropertyChanged(nameof(LipColor));
        }
        if (EyeColor != other.EyeColor)
        {
            EyeColor = other.EyeColor;
            OnPropertyChanged(nameof(EyeColor));
        }
        if (!HairColors.DeepEqualsListNaive(other.HairColors))
        {
            HairColors = other.HairColors;
            OnPropertyChanged(nameof(HairColors));
        }
        if (!FeatureColors.DeepEqualsListNaive(other.FeatureColors))
        {
            FeatureColors = other.FeatureColors;
            OnPropertyChanged(nameof(FeatureColors));
        }
        if (DecalColor != other.DecalColor)
        {
            DecalColor = other.DecalColor;
            OnPropertyChanged(nameof(DecalColor));
        }
        if (WearHelmet != other.WearHelmet)
        {
            WearHelmet = other.WearHelmet;
            OnPropertyChanged(nameof(WearHelmet));
        }
        if (HairIndex != other.HairIndex)
        {
            HairIndex = other.HairIndex;
            OnPropertyChanged(nameof(HairIndex));
        }
        if (FeatureIndex != other.FeatureIndex)
        {
            FeatureIndex = other.FeatureIndex;
            OnPropertyChanged(nameof(FeatureIndex));
        }
        if (DecalIndex != other.DecalIndex)
        {
            DecalIndex = other.DecalIndex;
            OnPropertyChanged(nameof(DecalIndex));
        }
    }
}