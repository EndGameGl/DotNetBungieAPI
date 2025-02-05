using DotNetBungieAPI.Models.Destiny.Definitions.MaterialRequirementSets;

namespace DotNetBungieAPI.Models.Destiny.Inventory;

public sealed record DestinyMaterialRequirementSetState
{
    /// <summary>
    ///     The hash identifier of the material requirement set.
    /// </summary>
    [JsonPropertyName("materialRequirementSetHash")]
    public DefinitionHashPointer<DestinyMaterialRequirementSetDefinition> MaterialRequirementSet { get; init; } =
        DefinitionHashPointer<DestinyMaterialRequirementSetDefinition>.Empty;

    /// <summary>
    ///     The dynamic state values for individual material requirements.
    /// </summary>
    [JsonPropertyName("materialRequirementStates")]
    public ReadOnlyCollection<DestinyMaterialRequirementState> MaterialRequirementStates { get; init; } =
        ReadOnlyCollection<DestinyMaterialRequirementState>.Empty;
}
