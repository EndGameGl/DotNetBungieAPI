namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Destinations and Activities may have default Activity Graphs that should be shown when you bring up the Director and are playing in either.
/// <para />
///     This contract defines the graph referred to and the gating for when it is relevant.
/// </summary>
public sealed class DestinyActivityGraphListEntryDefinition
{

    /// <summary>
    ///     The hash identifier of the DestinyActivityGraphDefinition that should be shown when opening the director.
    /// </summary>
    [JsonPropertyName("activityGraphHash")]
    public uint ActivityGraphHash { get; init; } // DestinyActivityGraphDefinition
}
