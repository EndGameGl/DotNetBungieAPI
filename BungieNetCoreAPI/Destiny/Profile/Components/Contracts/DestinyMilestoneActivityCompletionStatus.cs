using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyMilestoneActivityCompletionStatus
    {
        public bool IsCompleted { get; init; }
        public ReadOnlyCollection<DestinyMilestoneActivityPhase> Phases { get; init; }

        [JsonConstructor]
        internal DestinyMilestoneActivityCompletionStatus(bool completed, DestinyMilestoneActivityPhase[] phases)
        {
            IsCompleted = completed;
            Phases = phases.AsReadOnlyOrEmpty();
        }
    }
}
