namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Characters;

/// <summary>
///     This component holds activity data for a character. It will tell you about the character's current activity status, as well as activities that are available to the user.
/// </summary>
public class DestinyCharacterActivitiesComponent : IDeepEquatable<DestinyCharacterActivitiesComponent>
{
    /// <summary>
    ///     The last date that the user started playing an activity.
    /// </summary>
    [JsonPropertyName("dateActivityStarted")]
    public DateTime DateActivityStarted { get; set; }

    /// <summary>
    ///     The list of activities that the user can play.
    /// </summary>
    [JsonPropertyName("availableActivities")]
    public List<Destiny.DestinyActivity> AvailableActivities { get; set; }

    /// <summary>
    ///     If the user is in an activity, this will be the hash of the Activity being played. Note that you must combine this info with currentActivityModeHash to get a real picture of what the user is doing right now. For instance, PVP "Activities" are just maps: it's the ActivityMode that determines what type of PVP game they're playing.
    /// </summary>
    [JsonPropertyName("currentActivityHash")]
    public uint CurrentActivityHash { get; set; }

    /// <summary>
    ///     If the user is in an activity, this will be the hash of the activity mode being played. Combine with currentActivityHash to give a person a full picture of what they're doing right now.
    /// </summary>
    [JsonPropertyName("currentActivityModeHash")]
    public uint CurrentActivityModeHash { get; set; }

    /// <summary>
    ///     And the current activity's most specific mode type, if it can be found.
    /// </summary>
    [JsonPropertyName("currentActivityModeType")]
    public int? CurrentActivityModeType { get; set; }

    /// <summary>
    ///     If the user is in an activity, this will be the hashes of the DestinyActivityModeDefinition being played. Combine with currentActivityHash to give a person a full picture of what they're doing right now.
    /// </summary>
    [JsonPropertyName("currentActivityModeHashes")]
    public List<uint> CurrentActivityModeHashes { get; set; }

    /// <summary>
    ///     All Activity Modes that apply to the current activity being played, in enum form.
    /// </summary>
    [JsonPropertyName("currentActivityModeTypes")]
    public List<Destiny.HistoricalStats.Definitions.DestinyActivityModeType> CurrentActivityModeTypes { get; set; }

    /// <summary>
    ///     If the user is in a playlist, this is the hash identifier for the playlist that they chose.
    /// </summary>
    [JsonPropertyName("currentPlaylistActivityHash")]
    public uint? CurrentPlaylistActivityHash { get; set; }

    /// <summary>
    ///     This will have the activity hash of the last completed story/campaign mission, in case you care about that.
    /// </summary>
    [JsonPropertyName("lastCompletedStoryHash")]
    public uint LastCompletedStoryHash { get; set; }

    public bool DeepEquals(DestinyCharacterActivitiesComponent? other)
    {
        return other is not null &&
               DateActivityStarted == other.DateActivityStarted &&
               AvailableActivities.DeepEqualsList(other.AvailableActivities) &&
               CurrentActivityHash == other.CurrentActivityHash &&
               CurrentActivityModeHash == other.CurrentActivityModeHash &&
               CurrentActivityModeType == other.CurrentActivityModeType &&
               CurrentActivityModeHashes.DeepEqualsListNaive(other.CurrentActivityModeHashes) &&
               CurrentActivityModeTypes.DeepEqualsListNaive(other.CurrentActivityModeTypes) &&
               CurrentPlaylistActivityHash == other.CurrentPlaylistActivityHash &&
               LastCompletedStoryHash == other.LastCompletedStoryHash;
    }
}