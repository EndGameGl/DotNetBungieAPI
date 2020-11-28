using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.TalentGrids
{
    public class DestinyTalentGridDefinition : DestinyDefinition
    {
        [JsonConstructor]
        private DestinyTalentGridDefinition(bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
        }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
