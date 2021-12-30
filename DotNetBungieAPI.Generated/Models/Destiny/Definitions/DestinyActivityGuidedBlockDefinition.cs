using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyActivityGuidedBlockDefinition
{

    [JsonPropertyName("guidedMaxLobbySize")]
    public int GuidedMaxLobbySize { get; init; }

    [JsonPropertyName("guidedMinLobbySize")]
    public int GuidedMinLobbySize { get; init; }

    [JsonPropertyName("guidedDisbandCount")]
    public int GuidedDisbandCount { get; init; }
}
