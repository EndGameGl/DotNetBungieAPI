using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.Unlocks;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.UnlockCountMappings
{
    /// <summary>
    /// Empty definition
    /// </summary>
    [DestinyDefinition("DestinyUnlockCountMappingDefinition")]
    public class DestinyUnlockCountMappingDefinition : DestinyDefinition
    {
        public DefinitionHashPointer<DestinyUnlockDefinition> UnlockValue { get; }
        [JsonConstructor]
        private DestinyUnlockCountMappingDefinition(uint unlockValueHash, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            UnlockValue = new DefinitionHashPointer<DestinyUnlockDefinition>(unlockValueHash, "DestinyUnlockDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
        }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
