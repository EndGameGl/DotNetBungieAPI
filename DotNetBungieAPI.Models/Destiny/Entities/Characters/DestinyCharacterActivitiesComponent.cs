namespace DotNetBungieAPI.Models.Destiny.Entities.Characters;

/// <summary>
///     This component holds activity data for a character. It will tell you about the character's current activity status, as well as activities that are available to the user.
/// </summary>
public sealed class DestinyCharacterActivitiesComponent
{
    /// <summary>
    ///     The last date that the user started playing an activity.
    /// </summary>
    [JsonPropertyName("dateActivityStarted")]
    public DateTime DateActivityStarted { get; init; }

    /// <summary>
    ///     The list of activities that the user can play.
    /// </summary>
    [JsonPropertyName("availableActivities")]
    public Destiny.DestinyActivity[]? AvailableActivities { get; init; }

    /// <summary>
    ///     The list of activity interactables that the player can interact with.
    /// </summary>
    [JsonPropertyName("availableActivityInteractables")]
    public Destiny.Definitions.FireteamFinder.DestinyActivityInteractableReference[]? AvailableActivityInteractables { get; init; }

    /// <summary>
    ///     If the user is in an activity, this will be the hash of the Activity being played. Note that you must combine this info with currentActivityModeHash to get a real picture of what the user is doing right now. For instance, PVP "Activities" are just maps: it's the ActivityMode that determines what type of PVP game they're playing.
    /// </summary>
    [JsonPropertyName("currentActivityHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyActivityDefinition> CurrentActivityHash { get; init; }

    /// <summary>
    ///     If the user is in an activity, this will be the hash of the activity mode being played. Combine with currentActivityHash to give a person a full picture of what they're doing right now.
    /// </summary>
    [JsonPropertyName("currentActivityModeHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyActivityModeDefinition> CurrentActivityModeHash { get; init; }

    /// <summary>
    ///     And the current activity's most specific mode type, if it can be found.
    /// </summary>
    [JsonPropertyName("currentActivityModeType")]
    public Destiny.HistoricalStats.Definitions.DestinyActivityModeType? CurrentActivityModeType { get; init; }

    /// <summary>
    ///     If the user is in an activity, this will be the hashes of the DestinyActivityModeDefinition being played. Combine with currentActivityHash to give a person a full picture of what they're doing right now.
    /// </summary>
    [JsonPropertyName("currentActivityModeHashes")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyActivityModeDefinition>[]? CurrentActivityModeHashes { get; init; }

    /// <summary>
    ///     All Activity Modes that apply to the current activity being played, in enum form.
    /// </summary>
    [JsonPropertyName("currentActivityModeTypes")]
    public Destiny.HistoricalStats.Definitions.DestinyActivityModeType[]? CurrentActivityModeTypes { get; init; }

    /// <summary>
    ///     If the user is in a playlist, this is the hash identifier for the playlist that they chose.
    /// </summary>
    [JsonPropertyName("currentPlaylistActivityHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyActivityDefinition> CurrentPlaylistActivityHash { get; init; }

    /// <summary>
    ///     This will have the activity hash of the last completed story/campaign mission, in case you care about that.
    /// </summary>
    [JsonPropertyName("lastCompletedStoryHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyActivityDefinition> LastCompletedStoryHash { get; init; }
}
