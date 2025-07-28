namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Represents a reference to a Challenge, which for now is just an Objective.
/// </summary>
public class DestinyActivityChallengeDefinition
{
    /// <summary>
    ///     The hash for the Objective that matches this challenge. Use it to look up the DestinyObjectiveDefinition.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyObjectiveDefinition>("Destiny.Definitions.DestinyObjectiveDefinition")]
    [JsonPropertyName("objectiveHash")]
    public uint ObjectiveHash { get; set; }

    /// <summary>
    ///     The rewards as they're represented in the UI. Note that they generally link to "dummy" items that give a summary of rewards rather than direct, real items themselves.
    /// <para />
    ///     If the quantity is 0, don't show the quantity.
    /// </summary>
    [JsonPropertyName("dummyRewards")]
    public Destiny.DestinyItemQuantity[]? DummyRewards { get; set; }
}
