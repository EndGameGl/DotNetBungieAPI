namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinyPlugItemCraftingRequirements
{
    [JsonPropertyName("unlockRequirements")]
    public List<Destiny.Definitions.DestinyPlugItemCraftingUnlockRequirement> UnlockRequirements { get; set; }

    /// <summary>
    ///     If the plug has a known level requirement, it'll be available here.
    /// </summary>
    [JsonPropertyName("requiredLevel")]
    public int RequiredLevel { get; set; }

    [JsonPropertyName("materialRequirementHashes")]
    public List<uint> MaterialRequirementHashes { get; set; }
}
