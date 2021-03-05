﻿using BungieNetCoreAPI.Destiny.Definitions.Unlocks;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyUnlockStatus
    {
        public DefinitionHashPointer<DestinyUnlockDefinition> Unlock { get; }
        public bool IsSet { get; }

        [JsonConstructor]
        internal DestinyUnlockStatus(uint unlockHash, bool isSet)
        {
            Unlock = new DefinitionHashPointer<DestinyUnlockDefinition>(unlockHash, DefinitionsEnum.DestinyUnlockDefinition);
            IsSet = isSet;
        }
    }
}