using DotNetBungieAPI.Models.Destiny.Definitions.MaterialRequirementSets;
using DotNetBungieAPI.Models.Destiny.Definitions.SocketTypes;

namespace DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;

public sealed record DestinyItemCraftingBlockDefinition : IDeepEquatable<DestinyItemCraftingBlockDefinition>
{
    /// <summary>
    ///     A reference to the item definition that is created when crafting with this 'recipe' item.
    /// </summary>
    [JsonPropertyName("outputItemHash")]
    public DefinitionHashPointer<DestinyInventoryItemDefinition> OutputItem { get; init; }
        = DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

    /// <summary>
    ///     A list of socket type hashes that describes which sockets are required for crafting with this recipe.
    /// </summary>
    [JsonPropertyName("requiredSocketTypeHashes")]
    public ReadOnlyCollection<DefinitionHashPointer<DestinySocketTypeDefinition>> RequiredSocketTypes { get; init; }
        = ReadOnlyCollections<DefinitionHashPointer<DestinySocketTypeDefinition>>.Empty;

    [JsonPropertyName("failedRequirementStrings")]
    public ReadOnlyCollection<string> FailedRequirementStrings { get; init; } = ReadOnlyCollections<string>.Empty;

    /// <summary>
    ///     A reference to the base material requirements for crafting with this recipe.
    /// </summary>
    [JsonPropertyName("baseMaterialRequirements")]
    public DefinitionHashPointer<DestinyMaterialRequirementSetDefinition> BaseMaterialRequirements { get; init; }
        = DefinitionHashPointer<DestinyMaterialRequirementSetDefinition>.Empty;

    /// <summary>
    ///     A list of 'bonus' socket plugs that may be available if certain requirements are met.
    /// </summary>
    [JsonPropertyName("bonusPlugs")]
    public ReadOnlyCollection<DestinyItemCraftingBlockBonusPlugDefinition> BonusPlugs { get; init; }
        = ReadOnlyCollections<DestinyItemCraftingBlockBonusPlugDefinition>.Empty;

    public bool DeepEquals(DestinyItemCraftingBlockDefinition other)
    {
        return other is not null &&
               OutputItem.DeepEquals(other.OutputItem) &&
               RequiredSocketTypes.DeepEqualsReadOnlyCollections(other.RequiredSocketTypes) &&
               FailedRequirementStrings.DeepEqualsReadOnlySimpleCollection(other.FailedRequirementStrings) &&
               BaseMaterialRequirements.DeepEquals(other.BaseMaterialRequirements) &&
               BonusPlugs.DeepEqualsReadOnlyCollections(other.BonusPlugs);
    }
}