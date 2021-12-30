using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Director;

public sealed class DestinyActivityGraphDisplayProgressionDefinition
{

    [JsonPropertyName("id")]
    public uint Id { get; init; }

    [JsonPropertyName("progressionHash")]
    public uint ProgressionHash { get; init; }
}
