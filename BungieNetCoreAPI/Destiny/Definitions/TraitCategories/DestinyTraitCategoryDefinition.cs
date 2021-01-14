using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.Traits;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.TraitCategories
{
    [DestinyDefinition("DestinyTraitCategoryDefinition")]
    public class DestinyTraitCategoryDefinition : DestinyDefinition
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


        [JsonConstructor]
        private DestinyTraitCategoryDefinition(string traitCategoryId, List<uint> traitHashes, List<string> traitIds, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            TraitCategoryId = traitCategoryId;
            Traits = new List<DefinitionHashPointer<DestinyTraitDefinition>>();
            if (traitHashes != null)
            {
                foreach (var traitHash in traitHashes)
                {
                    Traits.Add(new DefinitionHashPointer<DestinyTraitDefinition>(traitHash, "DestinyTraitDefinition"));
                }
            }
            TraitIds = traitIds;
        }

        public override string ToString()
        {
            return $"{Hash} {TraitCategoryId}";
        }
    }
}
