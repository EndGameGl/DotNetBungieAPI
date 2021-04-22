using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny.Definitions.Common;
using NetBungieAPI.Models.Destiny.Definitions.Genders;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Classes
{
    [DestinyDefinition(DefinitionsEnum.DestinyClassDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public sealed record DestinyClassDefinition : IDestinyDefinition, IDeepEquatable<DestinyClassDefinition>
    {
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        [JsonPropertyName("classType")]
        public DestinyClass ClassType { get; init; }
        [JsonPropertyName("genderedClassNames")]
        public ReadOnlyDictionary<string, string> GenderedClassNames { get; init; } = Defaults.EmptyReadOnlyDictionary<string, string>();
        [JsonPropertyName("genderedClassNamesByGenderHash")]
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyGenderDefinition>, string> GenderedClassNamesByGender { get; init; } = Defaults.EmptyReadOnlyDictionary<DefinitionHashPointer<DestinyGenderDefinition>, string>();
        [JsonPropertyName("blacklisted")]
        public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")]
        public uint Hash { get; init; }
        [JsonPropertyName("index")]
        public int Index { get; init; }
        [JsonPropertyName("redacted")]
        public bool Redacted { get; init; }

        public override string ToString()
        {
            return $"{Hash}: {DisplayProperties.Name}";
        }

        public bool DeepEquals(DestinyClassDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   ClassType == other.ClassType &&
                   GenderedClassNames.DeepEqualsReadOnlyDictionaryWithSimpleKeyAndSimpleValue(other.GenderedClassNames) &&
                   GenderedClassNamesByGender.DeepEqualsReadOnlyDictionaryWithDefinitionKeyAndSimpleValue(other.GenderedClassNamesByGender) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
        public void MapValues()
        {
            foreach (var name in GenderedClassNamesByGender)
            {
                name.Key.TryMapValue();
            }
        }
    }
}
