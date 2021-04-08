using NetBungieAPI.Destiny.Definitions.Checklists;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyProfileProgressionComponent
    {
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyChecklistDefinition>, ReadOnlyDictionary<uint, bool>> Checklists { get; init; }
        public DestinyArtifactProfileScoped SeasonalArtifact { get; init; }

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
