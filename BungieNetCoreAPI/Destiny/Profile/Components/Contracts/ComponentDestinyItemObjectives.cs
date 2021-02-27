﻿using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class ComponentDestinyItemObjectives
    {
        public ReadOnlyCollection<DestinyObjectiveProgress> Objectives { get; }
        public DestinyObjectiveProgress FlavorObjective { get; }
        public DateTime? DateCompleted { get; }

        [JsonConstructor]
        internal ComponentDestinyItemObjectives(DestinyObjectiveProgress[] objectives, DestinyObjectiveProgress flavorObjective, DateTime? dateCompleted)
        {
            Objectives = objectives.AsReadOnlyOrEmpty();
            FlavorObjective = flavorObjective;
            DateCompleted = dateCompleted;
        }
    }
}
