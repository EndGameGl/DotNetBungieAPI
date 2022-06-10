namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Defines the conditions under which an intrinsic perk is applied while participating in an Objective.
/// <para />
///     These perks will generally not be benefit-granting perks, but rather a perk that modifies gameplay in some interesting way.
/// </summary>
public class DestinyObjectivePerkEntryDefinition
{
    /// <summary>
    ///     The hash identifier of the DestinySandboxPerkDefinition that will be applied to the character.
    /// </summary>
    [JsonPropertyName("perkHash")]
    public uint? PerkHash { get; set; }

    /// <summary>
    ///     An enumeration indicating whether it will be applied as long as the Objective is active, when it's completed, or until it's completed.
    /// </summary>
    [JsonPropertyName("style")]
    public Destiny.DestinyObjectiveGrantStyle? Style { get; set; }
}
