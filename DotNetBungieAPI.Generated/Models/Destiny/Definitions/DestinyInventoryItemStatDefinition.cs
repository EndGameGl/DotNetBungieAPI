using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyInventoryItemStatDefinition
{

    [JsonPropertyName("statHash")]
    public uint StatHash { get; init; }

    [JsonPropertyName("value")]
    public int Value { get; init; }

    [JsonPropertyName("minimum")]
    public int Minimum { get; init; }

    [JsonPropertyName("maximum")]
    public int Maximum { get; init; }

    [JsonPropertyName("displayMaximum")]
    public int? DisplayMaximum { get; init; }
}
