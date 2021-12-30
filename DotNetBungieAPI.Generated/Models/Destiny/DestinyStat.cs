using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny;

public sealed class DestinyStat
{

    [JsonPropertyName("statHash")]
    public uint StatHash { get; init; }

    [JsonPropertyName("value")]
    public int Value { get; init; }
}
