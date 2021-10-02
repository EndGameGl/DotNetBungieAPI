using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Character
{
    /// <summary>
    ///     Raw data about the customization options chosen for a character's face and appearance.
    ///     <para />
    ///     You can look up the relevant class/race/gender combo in DestinyCharacterCustomizationOptionDefinition for the
    ///     character, and then look up these values within the CustomizationOptions found to pull some data about their
    ///     choices. Warning: not all of that data is meaningful. Some data has useful icons. Others have nothing, and are only
    ///     meant for 3D rendering purposes (which we sadly do not expose yet)
    /// </summary>
    public sealed record DestinyCharacterCustomization
    {
        [JsonPropertyName("personality")] public uint Personality { get; init; }
        [JsonPropertyName("face")] public uint Face { get; init; }
        [JsonPropertyName("skinColor")] public uint SkinColor { get; init; }
        [JsonPropertyName("lipColor")] public uint LipColor { get; init; }
        [JsonPropertyName("eyeColor")] public uint EyeColor { get; init; }

        [JsonPropertyName("hairColors")]
        public ReadOnlyCollection<uint> HairColors { get; init; } = Defaults.EmptyReadOnlyCollection<uint>();

        [JsonPropertyName("featureColors")]
        public ReadOnlyCollection<uint> FeatureColors { get; init; } = Defaults.EmptyReadOnlyCollection<uint>();

        [JsonPropertyName("decalColor")] public uint DecalColor { get; init; }
        [JsonPropertyName("wearHelmet")] public bool WearHelmet { get; init; }
        [JsonPropertyName("hairIndex")] public int HairIndex { get; init; }
        [JsonPropertyName("featureIndex")] public int FeatureIndex { get; init; }
        [JsonPropertyName("decalIndex")] public int DecalIndex { get; init; }
    }
}