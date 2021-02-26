using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyMilestoneActivityCompletionStatus
    {
        public bool IsCompleted { get; }
        public ReadOnlyCollection<DestinyMilestoneActivityPhase> Phases { get; }

        [JsonConstructor]
        internal DestinyMilestoneActivityCompletionStatus(bool completed, DestinyMilestoneActivityPhase[] phases)
        {
            IsCompleted = completed;
            Phases = phases.AsReadOnlyOrEmpty();
        }
    }
}
