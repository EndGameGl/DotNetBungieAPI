using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.MaterialRequirementSets
{
    public class DestinyMaterialRequirementSetDefinition : DestinyDefinition
    {
        public List<MaterialRequirementSetEntry> Materials { get; }

        [JsonConstructor]
        private DestinyMaterialRequirementSetDefinition(List<MaterialRequirementSetEntry> materials, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            Materials = materials;
        }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
