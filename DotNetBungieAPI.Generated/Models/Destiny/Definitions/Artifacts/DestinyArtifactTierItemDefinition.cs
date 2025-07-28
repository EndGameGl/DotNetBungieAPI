namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Artifacts;

public class DestinyArtifactTierItemDefinition
{
    /// <summary>
    ///     The identifier of the Plug Item unlocked by activating this item in the Artifact.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyInventoryItemDefinition>("Destiny.Definitions.DestinyInventoryItemDefinition")]
    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; set; }
}
