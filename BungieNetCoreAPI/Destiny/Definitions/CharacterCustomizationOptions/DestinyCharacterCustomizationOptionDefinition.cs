using BungieNetCoreAPI.Destiny.Definitions.Genders;
using BungieNetCoreAPI.Destiny.Definitions.Races;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.CharacterCustomizationOptions
{
    public class DestinyCharacterCustomizationOptionDefinition : DestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public DefinitionHashPointer<DestinyGenderDefinition> Gender { get; }
        public DefinitionHashPointer<DestinyRaceDefinition> Race { get; }
        public CharacterCustomizationOptionColorOptions DecalColorOptions { get; }
        public CharacterCustomizationOptionColorOptions DecalOptions { get; }
        public CharacterCustomizationOptionColorOptions EyeColorOptions { get; }
        public List<uint> FaceOptionCinematicHostPatternIds { get; }
        public CharacterCustomizationOptionColorOptions FaceOptions { get; }
        public CharacterCustomizationOptionColorOptionsWithMultipleValues FeatureColorOptions { get; }
        public CharacterCustomizationOptionColorOptions FeatureOptions { get; }
        public CharacterCustomizationOptionColorOptionsWithMultipleValues HairColorOptions { get; }
        public CharacterCustomizationOptionColorOptions HairOptions { get; }
        public CharacterCustomizationOptionColorOptions HelmetPreferences { get; }
        public CharacterCustomizationOptionColorOptions LipColorOptions { get; }
        public CharacterCustomizationOptionColorOptions PersonalityOptions { get; }
        public CharacterCustomizationOptionColorOptions SkinColorOptions { get; }

        [JsonConstructor]
        private DestinyCharacterCustomizationOptionDefinition(DestinyDefinitionDisplayProperties displayProperties, uint genderHash, uint raceHash,
            CharacterCustomizationOptionColorOptions decalColorOptions,
            CharacterCustomizationOptionColorOptions decalOptions, CharacterCustomizationOptionColorOptions eyeColorOptions,
            List<uint> faceOptionCinematicHostPatternIds, CharacterCustomizationOptionColorOptions faceOptions,
            CharacterCustomizationOptionColorOptionsWithMultipleValues featureColorOptions, CharacterCustomizationOptionColorOptions featureOptions,
            CharacterCustomizationOptionColorOptionsWithMultipleValues hairColorOptions, CharacterCustomizationOptionColorOptions hairOptions,
            CharacterCustomizationOptionColorOptions helmetPreferences, CharacterCustomizationOptionColorOptions lipColorOptions,
            CharacterCustomizationOptionColorOptions personalityOptions, CharacterCustomizationOptionColorOptions skinColorOptions,
            bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            DisplayProperties = displayProperties;
            Gender = new DefinitionHashPointer<DestinyGenderDefinition>(genderHash, "DestinyGenderDefinition");
            Race = new DefinitionHashPointer<DestinyRaceDefinition>(raceHash, "DestinyRaceDefinition");
            DecalColorOptions = decalColorOptions;
            DecalOptions = decalOptions;
            EyeColorOptions = eyeColorOptions;
            if (faceOptionCinematicHostPatternIds == null)
                FaceOptionCinematicHostPatternIds = new List<uint>();
            else
                FaceOptionCinematicHostPatternIds = faceOptionCinematicHostPatternIds;
            FaceOptions = faceOptions;
            FeatureColorOptions = featureColorOptions;
            FeatureOptions = featureOptions;
            HairColorOptions = hairColorOptions;
            HairOptions = hairOptions;
            HelmetPreferences = helmetPreferences;
            LipColorOptions = lipColorOptions;
            PersonalityOptions = personalityOptions;
            SkinColorOptions = skinColorOptions;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
