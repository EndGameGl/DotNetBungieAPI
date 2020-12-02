using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Unlocks
{
    [DestinyDefinition("DestinyUnlockDefinition")]
    public class DestinyUnlockDefinition : DestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public int Scope { get; }
        public int UnlockType { get; }

        [JsonConstructor]
        private DestinyUnlockDefinition(DestinyDefinitionDisplayProperties displayProperties, int scope, int unlockType, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            DisplayProperties = displayProperties;
            Scope = scope;
            UnlockType = unlockType;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
