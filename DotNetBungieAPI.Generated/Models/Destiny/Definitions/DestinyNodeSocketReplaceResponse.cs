using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyNodeSocketReplaceResponse
{

    [JsonPropertyName("socketTypeHash")]
    public uint SocketTypeHash { get; init; }

    [JsonPropertyName("plugItemHash")]
    public uint PlugItemHash { get; init; }
}
