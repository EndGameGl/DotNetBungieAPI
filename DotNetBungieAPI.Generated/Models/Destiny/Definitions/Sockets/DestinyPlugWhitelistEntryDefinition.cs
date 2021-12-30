using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Sockets;

public sealed class DestinyPlugWhitelistEntryDefinition
{

    [JsonPropertyName("categoryHash")]
    public uint CategoryHash { get; init; }

    [JsonPropertyName("categoryIdentifier")]
    public string CategoryIdentifier { get; init; }

    [JsonPropertyName("reinitializationPossiblePlugHashes")]
    public List<uint> ReinitializationPossiblePlugHashes { get; init; }
}
