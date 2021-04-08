using NetBungieAPI.Destiny.Definitions.Activities;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.Milestones
{
    public class MilestoneActivities : IDeepEquatable<MilestoneActivities>
    {
        public ReadOnlyCollection<MilestoneActivityGraphNode> ActivityGraphNodes { get; init; }
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; }
        public ReadOnlyCollection<MilestoneActivityChallenge> Challenges { get; init; }
        public ReadOnlyCollection<MilestoneActivityPhase> Phases { get; init; }

        [JsonConstructor]
        internal MilestoneActivities(MilestoneActivityGraphNode[] activityGraphNodes, uint activityHash, MilestoneActivityChallenge[] challenges,
            MilestoneActivityPhase[] phases)
        {
            ActivityGraphNodes = activityGraphNodes.AsReadOnlyOrEmpty();
            Activity = new DefinitionHashPointer<DestinyActivityDefinition>(activityHash, DefinitionsEnum.DestinyActivityDefinition);
            Challenges = challenges.AsReadOnlyOrEmpty();
            Phases = phases.AsReadOnlyOrEmpty();
        }

        public bool DeepEquals(MilestoneActivities other)
        {
            return other != null &&
                   ActivityGraphNodes.DeepEqualsReadOnlyCollections(other.ActivityGraphNodes) &&
                   Activity.DeepEquals(other.Activity) &&
                   Challenges.DeepEqualsReadOnlyCollections(other.Challenges) &&
                   Phases.DeepEqualsReadOnlyCollections(other.Phases);
        }
    }
}
