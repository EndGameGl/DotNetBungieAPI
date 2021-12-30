using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyActivityChallengeDefinition
{

    [JsonPropertyName("objectiveHash")]
    public uint ObjectiveHash { get; init; }

    [JsonPropertyName("dummyRewards")]
    public List<Destiny.DestinyItemQuantity> DummyRewards { get; init; }
}
