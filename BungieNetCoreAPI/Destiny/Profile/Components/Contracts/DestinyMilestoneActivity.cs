using NetBungieApi.Destiny.Definitions.Activities;
using NetBungieApi.Destiny.Definitions.ActivityModes;
using NetBungieApi.Destiny.Definitions.ActivityModifiers;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Profile.Components.Contracts
{
    public class DestinyMilestoneActivity
    {
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; }
        public DefinitionHashPointer<DestinyActivityModeDefinition> ActivityMode { get; }
        public DestinyActivityModeType? ActivityModeType { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyActivityModifierDefinition>> Modifiers { get; }
        public DestinyMilestoneActivityVariant[] Variants { get; }

        [JsonConstructor]
        internal DestinyMilestoneActivity(uint activityHash, uint? activityModeHash, DestinyActivityModeType? activityModeType, uint[] modifierHashes,
            DestinyMilestoneActivityVariant[] variants)
        {
            Activity = new DefinitionHashPointer<DestinyActivityDefinition>(activityHash, DefinitionsEnum.DestinyActivityDefinition);
            ActivityMode = new DefinitionHashPointer<DestinyActivityModeDefinition>(activityModeHash, DefinitionsEnum.DestinyActivityModeDefinition);
            ActivityModeType = activityModeType;
            Modifiers = modifierHashes.DefinitionsAsReadOnlyOrEmpty<DestinyActivityModifierDefinition>(DefinitionsEnum.DestinyActivityModifierDefinition);
            Variants = variants;
        }
    }
}
