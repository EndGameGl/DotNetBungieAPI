using NetBungieAPI.Destiny.Definitions.Activities;
using NetBungieAPI.Destiny.Definitions.ActivityModes;
using NetBungieAPI.Destiny.Definitions.ActivityModifiers;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyPublicMilestoneActivity
    {
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyActivityModifierDefinition>> Modifiers { get; }
        public ReadOnlyCollection<DestinyPublicMilestoneActivityVariant> Variants { get; }
        public DefinitionHashPointer<DestinyActivityModeDefinition> ActivityMode { get; }
        public DestinyActivityModeType? ActivityModeType { get; }

        [JsonConstructor]
        internal DestinyPublicMilestoneActivity(uint activityHash, uint[] modifierHashes, DestinyPublicMilestoneActivityVariant[] variants,
            uint? activityModeHash, DestinyActivityModeType? activityModeType)
        {
            Activity = new DefinitionHashPointer<DestinyActivityDefinition>(activityHash, DefinitionsEnum.DestinyActivityDefinition);
            Modifiers = modifierHashes.DefinitionsAsReadOnlyOrEmpty<DestinyActivityModifierDefinition>(DefinitionsEnum.DestinyActivityModifierDefinition);
            Variants = variants.AsReadOnlyOrEmpty();
            ActivityMode = new DefinitionHashPointer<DestinyActivityModeDefinition>(activityModeHash, DefinitionsEnum.DestinyActivityModeDefinition);
            ActivityModeType = activityModeType;
        }
    }
}
