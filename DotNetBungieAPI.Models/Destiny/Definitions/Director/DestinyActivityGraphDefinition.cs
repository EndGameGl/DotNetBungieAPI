namespace DotNetBungieAPI.Models.Destiny.Definitions.Director;

/// <summary>
///     Represents a Map View in the director: be them overview views, destination views, or other.
/// <para />
///     They have nodes which map to activities, and other various visual elements that we (or others) may or may not be able to use.
/// <para />
///     Activity graphs, most importantly, have nodes which can have activities in various states of playability.
/// <para />
///     Unfortunately, activity graphs are combined at runtime with Game UI-only assets such as fragments of map images, various in-game special effects, decals etc... that we don't get in these definitions.
/// <para />
///     If we end up having time, we may end up trying to manually populate those here: but the last time we tried that, before the lead-up to D1, it proved to be unmaintainable as the game's content changed. So don't bet the farm on us providing that content in this definition.
/// </summary>
[DestinyDefinition(DefinitionsEnum.DestinyActivityGraphDefinition)]
public sealed class DestinyActivityGraphDefinition : IDestinyDefinition
{
    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyActivityGraphDefinition;

    /// <summary>
    ///     These represent the visual "nodes" on the map's view. These are the activities you can click on in the map.
    /// </summary>
    [JsonPropertyName("nodes")]
    public Destiny.Definitions.Director.DestinyActivityGraphNodeDefinition[]? Nodes { get; init; }

    /// <summary>
    ///     Represents one-off/special UI elements that appear on the map.
    /// </summary>
    [JsonPropertyName("artElements")]
    public Destiny.Definitions.Director.DestinyActivityGraphArtElementDefinition[]? ArtElements { get; init; }

    /// <summary>
    ///     Represents connections between graph nodes. However, it lacks context that we'd need to make good use of it.
    /// </summary>
    [JsonPropertyName("connections")]
    public Destiny.Definitions.Director.DestinyActivityGraphConnectionDefinition[]? Connections { get; init; }

    /// <summary>
    ///     Objectives can display on maps, and this is supposedly metadata for that. I have not had the time to analyze the details of what is useful within however: we could be missing important data to make this work. Expect this property to be expanded on later if possible.
    /// </summary>
    [JsonPropertyName("displayObjectives")]
    public Destiny.Definitions.Director.DestinyActivityGraphDisplayObjectiveDefinition[]? DisplayObjectives { get; init; }

    /// <summary>
    ///     Progressions can also display on maps, but similarly to displayObjectives we appear to lack some required information and context right now. We will have to look into it later and add more data if possible.
    /// </summary>
    [JsonPropertyName("displayProgressions")]
    public Destiny.Definitions.Director.DestinyActivityGraphDisplayProgressionDefinition[]? DisplayProgressions { get; init; }

    /// <summary>
    ///     Represents links between this Activity Graph and other ones.
    /// </summary>
    [JsonPropertyName("linkedGraphs")]
    public Destiny.Definitions.Director.DestinyLinkedGraphDefinition[]? LinkedGraphs { get; init; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; init; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
