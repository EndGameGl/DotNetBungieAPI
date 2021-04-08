using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyRecordComponent
    {
        public DestinyRecordState State { get; init; }
        public ReadOnlyCollection<DestinyObjectiveProgress> Objectives { get; init; }
        public ReadOnlyCollection<DestinyObjectiveProgress> IntervalObjectives { get; init; }
        public int IntervalsRedeemedCount { get; init; }

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
