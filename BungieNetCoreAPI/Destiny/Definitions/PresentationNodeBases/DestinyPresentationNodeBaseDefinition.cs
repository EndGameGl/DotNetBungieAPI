using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.PresentationNodeBases
{
    [DestinyDefinition(type: DefinitionsEnum.DestinyPresentationNodeBaseDefinition, presentInSQLiteDB: false, shouldBeLoaded: true)]
    public class DestinyPresentationNodeBaseDefinition : IDestinyDefinition
    {
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyPresentationNodeBaseDefinition(bool blacklisted, uint hash, int index, bool redacted)
        {
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
