using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Items;

public sealed class DestinyItemObjectivesComponent
{

    [JsonPropertyName("objectives")]
    public List<Destiny.Quests.DestinyObjectiveProgress> Objectives { get; init; }

    [JsonPropertyName("flavorObjective")]
    public Destiny.Quests.DestinyObjectiveProgress FlavorObjective { get; init; }

    [JsonPropertyName("dateCompleted")]
    public DateTime? DateCompleted { get; init; }
}
