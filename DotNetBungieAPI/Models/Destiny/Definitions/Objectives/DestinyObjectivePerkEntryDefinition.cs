using DotNetBungieAPI.Models.Destiny.Definitions.SandboxPerks;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Objectives;

/// <summary>
///     Defines the conditions under which an intrinsic perk is applied while participating in an Objective.
///     <para />
///     These perks will generally not be benefit-granting perks, but rather a perk that modifies gameplay in some
///     interesting way.
/// </summary>
public class DestinyObjectivePerkEntryDefinition : IDeepEquatable<DestinyObjectivePerkEntryDefinition>
{
    /// <summary>
    ///     DestinySandboxPerkDefinition that will be applied to the character.
    /// </summary>
    [JsonPropertyName("perkHash")]
    public DefinitionHashPointer<DestinySandboxPerkDefinition> Perk { get; init; } =
        DefinitionHashPointer<DestinySandboxPerkDefinition>.Empty;

    /// <summary>
    ///     An enumeration indicating whether it will be applied as long as the Objective is active, when it's completed, or
    ///     until it's completed.
    /// </summary>
    [JsonPropertyName("style")]
    public DestinyObjectiveGrantStyle Style { get; init; }

    public bool DeepEquals(DestinyObjectivePerkEntryDefinition other)
    {
        return other != null && Perk.DeepEquals(other.Perk) && Style == other.Style;
    }
}