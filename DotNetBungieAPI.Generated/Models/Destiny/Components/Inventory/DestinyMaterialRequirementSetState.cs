namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Inventory;

public class DestinyMaterialRequirementSetState
{
    /// <summary>
    ///     The hash identifier of the material requirement set. Use it to look up the DestinyMaterialRequirementSetDefinition.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyMaterialRequirementSetDefinition>("Destiny.Definitions.DestinyMaterialRequirementSetDefinition")]
    [JsonPropertyName("materialRequirementSetHash")]
    public uint? MaterialRequirementSetHash { get; set; }

    /// <summary>
    ///     The dynamic state values for individual material requirements.
    /// </summary>
    [JsonPropertyName("materialRequirementStates")]
    public List<Destiny.Components.Inventory.DestinyMaterialRequirementState> MaterialRequirementStates { get; set; }
}
