﻿using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.RewardSources
{
    /// <summary>
    /// Empty atm
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyRewardSourceDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyRewardSourceDefinition : IDestinyDefinition
    {
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }
        [JsonConstructor]
        private DestinyRewardSourceDefinition(bool blacklisted, uint hash, int index, bool redacted) { }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
