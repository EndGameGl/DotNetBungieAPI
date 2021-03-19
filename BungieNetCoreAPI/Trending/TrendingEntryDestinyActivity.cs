using NetBungieAPI.Destiny;
using NetBungieAPI.Destiny.Definitions.Activities;
using NetBungieAPI.Destiny.Responses;
using Newtonsoft.Json;

namespace NetBungieAPI.Trending
{
    public class TrendingEntryDestinyActivity
    {
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; }
        public DestinyPublicActivityStatus Status { get; }

        [JsonConstructor]
        internal TrendingEntryDestinyActivity(uint activityHash, DestinyPublicActivityStatus status)
        {
            Activity = new DefinitionHashPointer<DestinyActivityDefinition>(activityHash, DefinitionsEnum.DestinyActivityDefinition);
            Status = status;
        }
    }
}
