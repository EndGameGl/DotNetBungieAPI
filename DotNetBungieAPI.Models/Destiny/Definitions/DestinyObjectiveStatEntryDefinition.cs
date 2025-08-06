namespace DotNetBungieAPI.Models.Destiny.Definitions;

/// <summary>
///     Defines the conditions under which stat modifications will be applied to a Character while participating in an objective.
/// </summary>
public sealed class DestinyObjectiveStatEntryDefinition
{
    /// <summary>
    ///     The stat being modified, and the value used.
    /// </summary>
    [JsonPropertyName("stat")]
    public Destiny.Definitions.DestinyItemInvestmentStatDefinition? Stat { get; init; }

    /// <summary>
    ///     Whether it will be applied as long as the objective is active, when it's completed, or until it's completed.
    /// </summary>
    [JsonPropertyName("style")]
    public Destiny.DestinyObjectiveGrantStyle Style { get; init; }
}
