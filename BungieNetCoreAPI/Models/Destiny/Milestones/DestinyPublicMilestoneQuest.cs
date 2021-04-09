using NetBungieAPI.Models.Destiny.Definitions.Milestones;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Milestones
{
    public sealed record DestinyPublicMilestoneQuest
    {
        [JsonPropertyName("questItemHash")]
        public DefinitionHashPointer<DestinyMilestoneDefinition> QuestItem { get; init; } = DefinitionHashPointer<DestinyMilestoneDefinition>.Empty;
        [JsonPropertyName("activity")]
        public DestinyPublicMilestoneActivity Activity { get; init; }
        [JsonPropertyName("challenges")]
        public ReadOnlyCollection<DestinyPublicMilestoneChallenge> Challenges { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyPublicMilestoneChallenge>();
    }
}
