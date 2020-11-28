using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.MedalTiers
{
    public class DestinyMedalTierDefinition : DestinyDefinition
    {
        public int Order { get; }
        public string TierName { get; }
        [JsonConstructor]
        private DestinyMedalTierDefinition(int order, string tierName, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            Order = order;
            TierName = tierName;
        }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
