using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.Genders;
using BungieNetCoreAPI.Destiny.Definitions.Races;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.CharacterCustomizationOptions
{
    [DestinyDefinition(name: "DestinyCharacterCustomizationOptionDefinition", presentInSQLiteDB: false, shouldBeLoaded: true)]
    public class DestinyCharacterCustomizationOptionDefinition : IDestinyDefinition
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
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

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
        {
            DisplayProperties = displayProperties;
            Gender = new DefinitionHashPointer<DestinyGenderDefinition>(genderHash, DefinitionsEnum.DestinyGenderDefinition);
            Race = new DefinitionHashPointer<DestinyRaceDefinition>(raceHash, DefinitionsEnum.DestinyRaceDefinition);
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
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
