namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     An intrinsic perk on an item, and the requirements for it to be activated.
/// </summary>
public class DestinyItemPerkEntryDefinition
{
    /// <summary>
    ///     If this perk is not active, this is the string to show for why it's not providing its benefits.
    /// </summary>
    [JsonPropertyName("requirementDisplayString")]
    public string RequirementDisplayString { get; set; }

    /// <summary>
    ///     A hash identifier for the DestinySandboxPerkDefinition being provided on the item.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinySandboxPerkDefinition>("Destiny.Definitions.DestinySandboxPerkDefinition")]
    [JsonPropertyName("perkHash")]
    public uint PerkHash { get; set; }

    /// <summary>
    ///     Indicates whether this perk should be shown, or if it should be shown disabled.
    /// </summary>
    [JsonPropertyName("perkVisibility")]
    public Destiny.ItemPerkVisibility PerkVisibility { get; set; }
}
