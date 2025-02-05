using DotNetBungieAPI.Models.Attributes;

namespace DotNetBungieAPI.Models.Destiny.Definitions.ActivityGraphs;

/// <summary>
///     Represents a Map View in the director: be them overview views, destination views, or other.
///     <para />
///     They have nodes which map to activities, and other various visual elements that we(or others) may or may not be
///     able to use.
///     <para />
///     Activity graphs, most importantly, have nodes which can have activities in various states of playability.
///     <para />
///     Unfortunately, activity graphs are combined at runtime with Game UI-only assets such as fragments of map images,
///     various in-game special effects, decals etc... that we don't get in these definitions.
///     <para />
///     If we end up having time, we may end up trying to manually populate those here: but the last time we tried that,
///     before the lead-up to D1, it proved to be unmaintainable as the game's content changed. So don't bet the farm on us
///     providing that content in this definition.
/// </summary>
[DestinyDefinition(DefinitionsEnum.DestinyActivityGraphDefinition)]
public sealed record DestinyActivityGraphDefinition
    : IDestinyDefinition,
        IDeepEquatable<DestinyActivityGraphDefinition>
{
    /// <summary>
    ///     These represent the visual "nodes" on the map's view. These are the activities you can click on in the map.
    /// </summary>
    [JsonPropertyName("nodes")]
    public ReadOnlyCollection<DestinyActivityGraphNodeDefinition> Nodes { get; init; } =
        ReadOnlyCollection<DestinyActivityGraphNodeDefinition>.Empty;

    /// <summary>
    ///     Represents one-off/special UI elements that appear on the map.
    /// </summary>
    [JsonPropertyName("artElements")]
    public ReadOnlyCollection<DestinyActivityGraphArtElementDefinition> ArtElements { get; init; } =
        ReadOnlyCollection<DestinyActivityGraphArtElementDefinition>.Empty;

    /// <summary>
    ///     Represents connections between graph nodes. However, it lacks context that we'd need to make good use of it.
    /// </summary>
    [JsonPropertyName("connections")]
    public ReadOnlyCollection<DestinyActivityGraphConnectionDefinition> Connections { get; init; } =
        ReadOnlyCollection<DestinyActivityGraphConnectionDefinition>.Empty;

    /// <summary>
    ///     Objectives can display on maps, and this is supposedly metadata for that. I have not had the time to analyze the
    ///     details of what is useful within however: we could be missing important data to make this work. Expect this
    ///     property to be expanded on later if possible.
    /// </summary>
    [JsonPropertyName("displayObjectives")]
    public ReadOnlyCollection<DestinyActivityGraphDisplayObjectiveDefinition> DisplayObjectives { get; init; } =
        ReadOnlyCollection<DestinyActivityGraphDisplayObjectiveDefinition>.Empty;

    /// <summary>
    ///     Progressions can also display on maps, but similarly to displayObjectives we appear to lack some required
    ///     information and context right now. We will have to look into it later and add more data if possible.
    /// </summary>
    [JsonPropertyName("displayProgressions")]
    public ReadOnlyCollection<DestinyActivityGraphDisplayProgressionDefinition> DisplayProgressions { get; init; } =
        ReadOnlyCollection<DestinyActivityGraphDisplayProgressionDefinition>.Empty;

    [JsonPropertyName("ignoreForMilestones")]
    public bool IgnoreForMilestones { get; init; }

    /// <summary>
    ///     Represents links between this Activity Graph and other ones.
    /// </summary>
    [JsonPropertyName("linkedGraphs")]
    public ReadOnlyCollection<DestinyLinkedGraphDefinition> LinkedGraphs { get; init; } =
        ReadOnlyCollection<DestinyLinkedGraphDefinition>.Empty;

    [JsonPropertyName("uiScreen")]
    public int UIScreen { get; init; }

    public bool DeepEquals(DestinyActivityGraphDefinition other)
    {
        return other != null
            && ArtElements.DeepEqualsReadOnlyCollection(other.ArtElements)
            && Connections.DeepEqualsReadOnlyCollection(other.Connections)
            && DisplayObjectives.DeepEqualsReadOnlyCollection(other.DisplayObjectives)
            && DisplayProgressions.DeepEqualsReadOnlyCollection(other.DisplayProgressions)
            && IgnoreForMilestones == other.IgnoreForMilestones
            && LinkedGraphs.DeepEqualsReadOnlyCollection(other.LinkedGraphs)
            && Nodes.DeepEqualsReadOnlyCollection(other.Nodes)
            && UIScreen == other.UIScreen
            && Blacklisted == other.Blacklisted
            && Hash == other.Hash
            && Index == other.Index
            && Redacted == other.Redacted;
    }

    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyActivityGraphDefinition;

    [JsonPropertyName("blacklisted")]
    public bool Blacklisted { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
