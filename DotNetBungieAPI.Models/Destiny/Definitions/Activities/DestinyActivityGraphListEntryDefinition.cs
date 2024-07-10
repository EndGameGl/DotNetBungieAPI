using DotNetBungieAPI.Models.Destiny.Definitions.ActivityGraphs;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Activities;

/// <summary>
///     Destinations and Activities may have default Activity Graphs that should be shown when you bring up the Director
///     and are playing in either.
///     <para />
///     This contract defines the graph referred to and the gating for when it is relevant.
/// </summary>
public sealed record DestinyActivityGraphListEntryDefinition
    : IDeepEquatable<DestinyActivityGraphListEntryDefinition>
{
    /// <summary>
    ///     DestinyActivityGraphDefinition that should be shown when opening the director.
    /// </summary>
    [JsonPropertyName("activityGraphHash")]
    public DefinitionHashPointer<DestinyActivityGraphDefinition> ActivityGraph { get; init; } =
        DefinitionHashPointer<DestinyActivityGraphDefinition>.Empty;

    public bool DeepEquals(DestinyActivityGraphListEntryDefinition other)
    {
        return other != null && ActivityGraph.DeepEquals(other.ActivityGraph);
    }
}
