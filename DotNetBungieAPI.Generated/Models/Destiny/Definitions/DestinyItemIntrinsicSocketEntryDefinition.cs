using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyItemIntrinsicSocketEntryDefinition
{

    [JsonPropertyName("plugItemHash")]
    public uint PlugItemHash { get; init; }

    [JsonPropertyName("socketTypeHash")]
    public uint SocketTypeHash { get; init; }

    [JsonPropertyName("defaultVisible")]
    public bool DefaultVisible { get; init; }
}
