using BungieNetCoreAPI.Destiny.Definitions.Checklists;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyProfileProgressionComponent
    {
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyChecklistDefinition>, ReadOnlyDictionary<uint, bool>> Checklists { get; }
        public DestinyArtifactProfileScoped SeasonalArtifact { get; }

        [JsonConstructor]
        internal DestinyProfileProgressionComponent(Dictionary<uint, Dictionary<uint, bool>> checklists, DestinyArtifactProfileScoped seasonalArtifact)
        {
            Checklists = checklists
                .ToDictionary(x => x.Key, x => x.Value.AsReadOnlyDictionaryOrEmpty())
                .AsReadOnlyDictionaryWithDefinitionKeyOrEmpty<DestinyChecklistDefinition, ReadOnlyDictionary<uint, bool>>(DefinitionsEnum.DestinyChecklistDefinition);
            SeasonalArtifact = seasonalArtifact;
        }
    }
}
