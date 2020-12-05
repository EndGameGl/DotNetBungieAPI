using BungieNetCoreAPI.Destiny.Definitions.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemTranslationBlockArrangement
    {
        public uint ArtArrangementHash { get; }
        public DefinitionHashPointer<DestinyClassDefinition> Class { get; }       

        [JsonConstructor]
        private InventoryItemTranslationBlockArrangement(uint artArrangementHash, uint classHash)
        {
            ArtArrangementHash = artArrangementHash;
            Class = new DefinitionHashPointer<DestinyClassDefinition>(classHash, "DestinyClassDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);           
        }
    }
}
