namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Items;

public class DestinyItemSetPerkDefinition
{
    /// <summary>
    ///     The number of set pieces required to activate the perk.
    /// </summary>
    [JsonPropertyName("requiredSetCount")]
    public int? RequiredSetCount { get; set; }

    /// <summary>
    ///     The perk this set confers.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinySandboxPerkDefinition>("Destiny.Definitions.DestinySandboxPerkDefinition")]
    [JsonPropertyName("sandboxPerkHash")]
    public uint? SandboxPerkHash { get; set; }
}
