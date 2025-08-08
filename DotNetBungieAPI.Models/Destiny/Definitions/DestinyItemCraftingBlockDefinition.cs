namespace DotNetBungieAPI.Models.Destiny.Definitions;

/// <summary>
///     If an item can have an action performed on it (like "Dismantle"), it will be defined here if you care.
/// </summary>
public sealed class DestinyItemCraftingBlockDefinition
{
    /// <summary>
    ///     A reference to the item definition that is created when crafting with this 'recipe' item.
    /// </summary>
    [JsonPropertyName("outputItemHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyInventoryItemDefinition> OutputItemHash { get; init; }

    /// <summary>
    ///     A list of socket type hashes that describes which sockets are required for crafting with this recipe.
    /// </summary>
    [JsonPropertyName("requiredSocketTypeHashes")]
    public DefinitionHashPointer<Destiny.Definitions.Sockets.DestinySocketTypeDefinition>[]? RequiredSocketTypeHashes { get; init; }

    [JsonPropertyName("failedRequirementStrings")]
    public string[]? FailedRequirementStrings { get; init; }

    /// <summary>
    ///     A reference to the base material requirements for crafting with this recipe.
    /// </summary>
    [JsonPropertyName("baseMaterialRequirements")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyMaterialRequirementSetDefinition> BaseMaterialRequirements { get; init; }

    /// <summary>
    ///     A list of 'bonus' socket plugs that may be available if certain requirements are met.
    /// </summary>
    [JsonPropertyName("bonusPlugs")]
    public Destiny.Definitions.DestinyItemCraftingBlockBonusPlugDefinition[]? BonusPlugs { get; init; }
}
