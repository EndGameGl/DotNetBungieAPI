using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyTalentNodeStatBlock
    {
        public ReadOnlyCollection<DestinyStat> CurrentStepStats { get; }
        public ReadOnlyCollection<DestinyStat> NextStepStats { get; }

        [JsonConstructor]
        internal DestinyTalentNodeStatBlock(DestinyStat[] currentStepStats, DestinyStat[] nextStepStats)
        {
            CurrentStepStats = currentStepStats.AsReadOnlyOrEmpty();
            NextStepStats = nextStepStats.AsReadOnlyOrEmpty();
        }
    }
}
