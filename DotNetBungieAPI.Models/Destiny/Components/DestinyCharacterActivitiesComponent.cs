﻿using DotNetBungieAPI.Models.Destiny.Activities;
using DotNetBungieAPI.Models.Destiny.Definitions.Activities;
using DotNetBungieAPI.Models.Destiny.Definitions.ActivityModes;
using DotNetBungieAPI.Models.Destiny.Definitions.FireteamFinder;

namespace DotNetBungieAPI.Models.Destiny.Components;

/// <summary>
///     This component holds activity data for a character. It will tell you about the character's current activity status,
///     as well as activities that are available to the user.
/// </summary>
public sealed record DestinyCharacterActivitiesComponent
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
    public ReadOnlyCollection<DestinyActivity> AvailableActivities { get; init; } =
        ReadOnlyCollection<DestinyActivity>.Empty;

    /// <summary>
    ///     The list of activity interactables that the player can interact with.
    /// </summary>
    [JsonPropertyName("availableActivityInteractables")]
    public ReadOnlyCollection<DestinyActivityInteractableReference> AvailableActivityInteractables { get; init; } =
        ReadOnlyCollection<DestinyActivityInteractableReference>.Empty;

    /// <summary>
    ///     If the user is in an activity, this will be the hash of the Activity being played. Note that you must combine this
    ///     info with currentActivityModeHash to get a real picture of what the user is doing right now. For instance, PVP
    ///     "Activities" are just maps: it's the ActivityMode that determines what type of PVP game they're playing.
    /// </summary>
    [JsonPropertyName("currentActivityHash")]
    public DefinitionHashPointer<DestinyActivityDefinition> CurrentActivity { get; init; } =
        DefinitionHashPointer<DestinyActivityDefinition>.Empty;

    /// <summary>
    ///     If the user is in an activity, this will be the hash of the activity mode being played. Combine with
    ///     currentActivityHash to give a person a full picture of what they're doing right now.
    /// </summary>
    [JsonPropertyName("currentActivityModeHash")]
    public DefinitionHashPointer<DestinyActivityModeDefinition> CurrentActivityMode { get; init; } =
        DefinitionHashPointer<DestinyActivityModeDefinition>.Empty;

    /// <summary>
    ///     And the current activity's most specific mode type, if it can be found.
    /// </summary>
    [JsonPropertyName("currentActivityModeType")]
    public DestinyActivityModeType? CurrentActivityModeType { get; init; }

    /// <summary>
    ///     If the user is in an activity, this will be the hashes of the DestinyActivityModeDefinition being played. Combine
    ///     with currentActivityHash to give a person a full picture of what they're doing right now.
    /// </summary>
    [JsonPropertyName("currentActivityModeHashes")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinyActivityModeDefinition>
    > CurrentActivityModes { get; init; } =
        ReadOnlyCollection<DefinitionHashPointer<DestinyActivityModeDefinition>>.Empty;

    /// <summary>
    ///     All Activity Modes that apply to the current activity being played, in enum form.
    /// </summary>
    [JsonPropertyName("currentActivityModeTypes")]
    public ReadOnlyCollection<DestinyActivityModeType> CurrentActivityModeTypes { get; init; } =
        ReadOnlyCollection<DestinyActivityModeType>.Empty;

    /// <summary>
    ///     If the user is in a playlist, this is the hash identifier for the playlist that they chose.
    /// </summary>
    [JsonPropertyName("currentPlaylistActivityHash")]
    public DefinitionHashPointer<DestinyActivityDefinition> CurrentPlaylistActivity { get; init; } =
        DefinitionHashPointer<DestinyActivityDefinition>.Empty;

    /// <summary>
    ///     This will have the activity hash of the last completed story/campaign mission, in case you care about that.
    /// </summary>
    [JsonPropertyName("lastCompletedStoryHash")]
    public DefinitionHashPointer<DestinyActivityDefinition> LastCompletedStory { get; init; } =
        DefinitionHashPointer<DestinyActivityDefinition>.Empty;
}
