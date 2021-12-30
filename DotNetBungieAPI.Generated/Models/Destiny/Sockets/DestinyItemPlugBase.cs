using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Sockets;

public sealed class DestinyItemPlugBase
{

    [JsonPropertyName("plugItemHash")]
    public uint PlugItemHash { get; init; }

    [JsonPropertyName("canInsert")]
    public bool CanInsert { get; init; }

    [JsonPropertyName("enabled")]
    public bool Enabled { get; init; }

    [JsonPropertyName("insertFailIndexes")]
    public List<int> InsertFailIndexes { get; init; }

    [JsonPropertyName("enableFailIndexes")]
    public List<int> EnableFailIndexes { get; init; }
}
