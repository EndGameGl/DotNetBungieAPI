using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.UnlockEvents
{
    [DestinyDefinition("DestinyUnlockEventDefinition")]
    public class DestinyUnlockEventDefinition : DestinyDefinition
    {
        [JsonConstructor]
        private DestinyUnlockEventDefinition(bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
        }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
