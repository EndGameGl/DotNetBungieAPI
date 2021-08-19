using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Attributes;

namespace NetBungieAPI.Models.Destiny.Definitions.SandboxPatterns
{
    [DestinyDefinition(DefinitionsEnum.DestinySandboxPatternDefinition)]
    public sealed record DestinySandboxPatternDefinition : IDestinyDefinition,
        IDeepEquatable<DestinySandboxPatternDefinition>
    {
        [JsonPropertyName("patternGlobalTagIdHash")]
        public uint PatternGlobalTagIdHash { get; init; }

        [JsonPropertyName("patternHash")] public uint PatternHash { get; init; }

        [JsonPropertyName("weaponContentGroupHash")]
        public uint WeaponContentGroupHash { get; init; }

        [JsonPropertyName("weaponTranslationGroupHash")]
        public uint WeaponTranslationGroupHash { get; init; }

        [JsonPropertyName("weaponType")] public int WeaponType { get; init; }

        [JsonPropertyName("weaponTypeHash")] public uint WeaponTypeHash { get; init; }

        [JsonPropertyName("filters")]
        public ReadOnlyCollection<DestinySandboxPatternFilterDefinition> Filters { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinySandboxPatternFilterDefinition>();

        public bool DeepEquals(DestinySandboxPatternDefinition other)
        {
            return other != null &&
                   PatternGlobalTagIdHash == other.PatternGlobalTagIdHash &&
                   PatternHash == other.PatternHash &&
                   WeaponContentGroupHash == other.WeaponContentGroupHash &&
                   WeaponTranslationGroupHash == other.WeaponTranslationGroupHash &&
                   WeaponType == other.WeaponType &&
                   WeaponTypeHash == other.WeaponTypeHash &&
                   Filters.DeepEqualsReadOnlyCollections(other.Filters) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }

        public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinySandboxPatternDefinition;
        [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }

        [JsonPropertyName("hash")] public uint Hash { get; init; }

        [JsonPropertyName("index")] public int Index { get; init; }

        [JsonPropertyName("redacted")] public bool Redacted { get; init; }

        public void MapValues()
        {
            foreach (var filter in Filters) filter.Stat.TryMapValue();
        }

        public void SetPointerLocales(BungieLocales locale)
        {
            foreach (var filter in Filters) filter.Stat.SetLocale(locale);
        }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}