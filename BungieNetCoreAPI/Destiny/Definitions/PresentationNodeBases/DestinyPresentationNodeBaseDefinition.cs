using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.PresentationNodeBases
{
    public class DestinyPresentationNodeBaseDefinition : DestinyDefinition
    {

        [JsonConstructor]
        private DestinyPresentationNodeBaseDefinition(bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
        }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
