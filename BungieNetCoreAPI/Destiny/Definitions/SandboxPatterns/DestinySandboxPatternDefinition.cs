using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.SandboxPatterns
{
    [DestinyDefinition("DestinySandboxPatternDefinition")]
    public class DestinySandboxPatternDefinition : DestinyDefinition
    {
        public uint PatternGlobalTagIdHash { get; }
        public uint PatternHash { get; }
        public uint WeaponContentGroupHash { get; }
        public uint WeaponTranslationGroupHash { get; }
        public int WeaponType { get; }
        public uint WeaponTypeHash { get; }
        public List<SandboxPatternFilterEntry> Filters { get; }

        [JsonConstructor]
        private DestinySandboxPatternDefinition(uint patternGlobalTagIdHash, uint patternHash, uint weaponContentGroupHash, uint weaponTranslationGroupHash,
            int weaponType, uint weaponTypeHash, List<SandboxPatternFilterEntry> filters,
            bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            PatternGlobalTagIdHash = patternGlobalTagIdHash;
            PatternHash = patternHash;
            WeaponContentGroupHash = weaponContentGroupHash;
            WeaponTranslationGroupHash = weaponTranslationGroupHash;
            WeaponType = weaponType;
            WeaponTypeHash = weaponTypeHash;
            Filters = filters;
        }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
