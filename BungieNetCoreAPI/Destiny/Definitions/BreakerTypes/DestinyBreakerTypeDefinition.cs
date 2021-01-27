using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.BreakerTypes
{
    [DestinyDefinition(type: DefinitionsEnum.DestinyBreakerTypeDefinition, presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyBreakerTypeDefinition : IDestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public uint UnlockHash { get; }
        public DestinyBreakerTypes EnumValue { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyBreakerTypeDefinition(DestinyDefinitionDisplayProperties displayProperties, uint unlockHash, DestinyBreakerTypes enumValue,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            UnlockHash = unlockHash;
            EnumValue = enumValue;
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
