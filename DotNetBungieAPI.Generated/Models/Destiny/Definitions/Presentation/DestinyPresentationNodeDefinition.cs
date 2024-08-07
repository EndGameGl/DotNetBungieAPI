namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Presentation;

/// <summary>
///     A PresentationNode is an entity that represents a logical grouping of other entities visually/organizationally.
/// <para />
///     For now, Presentation Nodes may contain the following... but it may be used for more in the future:
/// <para />
///     - Collectibles - Records (Or, as the public will call them, "Triumphs." Don't ask me why we're overloading the term "Triumph", it still hurts me to think about it) - Metrics (aka Stat Trackers) - Other Presentation Nodes, allowing a tree of Presentation Nodes to be created
/// <para />
///     Part of me wants to break these into conceptual definitions per entity being collected, but the possibility of these different types being mixed in the same UI and the possibility that it could actually be more useful to return the "bare metal" presentation node concept has resulted in me deciding against that for the time being.
/// <para />
///     We'll see if I come to regret this as well.
/// </summary>
public class DestinyPresentationNodeDefinition
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; set; }

    /// <summary>
    ///     The original icon for this presentation node, before we futzed with it.
    /// </summary>
    [JsonPropertyName("originalIcon")]
    public string? OriginalIcon { get; set; }

    /// <summary>
    ///     Some presentation nodes are meant to be explicitly shown on the "root" or "entry" screens for the feature to which they are related. You should use this icon when showing them on such a view, if you have a similar "entry point" view in your UI. If you don't have a UI, then I guess it doesn't matter either way does it?
    /// </summary>
    [JsonPropertyName("rootViewIcon")]
    public string? RootViewIcon { get; set; }

    [JsonPropertyName("nodeType")]
    public Destiny.DestinyPresentationNodeType? NodeType { get; set; }

    /// <summary>
    ///     Primarily for Guardian Ranks, this property if the contents of this node are tied to the current season. These nodes are shown with a different color for the in-game Guardian Ranks display.
    /// </summary>
    [JsonPropertyName("isSeasonal")]
    public bool? IsSeasonal { get; set; }

    /// <summary>
    ///     Indicates whether this presentation node's state is determined on a per-character or on an account-wide basis.
    /// </summary>
    [JsonPropertyName("scope")]
    public Destiny.DestinyScope? Scope { get; set; }

    /// <summary>
    ///     If this presentation node shows a related objective (for instance, if it tracks the progress of its children), the objective being tracked is indicated here.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyObjectiveDefinition>("Destiny.Definitions.DestinyObjectiveDefinition")]
    [JsonPropertyName("objectiveHash")]
    public uint? ObjectiveHash { get; set; }

    /// <summary>
    ///     If this presentation node has an associated "Record" that you can accomplish for completing its children, this is the identifier of that Record.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.Records.DestinyRecordDefinition>("Destiny.Definitions.Records.DestinyRecordDefinition")]
    [JsonPropertyName("completionRecordHash")]
    public uint? CompletionRecordHash { get; set; }

    /// <summary>
    ///     The child entities contained by this presentation node.
    /// </summary>
    [JsonPropertyName("children")]
    public Destiny.Definitions.Presentation.DestinyPresentationNodeChildrenBlock? Children { get; set; }

    /// <summary>
    ///     A hint for how to display this presentation node when it's shown in a list.
    /// </summary>
    [JsonPropertyName("displayStyle")]
    public Destiny.DestinyPresentationDisplayStyle? DisplayStyle { get; set; }

    /// <summary>
    ///     A hint for how to display this presentation node when it's shown in its own detail screen.
    /// </summary>
    [JsonPropertyName("screenStyle")]
    public Destiny.DestinyPresentationScreenStyle? ScreenStyle { get; set; }

    /// <summary>
    ///     The requirements for being able to interact with this presentation node and its children.
    /// </summary>
    [JsonPropertyName("requirements")]
    public Destiny.Definitions.Presentation.DestinyPresentationNodeRequirementsBlock? Requirements { get; set; }

    /// <summary>
    ///     If this presentation node has children, but the game doesn't let you inspect the details of those children, that is indicated here.
    /// </summary>
    [JsonPropertyName("disableChildSubscreenNavigation")]
    public bool? DisableChildSubscreenNavigation { get; set; }

    [JsonPropertyName("maxCategoryRecordScore")]
    public int? MaxCategoryRecordScore { get; set; }

    [JsonPropertyName("presentationNodeType")]
    public Destiny.DestinyPresentationNodeType? PresentationNodeType { get; set; }

    [JsonPropertyName("traitIds")]
    public List<string> TraitIds { get; set; }

    [Destiny2DefinitionList<Destiny.Definitions.Traits.DestinyTraitDefinition>("Destiny.Definitions.Traits.DestinyTraitDefinition")]
    [JsonPropertyName("traitHashes")]
    public List<uint> TraitHashes { get; set; }

    /// <summary>
    ///     A quick reference to presentation nodes that have this node as a child. Presentation nodes can be parented under multiple parents.
    /// </summary>
    [Destiny2DefinitionList<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition>("Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition")]
    [JsonPropertyName("parentNodeHashes")]
    public List<uint> ParentNodeHashes { get; set; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint? Hash { get; set; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int? Index { get; set; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool? Redacted { get; set; }
}
