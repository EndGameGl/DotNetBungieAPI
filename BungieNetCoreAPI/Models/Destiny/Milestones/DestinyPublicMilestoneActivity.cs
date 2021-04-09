using NetBungieAPI.Models.Destiny.Definitions.Activities;
using NetBungieAPI.Models.Destiny.Definitions.ActivityModes;
using NetBungieAPI.Models.Destiny.Definitions.ActivityModifiers;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Milestones
{
    public sealed record DestinyPublicMilestoneActivity
    {
        [JsonPropertyName("activityHash")]
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; } = DefinitionHashPointer<DestinyActivityDefinition>.Empty;
        [JsonPropertyName("modifierHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyActivityModifierDefinition>> Modifiers { get; init; } = Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyActivityModifierDefinition>>();
        [JsonPropertyName("variants")]
        public ReadOnlyCollection<DestinyPublicMilestoneActivityVariant> Variants { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyPublicMilestoneActivityVariant>();
        [JsonPropertyName("activityModeHash")]
        public DefinitionHashPointer<DestinyActivityModeDefinition> ActivityMode { get; init; } = DefinitionHashPointer<DestinyActivityModeDefinition>.Empty;
        [JsonPropertyName("activityModeType")]
        public DestinyActivityModeType? ActivityModeType { get; init; }
    }
}
