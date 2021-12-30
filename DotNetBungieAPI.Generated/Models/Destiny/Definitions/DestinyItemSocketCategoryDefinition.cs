using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyItemSocketCategoryDefinition
{

    [JsonPropertyName("socketCategoryHash")]
    public uint SocketCategoryHash { get; init; }

    [JsonPropertyName("socketIndexes")]
    public List<int> SocketIndexes { get; init; }
}
