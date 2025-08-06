namespace DotNetBungieAPI.Models.Destiny.Definitions;

public sealed class DestinyPlugItemCraftingUnlockRequirement
{
    [JsonPropertyName("failureDescription")]
    public string FailureDescription { get; init; }
}
