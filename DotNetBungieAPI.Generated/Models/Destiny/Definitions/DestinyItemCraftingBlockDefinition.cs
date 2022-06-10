namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     If an item can have an action performed on it (like "Dismantle"), it will be defined here if you care.
/// </summary>
public class DestinyItemCraftingBlockDefinition
{
    /// <summary>
    ///     A reference to the item definition that is created when crafting with this 'recipe' item.
    /// </summary>
    [JsonPropertyName("outputItemHash")]
    public uint? OutputItemHash { get; set; }

    /// <summary>
    ///     A list of socket type hashes that describes which sockets are required for crafting with this recipe.
    /// </summary>
    [JsonPropertyName("requiredSocketTypeHashes")]
    public List<uint> RequiredSocketTypeHashes { get; set; }

    [JsonPropertyName("failedRequirementStrings")]
    public List<string> FailedRequirementStrings { get; set; }

    /// <summary>
    ///     A reference to the base material requirements for crafting with this recipe.
    /// </summary>
    [JsonPropertyName("baseMaterialRequirements")]
    public uint? BaseMaterialRequirements { get; set; }

    /// <summary>
    ///     A list of 'bonus' socket plugs that may be available if certain requirements are met.
    /// </summary>
    [JsonPropertyName("bonusPlugs")]
    public List<Destiny.Definitions.DestinyItemCraftingBlockBonusPlugDefinition> BonusPlugs { get; set; }
}
