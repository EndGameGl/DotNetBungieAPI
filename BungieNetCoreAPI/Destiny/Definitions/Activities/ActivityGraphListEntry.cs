using BungieNetCoreAPI.Destiny.Definitions.ActivityGraphs;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Activities
{
    public class ActivityGraphListEntry
    {
        public DefinitionHashPointer<DestinyActivityGraphDefinition> ActivityGraph { get; }

        [JsonConstructor]
        private ActivityGraphListEntry(uint activityGraphHash)
        {
            ActivityGraph = new DefinitionHashPointer<DestinyActivityGraphDefinition>(activityGraphHash, DefinitionsEnum.DestinyActivityGraphDefinition);
        }
    }
}
