using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyItemObjectivesComponent
    {
        public ReadOnlyCollection<DestinyObjectiveProgress> Objectives { get; init; }
        public DestinyObjectiveProgress FlavorObjective { get; init; }
        public DateTime? DateCompleted { get; init; }

        [JsonConstructor]
        internal DestinyItemObjectivesComponent(DestinyObjectiveProgress[] objectives, DestinyObjectiveProgress flavorObjective, DateTime? dateCompleted)
        {
            Objectives = objectives.AsReadOnlyOrEmpty();
            FlavorObjective = flavorObjective;
            DateCompleted = dateCompleted;
        }
    }
}
