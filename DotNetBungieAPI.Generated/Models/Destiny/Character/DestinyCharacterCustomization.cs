using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Character;

public sealed class DestinyCharacterCustomization
{

    [JsonPropertyName("personality")]
    public uint Personality { get; init; }

    [JsonPropertyName("face")]
    public uint Face { get; init; }

    [JsonPropertyName("skinColor")]
    public uint SkinColor { get; init; }

    [JsonPropertyName("lipColor")]
    public uint LipColor { get; init; }

    [JsonPropertyName("eyeColor")]
    public uint EyeColor { get; init; }

    [JsonPropertyName("hairColors")]
    public List<uint> HairColors { get; init; }

    [JsonPropertyName("featureColors")]
    public List<uint> FeatureColors { get; init; }

    [JsonPropertyName("decalColor")]
    public uint DecalColor { get; init; }

    [JsonPropertyName("wearHelmet")]
    public bool WearHelmet { get; init; }

    [JsonPropertyName("hairIndex")]
    public int HairIndex { get; init; }

    [JsonPropertyName("featureIndex")]
    public int FeatureIndex { get; init; }

    [JsonPropertyName("decalIndex")]
    public int DecalIndex { get; init; }
}
