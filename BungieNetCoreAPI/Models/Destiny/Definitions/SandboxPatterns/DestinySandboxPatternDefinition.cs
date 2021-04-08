using NetBungieAPI.Attributes;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Models.Destiny.Definitions.SandboxPatterns
{
    [DestinyDefinition(DefinitionsEnum.DestinySandboxPatternDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinySandboxPatternDefinition : IDestinyDefinition, IDeepEquatable<DestinySandboxPatternDefinition>
    {
        public uint PatternGlobalTagIdHash { get; init; }
        public uint PatternHash { get; init; }
        public uint WeaponContentGroupHash { get; init; }
        public uint WeaponTranslationGroupHash { get; init; }
        public int WeaponType { get; init; }
        public uint WeaponTypeHash { get; init; }
        public ReadOnlyCollection<SandboxPatternFilter> Filters { get; init; }
        public bool Blacklisted { get; init; }
        public uint Hash { get; init; }
        public int Index { get; init; }
        public bool Redacted { get; init; }

        [JsonConstructor]
        internal DestinySandboxPatternDefinition(uint patternGlobalTagIdHash, uint patternHash, uint weaponContentGroupHash, uint weaponTranslationGroupHash,
            int weaponType, uint weaponTypeHash, SandboxPatternFilter[] filters, bool blacklisted, uint hash, int index, bool redacted)
        {
            PatternGlobalTagIdHash = patternGlobalTagIdHash;
            PatternHash = patternHash;
            WeaponContentGroupHash = weaponContentGroupHash;
            WeaponTranslationGroupHash = weaponTranslationGroupHash;
            WeaponType = weaponType;
            WeaponTypeHash = weaponTypeHash;
            Filters = filters.AsReadOnlyOrEmpty();
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash}";
        }

        public void MapValues()
        {
            foreach (var filter in Filters)
            {
                filter.Stat.TryMapValue();
            }
        }

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
    }
}
