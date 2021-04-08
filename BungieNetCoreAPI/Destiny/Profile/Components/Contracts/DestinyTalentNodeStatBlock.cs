using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyTalentNodeStatBlock
    {
        public ReadOnlyCollection<DestinyStat> CurrentStepStats { get; init; }
        public ReadOnlyCollection<DestinyStat> NextStepStats { get; init; }

        [JsonConstructor]
        internal DestinyTalentNodeStatBlock(DestinyStat[] currentStepStats, DestinyStat[] nextStepStats)
        {
            CurrentStepStats = currentStepStats.AsReadOnlyOrEmpty();
            NextStepStats = nextStepStats.AsReadOnlyOrEmpty();
        }
    }
}
