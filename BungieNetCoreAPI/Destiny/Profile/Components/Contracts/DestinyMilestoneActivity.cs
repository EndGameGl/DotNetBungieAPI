using NetBungieAPI.Destiny.Definitions.Activities;
using NetBungieAPI.Destiny.Definitions.ActivityModes;
using NetBungieAPI.Destiny.Definitions.ActivityModifiers;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyMilestoneActivity
    {
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; }
        public DefinitionHashPointer<DestinyActivityModeDefinition> ActivityMode { get; init; }
        public DestinyActivityModeType? ActivityModeType { get; init; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyActivityModifierDefinition>> Modifiers { get; init; }
        public DestinyMilestoneActivityVariant[] Variants { get; init; }

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
