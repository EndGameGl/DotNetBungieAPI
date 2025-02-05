using DotNetBungieAPI.Models.Destiny.Definitions.MaterialRequirementSets;

namespace DotNetBungieAPI.Models.Destiny.Definitions.PlugSets;

public sealed record DestinyPlugItemCraftingRequirements
    : IDeepEquatable<DestinyPlugItemCraftingRequirements>
{
    [JsonPropertyName("unlockRequirements")]
    public ReadOnlyCollection<DestinyPlugItemCraftingUnlockRequirement> UnlockRequirements { get; init; } =
        ReadOnlyCollection<DestinyPlugItemCraftingUnlockRequirement>.Empty;

    [JsonPropertyName("materialRequirementHashes")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinyMaterialRequirementSetDefinition>
    > MaterialRequirements { get; init; } =
        ReadOnlyCollection<DefinitionHashPointer<DestinyMaterialRequirementSetDefinition>>.Empty;

    public bool DeepEquals(DestinyPlugItemCraftingRequirements other)
    {
        return other is not null
            && UnlockRequirements.DeepEqualsReadOnlyCollection(other.UnlockRequirements)
            && MaterialRequirements.DeepEqualsReadOnlyCollection(other.MaterialRequirements);
    }
}
