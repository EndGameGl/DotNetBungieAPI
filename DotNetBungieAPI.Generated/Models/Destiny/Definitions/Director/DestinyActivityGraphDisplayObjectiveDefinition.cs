using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Director;

public sealed class DestinyActivityGraphDisplayObjectiveDefinition
{

    [JsonPropertyName("id")]
    public uint Id { get; init; }

    [JsonPropertyName("objectiveHash")]
    public uint ObjectiveHash { get; init; }
}
