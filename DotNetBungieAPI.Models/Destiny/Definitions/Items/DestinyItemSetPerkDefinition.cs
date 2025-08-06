namespace DotNetBungieAPI.Models.Destiny.Definitions.Items;

public sealed class DestinyItemSetPerkDefinition
{
    /// <summary>
    ///     The number of set pieces required to activate the perk.
    /// </summary>
    [JsonPropertyName("requiredSetCount")]
    public int RequiredSetCount { get; init; }

    /// <summary>
    ///     The perk this set confers.
    /// </summary>
    [JsonPropertyName("sandboxPerkHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinySandboxPerkDefinition> SandboxPerkHash { get; init; }
}
