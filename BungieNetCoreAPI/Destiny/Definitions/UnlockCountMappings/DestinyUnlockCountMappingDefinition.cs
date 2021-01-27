using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.Unlocks;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.UnlockCountMappings
{
    /// <summary>
    /// Empty definition
    /// </summary>
    [DestinyDefinition(type: DefinitionsEnum.DestinyUnlockCountMappingDefinition, presentInSQLiteDB: false, shouldBeLoaded: true)]
    public class DestinyUnlockCountMappingDefinition : IDestinyDefinition
    {
        public DefinitionHashPointer<DestinyUnlockDefinition> UnlockValue { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }
        [JsonConstructor]
        private DestinyUnlockCountMappingDefinition(uint unlockValueHash, bool blacklisted, uint hash, int index, bool redacted)
        {
            UnlockValue = new DefinitionHashPointer<DestinyUnlockDefinition>(unlockValueHash, DefinitionsEnum.DestinyUnlockDefinition);
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
