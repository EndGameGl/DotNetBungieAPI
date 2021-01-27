﻿using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.RewardAdjusterPointers
{
    /// <summary>
    /// Empty atm
    /// </summary>
    [DestinyDefinition(type: DefinitionsEnum.DestinyRewardAdjusterPointerDefinition, presentInSQLiteDB: false, shouldBeLoaded: true)]
    public class DestinyRewardAdjusterPointerDefinition : IDestinyDefinition
    {
        public int AdjusterType { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }
        [JsonConstructor]
        private DestinyRewardAdjusterPointerDefinition(int adjusterType, bool blacklisted, uint hash, int index, bool redacted)
        {
            AdjusterType = adjusterType;
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
