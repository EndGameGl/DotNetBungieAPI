namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Items;

/// <summary>
///     Well, we're here in Destiny 2, and Talent Grids are unfortunately still around.
/// <para />
///     The good news is that they're pretty much only being used for certain base information on items and for Builds/Subclasses. The bad news is that they still suck. If you really want this information, grab this component.
/// <para />
///     An important note is that talent grids are defined as such:
/// <para />
///     A Grid has 1:M Nodes, which has 1:M Steps.
/// <para />
///     Any given node can only have a single step active at one time, which represents the actual visual contents and effects of the Node (for instance, if you see a "Super Cool Bonus" node, the actual icon and text for the node is coming from the current Step of that node).
/// <para />
///     Nodes can be grouped into exclusivity sets *and* as of D2, exclusivity groups (which are collections of exclusivity sets that affect each other).
/// <para />
///     See DestinyTalentGridDefinition for more information. Brace yourself, the water's cold out there in the deep end.
/// </summary>
public class DestinyItemTalentGridComponent : IDeepEquatable<DestinyItemTalentGridComponent>
{
    /// <summary>
    ///     Most items don't have useful talent grids anymore, but Builds in particular still do.
    /// <para />
    ///     You can use this hash to lookup the DestinyTalentGridDefinition attached to this item, which will be crucial for understanding the node values on the item.
    /// </summary>
    [JsonPropertyName("talentGridHash")]
    public uint TalentGridHash { get; set; }

    /// <summary>
    ///     Detailed information about the individual nodes in the talent grid.
    /// <para />
    ///     A node represents a single visual "pip" in the talent grid or Build detail view, though each node may have multiple "steps" which indicate the actual bonuses and visual representation of that node.
    /// </summary>
    [JsonPropertyName("nodes")]
    public List<Destiny.DestinyTalentNode> Nodes { get; set; }

    /// <summary>
    ///     Indicates whether the talent grid on this item is completed, and thus whether it should have a gold border around it.
    /// <para />
    ///     Only will be true if the item actually *has* a talent grid, and only then if it is completed (i.e. every exclusive set has an activated node, and every non-exclusive set node has been activated)
    /// </summary>
    [JsonPropertyName("isGridComplete")]
    public bool IsGridComplete { get; set; }

    /// <summary>
    ///     If the item has a progression, it will be detailed here. A progression means that the item can gain experience. Thresholds of experience are what determines whether and when a talent node can be activated.
    /// </summary>
    [JsonPropertyName("gridProgression")]
    public Destiny.DestinyProgression GridProgression { get; set; }

    public bool DeepEquals(DestinyItemTalentGridComponent? other)
    {
        return other is not null &&
               TalentGridHash == other.TalentGridHash &&
               Nodes.DeepEqualsList(other.Nodes) &&
               IsGridComplete == other.IsGridComplete &&
               (GridProgression is not null ? GridProgression.DeepEquals(other.GridProgression) : other.GridProgression is null);
    }
}