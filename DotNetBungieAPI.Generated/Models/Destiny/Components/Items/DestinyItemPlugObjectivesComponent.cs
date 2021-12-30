using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Items;

public sealed class DestinyItemPlugObjectivesComponent
{

    [JsonPropertyName("objectivesPerPlug")]
    public Dictionary<uint, List<Destiny.Quests.DestinyObjectiveProgress>> ObjectivesPerPlug { get; init; }
}
