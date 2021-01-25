using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.MaterialRequirementSets
{
    [DestinyDefinition(name: "DestinyMaterialRequirementSetDefinition", presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyMaterialRequirementSetDefinition : IDestinyDefinition
    {
        public List<MaterialRequirementSetEntry> Materials { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyMaterialRequirementSetDefinition(List<MaterialRequirementSetEntry> materials, bool blacklisted, uint hash, int index, bool redacted)
        {
            Materials = materials;
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
