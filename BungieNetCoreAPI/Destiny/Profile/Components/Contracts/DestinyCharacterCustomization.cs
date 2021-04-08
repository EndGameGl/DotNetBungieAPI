using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyCharacterCustomization
    {
        public uint Personality { get; init; }
        public uint Face { get; init; }
        public uint SkinColor { get; init; }
        public uint LipColor { get; init; }
        public uint EyeColor { get; init; }
        public ReadOnlyCollection<uint> HairColors { get; init; }
        public ReadOnlyCollection<uint> FeatureColors { get; init; }
        public uint DecalColor { get; init; }
        public bool WearHelmet { get; init; }
        public int HairIndex { get; init; }
        public int FeatureIndex { get; init; }
        public int DecalIndex { get; init; }

        [JsonConstructor]
        internal DestinyCharacterCustomization(uint personality, uint face, uint skinColor, uint lipColor, uint eyeColor, uint[] hairColors,
            uint[] featureColors, uint decalColor, bool wearHelmet, int hairIndex, int featureIndex, int decalIndex)
        {
            Personality = personality;
            Face = face;
            SkinColor = skinColor;
            LipColor = lipColor;
            EyeColor = eyeColor;
            HairColors = hairColors.AsReadOnlyOrEmpty();
            FeatureColors = featureColors.AsReadOnlyOrEmpty();
            DecalColor = decalColor;
            WearHelmet = wearHelmet;
            HairIndex = hairIndex;
            FeatureIndex = featureIndex;
            DecalIndex = decalIndex;
        }
    }
}
