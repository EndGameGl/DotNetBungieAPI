namespace DotNetBungieAPI.Models.Destiny.Definitions;

/// <summary>
///     An overly complicated wrapper for the item level at which the item should spawn.
/// </summary>
public sealed class DestinyItemCreationEntryLevelDefinition
{
    [JsonPropertyName("level")]
    public int Level { get; init; }
}
