﻿using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.SackRewardItemLists
{
    public class DestinySackRewardItemListDefinition : DestinyDefinition
    {
        [JsonConstructor]
        private DestinySackRewardItemListDefinition(bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted) { }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
