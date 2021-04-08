using NetBungieAPI.Destiny.Definitions.Activities;
using NetBungieAPI.Destiny.Definitions.ActivityModes;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyPublicMilestoneActivityVariant
    {
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; }
        public DefinitionHashPointer<DestinyActivityModeDefinition> ActivityMode { get; init; }
        public DestinyActivityModeType? ActivityModeType { get; init; }

        [JsonConstructor]
        internal DestinyPublicMilestoneActivityVariant(uint activityHash, uint? activityModeHash, DestinyActivityModeType? activityModeType)
        {
            Activity = new DefinitionHashPointer<DestinyActivityDefinition>(activityHash, DefinitionsEnum.DestinyActivityDefinition);
            ActivityMode = new DefinitionHashPointer<DestinyActivityModeDefinition>(activityModeHash, DefinitionsEnum.DestinyActivityModeDefinition);
            ActivityModeType = activityModeType;
        }
    }
}
