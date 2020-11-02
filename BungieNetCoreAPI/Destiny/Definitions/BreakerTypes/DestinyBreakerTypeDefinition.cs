using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.BreakerTypes
{
    public class DestinyBreakerTypeDefinition : DestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public uint UnlockHash { get; }
        public DestinyBreakerTypes EnumValue { get; }

        [JsonConstructor]
        private DestinyBreakerTypeDefinition(DestinyDefinitionDisplayProperties displayProperties, uint unlockHash, DestinyBreakerTypes enumValue,
            bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            DisplayProperties = displayProperties;
            UnlockHash = unlockHash;
            EnumValue = enumValue;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
