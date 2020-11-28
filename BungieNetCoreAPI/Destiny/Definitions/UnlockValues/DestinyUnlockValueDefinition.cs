using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.UnlockValues
{
    public class DestinyUnlockValueDefinition : DestinyDefinition
    {
        public int AggregationType { get; }
        public int Scope { get; }
        public int MappingIndex { get; }

        [JsonConstructor]
        private DestinyUnlockValueDefinition(int aggregationType, int scope, int mappingIndex, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            AggregationType = aggregationType;
            Scope = scope;
            MappingIndex = mappingIndex;
        }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
