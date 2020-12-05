using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.ActivityGraphs
{
    public class ActivityGraphLinkedGraphEntryLinkedGraphEntry
    {
        public DefinitionHashPointer<DestinyActivityGraphDefinition> ActivityGraph { get; }

        [JsonConstructor]
        private ActivityGraphLinkedGraphEntryLinkedGraphEntry(uint activityGraphHash)
        {
            ActivityGraph = new DefinitionHashPointer<DestinyActivityGraphDefinition>(activityGraphHash, "DestinyActivityGraphDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
        }
    }
}
