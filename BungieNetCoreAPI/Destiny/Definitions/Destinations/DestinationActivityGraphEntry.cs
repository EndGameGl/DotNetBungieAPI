using BungieNetCoreAPI.Destiny.Definitions.ActivityGraphs;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Destinations
{
    public class DestinationActivityGraphEntry
    {
        public DefinitionHashPointer<DestinyActivityGraphDefinition> ActivityGraph { get; }

        [JsonConstructor]
        private DestinationActivityGraphEntry(uint activityGraphHash)
        {
            ActivityGraph = new DefinitionHashPointer<DestinyActivityGraphDefinition>(activityGraphHash, DefinitionsEnum.DestinyActivityGraphDefinition);
        }
    }
}
