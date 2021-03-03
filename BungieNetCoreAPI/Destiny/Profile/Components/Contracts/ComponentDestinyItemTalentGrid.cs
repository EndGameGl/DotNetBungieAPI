using BungieNetCoreAPI.Destiny.Definitions.TalentGrids;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class ComponentDestinyItemTalentGrid
    {
        public DefinitionHashPointer<DestinyTalentGridDefinition> TalentGrid { get; }
        public ReadOnlyCollection<DestinyTalentNode> Nodes { get; }
        public bool IsGridComplete { get; }
        public DestinyProgression GridProgression { get; }

        [JsonConstructor]
        internal ComponentDestinyItemTalentGrid(uint talentGridHash, DestinyTalentNode[] nodes, bool isGridComplete, DestinyProgression gridProgression)
        {
            TalentGrid = new DefinitionHashPointer<DestinyTalentGridDefinition>(talentGridHash, DefinitionsEnum.DestinyTalentGridDefinition);
            Nodes = nodes.AsReadOnlyOrEmpty();
            IsGridComplete = isGridComplete;
            GridProgression = gridProgression;
        }
    }
}
