using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Director;

public sealed class DestinyActivityGraphConnectionDefinition
{

    [JsonPropertyName("sourceNodeHash")]
    public uint SourceNodeHash { get; init; }

    [JsonPropertyName("destNodeHash")]
    public uint DestNodeHash { get; init; }
}
