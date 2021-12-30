using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyVendorItemSocketOverride
{

    [JsonPropertyName("singleItemHash")]
    public uint? SingleItemHash { get; init; }

    [JsonPropertyName("randomizedOptionsCount")]
    public int RandomizedOptionsCount { get; init; }

    [JsonPropertyName("socketTypeHash")]
    public uint SocketTypeHash { get; init; }
}
