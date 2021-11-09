using DotNetBungieAPI.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;
using DotNetBungieAPI.Models.Destiny.Definitions.Genders;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Classes
{
    /// <summary>
    ///     Defines a Character Class in Destiny 2. These are types of characters you can play, like Titan, Warlock, and
    ///     Hunter.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyClassDefinition)]
    public sealed record DestinyClassDefinition : IDestinyDefinition, IDeepEquatable<DestinyClassDefinition>
    {
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

        /// <summary>
        ///     In Destiny 1, we added a convenience Enumeration for referring to classes. We've kept it, though mostly for
        ///     posterity. This is the enum value for this definition's class.
        /// </summary>
        [JsonPropertyName("classType")]
        public DestinyClass ClassType { get; init; }

        /// <summary>
        ///     A localized string referring to the singular form of the Class's name when referred to in gendered form. Keyed by
        ///     the DestinyGender.
        /// </summary>
        [JsonPropertyName("genderedClassNames")]
        public ReadOnlyDictionary<string, string> GenderedClassNames { get; init; } =
            ReadOnlyDictionaries<string, string>.Empty;

        [JsonPropertyName("genderedClassNamesByGenderHash")]
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyGenderDefinition>, string>
            GenderedClassNamesByGender
        { get; init; } =
            ReadOnlyDictionaries<DefinitionHashPointer<DestinyGenderDefinition>, string>.Empty;

        public bool DeepEquals(DestinyClassDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   ClassType == other.ClassType &&
                   GenderedClassNames
                       .DeepEqualsReadOnlyDictionaryWithSimpleKeyAndSimpleValue(other.GenderedClassNames) &&
                   GenderedClassNamesByGender.DeepEqualsReadOnlyDictionaryWithDefinitionKeyAndSimpleValue(
                       other.GenderedClassNamesByGender) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }

        public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyClassDefinition;
        [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")] public uint Hash { get; init; }
        [JsonPropertyName("index")] public int Index { get; init; }
        [JsonPropertyName("redacted")] public bool Redacted { get; init; }

        public void MapValues()
        {
            foreach (var name in GenderedClassNamesByGender) name.Key.TryMapValue();
        }

        public void SetPointerLocales(BungieLocales locale)
        {
            foreach (var name in GenderedClassNamesByGender) name.Key.SetLocale(locale);
        }
    }
}