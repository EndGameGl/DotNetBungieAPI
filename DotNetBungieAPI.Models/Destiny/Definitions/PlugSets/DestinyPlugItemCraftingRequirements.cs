using DotNetBungieAPI.Models.Destiny.Definitions.MaterialRequirementSets;

namespace DotNetBungieAPI.Models.Destiny.Definitions.PlugSets;

public sealed record DestinyPlugItemCraftingRequirements
    : IDeepEquatable<DestinyPlugItemCraftingRequirements>
{
    [JsonPropertyName("unlockRequirements")]
    public ReadOnlyCollection<DestinyPlugItemCraftingUnlockRequirement> UnlockRequirements { get; init; } =
        ReadOnlyCollections<DestinyPlugItemCraftingUnlockRequirement>.Empty;

    [JsonPropertyName("materialRequirementHashes")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinyMaterialRequirementSetDefinition>
    > MaterialRequirements { get; init; } =
        ReadOnlyCollections<DefinitionHashPointer<DestinyMaterialRequirementSetDefinition>>.Empty;

    public bool DeepEquals(DestinyPlugItemCraftingRequirements other)
    {
        return other is not null
            && UnlockRequirements.DeepEqualsReadOnlyCollections(other.UnlockRequirements)
            && MaterialRequirements.DeepEqualsReadOnlyCollections(other.MaterialRequirements);
    }
}
