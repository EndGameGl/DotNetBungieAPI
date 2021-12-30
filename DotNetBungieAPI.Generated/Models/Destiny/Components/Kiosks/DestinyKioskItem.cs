using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Kiosks;

public sealed class DestinyKioskItem
{

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("canAcquire")]
    public bool CanAcquire { get; init; }

    [JsonPropertyName("failureIndexes")]
    public List<int> FailureIndexes { get; init; }

    [JsonPropertyName("flavorObjective")]
    public Destiny.Quests.DestinyObjectiveProgress FlavorObjective { get; init; }
}
