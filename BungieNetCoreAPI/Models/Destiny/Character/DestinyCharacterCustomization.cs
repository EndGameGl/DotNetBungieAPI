using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Character
{
    public sealed record DestinyCharacterCustomization
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
        public ReadOnlyCollection<uint> HairColors { get; init; } = Defaults.EmptyReadOnlyCollection<uint>();
        [JsonPropertyName("featureColors")]
        public ReadOnlyCollection<uint> FeatureColors { get; init; } = Defaults.EmptyReadOnlyCollection<uint>();
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
}
