using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyMetricComponent
    {
        public bool IsInvisible { get; }
        public DestinyObjectiveProgress ObjectiveProgress { get; }

        [JsonConstructor]
        internal DestinyMetricComponent(bool invisible, DestinyObjectiveProgress objectiveProgress)
        {
            IsInvisible = invisible;
            ObjectiveProgress = objectiveProgress;
        }
    }
}
