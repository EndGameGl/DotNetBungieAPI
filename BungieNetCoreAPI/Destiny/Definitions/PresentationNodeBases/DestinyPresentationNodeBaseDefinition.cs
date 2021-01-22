using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.PresentationNodeBases
{
    [DestinyDefinition(name: "DestinyPresentationNodeBaseDefinition", presentInSQLiteDB: false, shouldBeLoaded: true)]
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
