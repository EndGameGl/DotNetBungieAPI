using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny;

public sealed class DestinyTalentNodeStatBlock
{

    [JsonPropertyName("currentStepStats")]
    public List<Destiny.DestinyStat> CurrentStepStats { get; init; }

    [JsonPropertyName("nextStepStats")]
    public List<Destiny.DestinyStat> NextStepStats { get; init; }
}
