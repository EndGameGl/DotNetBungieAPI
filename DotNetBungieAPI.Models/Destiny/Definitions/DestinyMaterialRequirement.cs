using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;

namespace DotNetBungieAPI.Models.Destiny.Definitions;

/// <summary>
///     Many actions relating to items require you to expend materials: - Activating a talent node - Inserting a plug into
///     a socket The items will refer to material requirements by a materialRequirementsHash in these cases, and this is
///     the definition for those requirements in terms of the item required, how much of it is required and other
///     interesting info. This is one of the rare/strange times where a single contract class is used both in definitions
///     *and* in live data response contracts. I'm not sure yet whether I regret that
/// </summary>
public sealed record DestinyMaterialRequirement : IDeepEquatable<DestinyMaterialRequirement>
{
    /// <summary>
    ///     The amount of the material required.
    /// </summary>
    [JsonPropertyName("count")]
    public int Count { get; init; }

    /// <summary>
    ///     If True, the material will be removed from the character's inventory when the action is performed.
    /// </summary>
    [JsonPropertyName("deleteOnAction")]
    public bool DeleteOnAction { get; init; }

    /// <summary>
    ///     The material required
    /// </summary>
    [JsonPropertyName("itemHash")]
    public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; init; }

    /// <summary>
    ///     If true, the material requirement count value is constant. Since The Witch Queen expansion, some material requirement counts can be dynamic and will need to be returned with an API call.
    /// </summary>
    [JsonPropertyName("countIsConstant")]
    public bool CountIsConstant { get; init; }

    /// <summary>
    ///     If True, this requirement is "silent": don't bother showing it in a material requirements display. I mean, I'm not
    ///     your mom: I'm not going to tell you you *can't* show it. But we won't show it in our UI.
    /// </summary>
    [JsonPropertyName("omitFromRequirements")]
    public bool OmitFromRequirements { get; init; }

    public bool DeepEquals(DestinyMaterialRequirement other)
    {
        return other != null
            && Count == other.Count
            && DeleteOnAction == other.DeleteOnAction
            && Item.DeepEquals(other.Item)
            && OmitFromRequirements == other.OmitFromRequirements
            && CountIsConstant == other.CountIsConstant;
    }
}
