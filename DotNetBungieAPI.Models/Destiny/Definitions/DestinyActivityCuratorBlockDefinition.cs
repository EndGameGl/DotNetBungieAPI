namespace DotNetBungieAPI.Models.Destiny.Definitions;

public sealed class DestinyActivityCuratorBlockDefinition
{
    /// <summary>
    ///     Sort order
    /// </summary>
    [JsonPropertyName("quickplaySortPriority")]
    public int QuickplaySortPriority { get; init; }

    /// <summary>
    ///     Whether this activity should be sorted to the front of the Portal category
    /// </summary>
    [JsonPropertyName("quickplaySortToFront")]
    public bool QuickplaySortToFront { get; init; }
}
