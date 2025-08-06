namespace DotNetBungieAPI.Models.Destiny.Definitions;

/// <summary>
///     An intrinsic perk on an item, and the requirements for it to be activated.
/// </summary>
public sealed class DestinyItemPerkEntryDefinition
{
    /// <summary>
    ///     If this perk is not active, this is the string to show for why it's not providing its benefits.
    /// </summary>
    [JsonPropertyName("requirementDisplayString")]
    public string RequirementDisplayString { get; init; }

    /// <summary>
    ///     A hash identifier for the DestinySandboxPerkDefinition being provided on the item.
    /// </summary>
    [JsonPropertyName("perkHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinySandboxPerkDefinition> PerkHash { get; init; }

    /// <summary>
    ///     Indicates whether this perk should be shown, or if it should be shown disabled.
    /// </summary>
    [JsonPropertyName("perkVisibility")]
    public Destiny.ItemPerkVisibility PerkVisibility { get; init; }
}
