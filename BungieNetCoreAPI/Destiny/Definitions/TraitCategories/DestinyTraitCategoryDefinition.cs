using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.Traits;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.TraitCategories
{
    [DestinyDefinition(name: "DestinyTraitCategoryDefinition", presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyTraitCategoryDefinition : IDestinyDefinition
    {
        /// <summary>
        /// String for this trait category
        /// </summary>
        public string TraitCategoryId { get; }
        /// <summary>
        /// Traits that are in this category
        /// </summary>
        public List<DefinitionHashPointer<DestinyTraitDefinition>> Traits { get; }
        /// <summary>
        /// Possible trait strings for searching in this category
        /// </summary>
        public List<string> TraitIds { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }


        [JsonConstructor]
        private DestinyTraitCategoryDefinition(string traitCategoryId, List<uint> traitHashes, List<string> traitIds, bool blacklisted, uint hash, int index, bool redacted)
        {
            TraitCategoryId = traitCategoryId;
            Traits = new List<DefinitionHashPointer<DestinyTraitDefinition>>();
            if (traitHashes != null)
            {
                foreach (var traitHash in traitHashes)
                {
                    Traits.Add(new DefinitionHashPointer<DestinyTraitDefinition>(traitHash, DefinitionsEnum.DestinyTraitDefinition));
                }
            }
            TraitIds = traitIds;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {TraitCategoryId}";
        }
    }
}
