using System.Text.Json.Serialization;
using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny.Definitions.Common;

namespace NetBungieAPI.Models.Destiny.Definitions.Genders
{
    /// <summary>
    ///     Gender is a social construct, and as such we have definitions for Genders. Right now there happens to only be two,
    ///     but we'll see what the future holds.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyGenderDefinition)]
    public sealed record DestinyGenderDefinition : IDestinyDefinition, IDeepEquatable<DestinyGenderDefinition>
    {
        /// <summary>
        ///     This is a quick reference enumeration for all of the currently defined Genders. We use the enumeration for quicker
        ///     lookups in related data, like DestinyClassDefinition.GenderedClassNames.
        /// </summary>
        [JsonPropertyName("genderType")]
        public DestinyGender GenderType { get; init; }

        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

        public bool DeepEquals(DestinyGenderDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   GenderType == other.GenderType &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }

        [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")] public uint Hash { get; init; }
        [JsonPropertyName("index")] public int Index { get; init; }
        [JsonPropertyName("redacted")] public bool Redacted { get; init; }

        public void MapValues()
        {
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}