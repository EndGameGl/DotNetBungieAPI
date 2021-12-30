using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Director;

public sealed class DestinyActivityGraphNodeActivityDefinition
{

    [JsonPropertyName("nodeActivityId")]
    public uint NodeActivityId { get; init; }

    [JsonPropertyName("activityHash")]
    public uint ActivityHash { get; init; }
}
