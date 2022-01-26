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
public class DestinyPresentationNodeDefinition : IDeepEquatable<DestinyPresentationNodeDefinition>
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

    /// <summary>
    ///     The original icon for this presentation node, before we futzed with it.
    /// </summary>
    [JsonPropertyName("originalIcon")]
    public string OriginalIcon { get; set; }

    /// <summary>
    ///     Some presentation nodes are meant to be explicitly shown on the "root" or "entry" screens for the feature to which they are related. You should use this icon when showing them on such a view, if you have a similar "entry point" view in your UI. If you don't have a UI, then I guess it doesn't matter either way does it?
    /// </summary>
    [JsonPropertyName("rootViewIcon")]
    public string RootViewIcon { get; set; }

    [JsonPropertyName("nodeType")]
    public Destiny.DestinyPresentationNodeType NodeType { get; set; }

    /// <summary>
    ///     Indicates whether this presentation node's state is determined on a per-character or on an account-wide basis.
    /// </summary>
    [JsonPropertyName("scope")]
    public Destiny.DestinyScope Scope { get; set; }

    /// <summary>
    ///     If this presentation node shows a related objective (for instance, if it tracks the progress of its children), the objective being tracked is indicated here.
    /// </summary>
    [JsonPropertyName("objectiveHash")]
    public uint? ObjectiveHash { get; set; }

    /// <summary>
    ///     If this presentation node has an associated "Record" that you can accomplish for completing its children, this is the identifier of that Record.
    /// </summary>
    [JsonPropertyName("completionRecordHash")]
    public uint? CompletionRecordHash { get; set; }

    /// <summary>
    ///     The child entities contained by this presentation node.
    /// </summary>
    [JsonPropertyName("children")]
    public Destiny.Definitions.Presentation.DestinyPresentationNodeChildrenBlock Children { get; set; }

    /// <summary>
    ///     A hint for how to display this presentation node when it's shown in a list.
    /// </summary>
    [JsonPropertyName("displayStyle")]
    public Destiny.DestinyPresentationDisplayStyle DisplayStyle { get; set; }

    /// <summary>
    ///     A hint for how to display this presentation node when it's shown in its own detail screen.
    /// </summary>
    [JsonPropertyName("screenStyle")]
    public Destiny.DestinyPresentationScreenStyle ScreenStyle { get; set; }

    /// <summary>
    ///     The requirements for being able to interact with this presentation node and its children.
    /// </summary>
    [JsonPropertyName("requirements")]
    public Destiny.Definitions.Presentation.DestinyPresentationNodeRequirementsBlock Requirements { get; set; }

    /// <summary>
    ///     If this presentation node has children, but the game doesn't let you inspect the details of those children, that is indicated here.
    /// </summary>
    [JsonPropertyName("disableChildSubscreenNavigation")]
    public bool DisableChildSubscreenNavigation { get; set; }

    [JsonPropertyName("maxCategoryRecordScore")]
    public int MaxCategoryRecordScore { get; set; }

    [JsonPropertyName("presentationNodeType")]
    public Destiny.DestinyPresentationNodeType PresentationNodeType { get; set; }

    [JsonPropertyName("traitIds")]
    public List<string> TraitIds { get; set; }

    [JsonPropertyName("traitHashes")]
    public List<uint> TraitHashes { get; set; }

    /// <summary>
    ///     A quick reference to presentation nodes that have this node as a child. Presentation nodes can be parented under multiple parents.
    /// </summary>
    [JsonPropertyName("parentNodeHashes")]
    public List<uint> ParentNodeHashes { get; set; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; set; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; set; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool Redacted { get; set; }

    public bool DeepEquals(DestinyPresentationNodeDefinition? other)
    {
        return other is not null &&
               (DisplayProperties is not null ? DisplayProperties.DeepEquals(other.DisplayProperties) : other.DisplayProperties is null) &&
               OriginalIcon == other.OriginalIcon &&
               RootViewIcon == other.RootViewIcon &&
               NodeType == other.NodeType &&
               Scope == other.Scope &&
               ObjectiveHash == other.ObjectiveHash &&
               CompletionRecordHash == other.CompletionRecordHash &&
               (Children is not null ? Children.DeepEquals(other.Children) : other.Children is null) &&
               DisplayStyle == other.DisplayStyle &&
               ScreenStyle == other.ScreenStyle &&
               (Requirements is not null ? Requirements.DeepEquals(other.Requirements) : other.Requirements is null) &&
               DisableChildSubscreenNavigation == other.DisableChildSubscreenNavigation &&
               MaxCategoryRecordScore == other.MaxCategoryRecordScore &&
               PresentationNodeType == other.PresentationNodeType &&
               TraitIds.DeepEqualsListNaive(other.TraitIds) &&
               TraitHashes.DeepEqualsListNaive(other.TraitHashes) &&
               ParentNodeHashes.DeepEqualsListNaive(other.ParentNodeHashes) &&
               Hash == other.Hash &&
               Index == other.Index &&
               Redacted == other.Redacted;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyPresentationNodeDefinition? other)
    {
        if (other is null) return;
        if (!DisplayProperties.DeepEquals(other.DisplayProperties))
        {
            DisplayProperties.Update(other.DisplayProperties);
            OnPropertyChanged(nameof(DisplayProperties));
        }
        if (OriginalIcon != other.OriginalIcon)
        {
            OriginalIcon = other.OriginalIcon;
            OnPropertyChanged(nameof(OriginalIcon));
        }
        if (RootViewIcon != other.RootViewIcon)
        {
            RootViewIcon = other.RootViewIcon;
            OnPropertyChanged(nameof(RootViewIcon));
        }
        if (NodeType != other.NodeType)
        {
            NodeType = other.NodeType;
            OnPropertyChanged(nameof(NodeType));
        }
        if (Scope != other.Scope)
        {
            Scope = other.Scope;
            OnPropertyChanged(nameof(Scope));
        }
        if (ObjectiveHash != other.ObjectiveHash)
        {
            ObjectiveHash = other.ObjectiveHash;
            OnPropertyChanged(nameof(ObjectiveHash));
        }
        if (CompletionRecordHash != other.CompletionRecordHash)
        {
            CompletionRecordHash = other.CompletionRecordHash;
            OnPropertyChanged(nameof(CompletionRecordHash));
        }
        if (!Children.DeepEquals(other.Children))
        {
            Children.Update(other.Children);
            OnPropertyChanged(nameof(Children));
        }
        if (DisplayStyle != other.DisplayStyle)
        {
            DisplayStyle = other.DisplayStyle;
            OnPropertyChanged(nameof(DisplayStyle));
        }
        if (ScreenStyle != other.ScreenStyle)
        {
            ScreenStyle = other.ScreenStyle;
            OnPropertyChanged(nameof(ScreenStyle));
        }
        if (!Requirements.DeepEquals(other.Requirements))
        {
            Requirements.Update(other.Requirements);
            OnPropertyChanged(nameof(Requirements));
        }
        if (DisableChildSubscreenNavigation != other.DisableChildSubscreenNavigation)
        {
            DisableChildSubscreenNavigation = other.DisableChildSubscreenNavigation;
            OnPropertyChanged(nameof(DisableChildSubscreenNavigation));
        }
        if (MaxCategoryRecordScore != other.MaxCategoryRecordScore)
        {
            MaxCategoryRecordScore = other.MaxCategoryRecordScore;
            OnPropertyChanged(nameof(MaxCategoryRecordScore));
        }
        if (PresentationNodeType != other.PresentationNodeType)
        {
            PresentationNodeType = other.PresentationNodeType;
            OnPropertyChanged(nameof(PresentationNodeType));
        }
        if (!TraitIds.DeepEqualsListNaive(other.TraitIds))
        {
            TraitIds = other.TraitIds;
            OnPropertyChanged(nameof(TraitIds));
        }
        if (!TraitHashes.DeepEqualsListNaive(other.TraitHashes))
        {
            TraitHashes = other.TraitHashes;
            OnPropertyChanged(nameof(TraitHashes));
        }
        if (!ParentNodeHashes.DeepEqualsListNaive(other.ParentNodeHashes))
        {
            ParentNodeHashes = other.ParentNodeHashes;
            OnPropertyChanged(nameof(ParentNodeHashes));
        }
        if (Hash != other.Hash)
        {
            Hash = other.Hash;
            OnPropertyChanged(nameof(Hash));
        }
        if (Index != other.Index)
        {
            Index = other.Index;
            OnPropertyChanged(nameof(Index));
        }
        if (Redacted != other.Redacted)
        {
            Redacted = other.Redacted;
            OnPropertyChanged(nameof(Redacted));
        }
    }
}