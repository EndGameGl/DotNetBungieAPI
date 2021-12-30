using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Requests.Actions;

public sealed class DestinyInsertPlugsRequestEntry
{

    [JsonPropertyName("socketIndex")]
    public int SocketIndex { get; init; }

    [JsonPropertyName("socketArrayType")]
    public Destiny.Requests.Actions.DestinySocketArrayType SocketArrayType { get; init; }

    [JsonPropertyName("plugItemHash")]
    public uint PlugItemHash { get; init; }
}
