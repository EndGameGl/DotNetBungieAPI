using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Profile.Components.Contracts
{
    public class DestinyRecordComponent
    {
        public DestinyRecordState State { get; }
        public ReadOnlyCollection<DestinyObjectiveProgress> Objectives { get; }
        public ReadOnlyCollection<DestinyObjectiveProgress> IntervalObjectives { get; }
        public int IntervalsRedeemedCount { get; }

        [JsonConstructor]
        internal DestinyRecordComponent(DestinyRecordState state, DestinyObjectiveProgress[] objectives, DestinyObjectiveProgress[] intervalObjectives, 
            int intervalsRedeemedCount)
        {
            State = state;
            Objectives = objectives.AsReadOnlyOrEmpty();
            IntervalObjectives = intervalObjectives.AsReadOnlyOrEmpty();
            IntervalsRedeemedCount = intervalsRedeemedCount;
        }
    }
}
