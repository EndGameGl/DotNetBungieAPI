using NetBungieAPI.Models.Destiny.Quests;
using System;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyItemObjectivesComponent
    {
        [JsonPropertyName("objectives")]
        public ReadOnlyCollection<DestinyObjectiveProgress> Objectives { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyObjectiveProgress>();
        [JsonPropertyName("flavorObjective")]
        public DestinyObjectiveProgress FlavorObjective { get; init; }
        [JsonPropertyName("dateCompleted")]
        public DateTime? DateCompleted { get; init; }
    }
}
