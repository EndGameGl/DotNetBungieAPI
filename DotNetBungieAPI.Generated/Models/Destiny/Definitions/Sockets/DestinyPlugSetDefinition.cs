using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Sockets;

public sealed class DestinyPlugSetDefinition
{

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("reusablePlugItems")]
    public List<Destiny.Definitions.DestinyItemSocketEntryPlugItemRandomizedDefinition> ReusablePlugItems { get; init; }

    [JsonPropertyName("isFakePlugSet")]
    public bool IsFakePlugSet { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
