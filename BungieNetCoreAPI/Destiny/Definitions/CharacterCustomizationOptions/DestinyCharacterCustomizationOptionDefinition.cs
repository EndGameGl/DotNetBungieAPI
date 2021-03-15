using NetBungieAPI.Attributes;
using NetBungieAPI.Destiny.Definitions.Genders;
using NetBungieAPI.Destiny.Definitions.Races;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.CharacterCustomizationOptions
{
    [DestinyDefinition(DefinitionsEnum.DestinyCharacterCustomizationOptionDefinition, DefinitionSources.BungieNet | DefinitionSources.JSON, DefinitionKeyType.UInt)]
    public class DestinyCharacterCustomizationOptionDefinition : IDestinyDefinition, IDeepEquatable<DestinyCharacterCustomizationOptionDefinition>
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public DefinitionHashPointer<DestinyGenderDefinition> Gender { get; }
        public DefinitionHashPointer<DestinyRaceDefinition> Race { get; }
        public CharacterCustomizationOptionColorOptions DecalColorOptions { get; }
        public CharacterCustomizationOptionColorOptions DecalOptions { get; }
        public CharacterCustomizationOptionColorOptions EyeColorOptions { get; }
        public ReadOnlyCollection<uint> FaceOptionCinematicHostPatternIds { get; }
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
        internal DestinyCharacterCustomizationOptionDefinition(DestinyDefinitionDisplayProperties displayProperties, uint genderHash, uint raceHash,
            CharacterCustomizationOptionColorOptions decalColorOptions,
            CharacterCustomizationOptionColorOptions decalOptions, CharacterCustomizationOptionColorOptions eyeColorOptions,
            uint[] faceOptionCinematicHostPatternIds, CharacterCustomizationOptionColorOptions faceOptions,
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
            FaceOptionCinematicHostPatternIds = faceOptionCinematicHostPatternIds.AsReadOnlyOrEmpty();
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

        public bool DeepEquals(DestinyCharacterCustomizationOptionDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   Gender.DeepEquals(other.Gender) &&
                   Race.DeepEquals(other.Race) &&
                   DecalColorOptions.DeepEquals(other.DecalColorOptions) &&
                   DecalOptions.DeepEquals(other.DecalOptions) &&
                   EyeColorOptions.DeepEquals(other.EyeColorOptions) &&
                   FaceOptionCinematicHostPatternIds.DeepEqualsReadOnlySimpleCollection(other.FaceOptionCinematicHostPatternIds) &&
                   FaceOptions.DeepEquals(other.FaceOptions) &&
                   FeatureColorOptions.DeepEquals(other.FeatureColorOptions) &&
                   FeatureOptions.DeepEquals(other.FeatureOptions) &&
                   HairColorOptions.DeepEquals(other.HairColorOptions) &&
                   HairOptions.DeepEquals(other.HairOptions) &&
                   HelmetPreferences.DeepEquals(other.HelmetPreferences) &&
                   LipColorOptions.DeepEquals(other.LipColorOptions) &&
                   PersonalityOptions.DeepEquals(other.PersonalityOptions) &&
                   SkinColorOptions.DeepEquals(other.SkinColorOptions) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }

        public void MapValues()
        {
            return;
        }
    }
}
