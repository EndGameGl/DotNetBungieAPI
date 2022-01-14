namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Director;

/// <summary>
///     When a Graph needs to show active Progressions, this defines those objectives as well as an identifier.
/// </summary>
public sealed class DestinyActivityGraphDisplayProgressionDefinition
{

    [JsonPropertyName("id")]
    public uint Id { get; init; }

    [JsonPropertyName("progressionHash")]
    public uint ProgressionHash { get; init; }
}
