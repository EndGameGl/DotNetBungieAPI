using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyItemObjectivesComponent
    {
        public ReadOnlyCollection<DestinyObjectiveProgress> Objectives { get; }
        public DestinyObjectiveProgress FlavorObjective { get; }
        public DateTime? DateCompleted { get; }

        [JsonConstructor]
        internal DestinyItemObjectivesComponent(DestinyObjectiveProgress[] objectives, DestinyObjectiveProgress flavorObjective, DateTime? dateCompleted)
        {
            Objectives = objectives.AsReadOnlyOrEmpty();
            FlavorObjective = flavorObjective;
            DateCompleted = dateCompleted;
        }
    }
}
