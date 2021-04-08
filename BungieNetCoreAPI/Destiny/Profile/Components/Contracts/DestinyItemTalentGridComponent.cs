using NetBungieAPI.Destiny.Definitions.TalentGrids;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyItemTalentGridComponent
    {
        public DefinitionHashPointer<DestinyTalentGridDefinition> TalentGrid { get; init; }
        public ReadOnlyCollection<DestinyTalentNode> Nodes { get; init; }
        public bool IsGridComplete { get; init; }
        public DestinyProgression GridProgression { get; init; }

        [JsonConstructor]
        internal DestinyItemTalentGridComponent(uint talentGridHash, DestinyTalentNode[] nodes, bool isGridComplete, DestinyProgression gridProgression)
        {
            TalentGrid = new DefinitionHashPointer<DestinyTalentGridDefinition>(talentGridHash, DefinitionsEnum.DestinyTalentGridDefinition);
            Nodes = nodes.AsReadOnlyOrEmpty();
            IsGridComplete = isGridComplete;
            GridProgression = gridProgression;
        }
    }
}
