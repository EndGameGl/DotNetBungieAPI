﻿using NetBungieAPI.Destiny.Definitions.Stats;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyStat
    {
        public DefinitionHashPointer<DestinyStatDefinition> Stat { get; }
        public int Value { get; }

        [JsonConstructor]
        internal DestinyStat(uint statHash, int value)
        {
            Stat = new DefinitionHashPointer<DestinyStatDefinition>(statHash, DefinitionsEnum.DestinyStatDefinition);
            Value = value;
        }
    }
}
