using BungieNetCoreAPI.Destiny.Definitions.Activities;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.ActivityGraphs
{
    public class ActivityGraphNodeActivityEntry
    {
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; }
        public uint NodeActivityId { get; }

        [JsonConstructor]
        private ActivityGraphNodeActivityEntry(uint activityHash, uint nodeActivityId)
        {
            Activity =new DefinitionHashPointer<DestinyActivityDefinition>(activityHash, "DestinyActivityDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
            NodeActivityId = nodeActivityId;
        }
    }
}
