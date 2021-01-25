﻿using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.RewardItemLists
{
    /// <summary>
    /// Empty atm
    /// </summary>
    [DestinyDefinition(name: "DestinyRewardItemListDefinition", presentInSQLiteDB: false, shouldBeLoaded: true)]
    public class DestinyRewardItemListDefinition : IDestinyDefinition
    {
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }
        [JsonConstructor]
        private DestinyRewardItemListDefinition(bool blacklisted, uint hash, int index, bool redacted) { }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
