namespace DotNetBungieAPI.Models.Destiny.Definitions;

public sealed class DestinyPlugItemCraftingRequirements
{
    [JsonPropertyName("unlockRequirements")]
    public Destiny.Definitions.DestinyPlugItemCraftingUnlockRequirement[]? UnlockRequirements { get; init; }

    /// <summary>
    ///     If the plug has a known level requirement, it'll be available here.
    /// </summary>
    [JsonPropertyName("requiredLevel")]
    public int? RequiredLevel { get; init; }

    [JsonPropertyName("materialRequirementHashes")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyMaterialRequirementSetDefinition>[]? MaterialRequirementHashes { get; init; }
}
