using BungieNetCoreAPI.Destiny.Definitions.Unlocks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.UnlockCountMappings
{
    public class DestinyUnlockCountMappingDefinition : DestinyDefinition
    {
        public DefinitionHashPointer<DestinyUnlockDefinition> UnlockValue { get; }
        [JsonConstructor]
        private DestinyUnlockCountMappingDefinition(uint unlockValueHash, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            UnlockValue = new DefinitionHashPointer<DestinyUnlockDefinition>(unlockValueHash, "DestinyUnlockDefinition");
        }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
