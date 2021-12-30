using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny;

public sealed class DestinyProgressionResetEntry
{

    [JsonPropertyName("season")]
    public int Season { get; init; }

    [JsonPropertyName("resets")]
    public int Resets { get; init; }
}
