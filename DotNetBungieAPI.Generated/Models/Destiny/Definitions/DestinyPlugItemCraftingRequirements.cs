namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinyPlugItemCraftingRequirements
{
    [JsonPropertyName("unlockRequirements")]
    public Destiny.Definitions.DestinyPlugItemCraftingUnlockRequirement[]? UnlockRequirements { get; set; }

    /// <summary>
    ///     If the plug has a known level requirement, it'll be available here.
    /// </summary>
    [JsonPropertyName("requiredLevel")]
    public int? RequiredLevel { get; set; }

    [Destiny2Definition<Destiny.Definitions.DestinyMaterialRequirementSetDefinition>("Destiny.Definitions.DestinyMaterialRequirementSetDefinition")]
    [JsonPropertyName("materialRequirementHashes")]
    public uint[]? MaterialRequirementHashes { get; set; }
}
