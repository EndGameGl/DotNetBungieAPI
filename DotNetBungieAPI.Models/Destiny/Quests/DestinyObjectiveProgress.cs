namespace DotNetBungieAPI.Models.Destiny.Quests;

/// <summary>
///     Returns data about a character's status with a given Objective. Combine with DestinyObjectiveDefinition static data for display purposes.
/// </summary>
public sealed class DestinyObjectiveProgress
{
    /// <summary>
    ///     The unique identifier of the Objective being referred to. Use to look up the DestinyObjectiveDefinition in static data.
    /// </summary>
    [JsonPropertyName("objectiveHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyObjectiveDefinition> ObjectiveHash { get; init; }

    /// <summary>
    ///     If the Objective has a Destination associated with it, this is the unique identifier of the Destination being referred to. Use to look up the DestinyDestinationDefinition in static data. This will give localized data about *where* in the universe the objective should be achieved.
    /// </summary>
    [JsonPropertyName("destinationHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyDestinationDefinition> DestinationHash { get; init; }

    /// <summary>
    ///     If the Objective has an Activity associated with it, this is the unique identifier of the Activity being referred to. Use to look up the DestinyActivityDefinition in static data. This will give localized data about *what* you should be playing for the objective to be achieved.
    /// </summary>
    [JsonPropertyName("activityHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyActivityDefinition> ActivityHash { get; init; }

    /// <summary>
    ///     If progress has been made, and the progress can be measured numerically, this will be the value of that progress. You can compare it to the DestinyObjectiveDefinition.completionValue property for current vs. upper bounds, and use DestinyObjectiveDefinition.inProgressValueStyle or completedValueStyle to determine how this should be rendered. Note that progress, in Destiny 2, need not be a literal numeric progression. It could be one of a number of possible values, even a Timestamp. Always examine DestinyObjectiveDefinition.inProgressValueStyle or completedValueStyle before rendering progress.
    /// </summary>
    [JsonPropertyName("progress")]
    public int? Progress { get; init; }

    /// <summary>
    ///     As of Forsaken, objectives' completion value is determined dynamically at runtime.
    /// <para />
    ///     This value represents the threshold of progress you need to surpass in order for this objective to be considered "complete".
    /// <para />
    ///     If you were using objective data, switch from using the DestinyObjectiveDefinition's "completionValue" to this value.
    /// </summary>
    [JsonPropertyName("completionValue")]
    public int CompletionValue { get; init; }

    /// <summary>
    ///     Whether or not the Objective is completed.
    /// </summary>
    [JsonPropertyName("complete")]
    public bool Complete { get; init; }

    /// <summary>
    ///     If this is true, the objective is visible in-game. Otherwise, it's not yet visible to the player. Up to you if you want to honor this property.
    /// </summary>
    [JsonPropertyName("visible")]
    public bool Visible { get; init; }
}
