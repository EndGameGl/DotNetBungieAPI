using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyCharacterCustomization
    {
        public uint Personality { get; }
        public uint Face { get; }
        public uint SkinColor { get; }
        public uint LipColor { get; }
        public uint EyeColor { get; }
        public ReadOnlyCollection<uint> HairColors { get; }
        public ReadOnlyCollection<uint> FeatureColors { get; }
        public uint DecalColor { get; }
        public bool WearHelmet { get; }
        public int HairIndex { get; }
        public int FeatureIndex { get; }
        public int DecalIndex { get; }

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
