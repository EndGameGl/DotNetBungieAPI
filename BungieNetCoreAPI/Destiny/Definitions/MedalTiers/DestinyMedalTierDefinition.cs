using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.MedalTiers
{
    [DestinyDefinition(type: DefinitionsEnum.DestinyMedalTierDefinition, presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyMedalTierDefinition : IDestinyDefinition
    {
        public int Order { get; }
        public string TierName { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }
        [JsonConstructor]
        private DestinyMedalTierDefinition(int order, string tierName, bool blacklisted, uint hash, int index, bool redacted)
        {
            Order = order;
            TierName = tierName;
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
