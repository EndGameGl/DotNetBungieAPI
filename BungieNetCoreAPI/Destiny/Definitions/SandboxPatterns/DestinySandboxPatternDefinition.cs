using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.SandboxPatterns
{
    [DestinyDefinition(type: DefinitionsEnum.DestinySandboxPatternDefinition, presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinySandboxPatternDefinition : IDestinyDefinition
    {
        public uint PatternGlobalTagIdHash { get; }
        public uint PatternHash { get; }
        public uint WeaponContentGroupHash { get; }
        public uint WeaponTranslationGroupHash { get; }
        public int WeaponType { get; }
        public uint WeaponTypeHash { get; }
        public List<SandboxPatternFilterEntry> Filters { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinySandboxPatternDefinition(uint patternGlobalTagIdHash, uint patternHash, uint weaponContentGroupHash, uint weaponTranslationGroupHash,
            int weaponType, uint weaponTypeHash, List<SandboxPatternFilterEntry> filters,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            PatternGlobalTagIdHash = patternGlobalTagIdHash;
            PatternHash = patternHash;
            WeaponContentGroupHash = weaponContentGroupHash;
            WeaponTranslationGroupHash = weaponTranslationGroupHash;
            WeaponType = weaponType;
            WeaponTypeHash = weaponTypeHash;
            Filters = filters;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
