﻿using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.RewardSources
{
    /// <summary>
    /// Empty atm
    /// </summary>
    [DestinyDefinition(name: "DestinyRewardSourceDefinition", presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyRewardSourceDefinition : DestinyDefinition
    {
        [JsonConstructor]
        private DestinyRewardSourceDefinition(bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted) { }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
