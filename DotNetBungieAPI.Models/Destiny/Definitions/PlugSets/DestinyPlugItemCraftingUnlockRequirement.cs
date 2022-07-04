namespace DotNetBungieAPI.Models.Destiny.Definitions.PlugSets;

public sealed record DestinyPlugItemCraftingUnlockRequirement : IDeepEquatable<DestinyPlugItemCraftingUnlockRequirement>
{
    [JsonPropertyName("failureDescription")]
    public string FailureDescription { get; init; }

    public bool DeepEquals(DestinyPlugItemCraftingUnlockRequirement other)
    {
        return other is not null &&
               FailureDescription != other.FailureDescription;
    }
}