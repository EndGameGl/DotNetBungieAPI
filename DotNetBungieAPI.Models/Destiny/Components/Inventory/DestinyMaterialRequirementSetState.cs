namespace DotNetBungieAPI.Models.Destiny.Components.Inventory;

public sealed class DestinyMaterialRequirementSetState
{
    /// <summary>
    ///     The hash identifier of the material requirement set. Use it to look up the DestinyMaterialRequirementSetDefinition.
    /// </summary>
    [JsonPropertyName("materialRequirementSetHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyMaterialRequirementSetDefinition> MaterialRequirementSetHash { get; init; }

    /// <summary>
    ///     The dynamic state values for individual material requirements.
    /// </summary>
    [JsonPropertyName("materialRequirementStates")]
    public Destiny.Components.Inventory.DestinyMaterialRequirementState[]? MaterialRequirementStates { get; init; }
}
