using NetBungieAPI.Destiny.Definitions.Activities;
using NetBungieAPI.Destiny.Definitions.ActivityModes;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyMilestoneActivityVariant
    {
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; }
        public DestinyMilestoneActivityCompletionStatus CompletionStatus { get; }
        public DefinitionHashPointer<DestinyActivityModeDefinition> ActivityMode { get; }
        public DestinyActivityModeType? ActivityModeType { get; }

        [JsonConstructor]
        internal DestinyMilestoneActivityVariant(uint activityHash, DestinyMilestoneActivityCompletionStatus completionStatus, uint? activityModeHash,
            DestinyActivityModeType? activityModeType)
        {
            Activity = new DefinitionHashPointer<DestinyActivityDefinition>(activityHash, DefinitionsEnum.DestinyActivityDefinition);
            CompletionStatus = completionStatus;
            ActivityMode = new DefinitionHashPointer<DestinyActivityModeDefinition>(activityModeHash, DefinitionsEnum.DestinyActivityModeDefinition);
            ActivityModeType = activityModeType;
        }
    }
}
