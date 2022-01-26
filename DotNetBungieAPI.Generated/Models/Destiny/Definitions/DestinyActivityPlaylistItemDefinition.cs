namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     If the activity is a playlist, this is the definition for a specific entry in the playlist: a single possible combination of Activity and Activity Mode that can be chosen.
/// </summary>
public class DestinyActivityPlaylistItemDefinition : IDeepEquatable<DestinyActivityPlaylistItemDefinition>
{
    /// <summary>
    ///     The hash identifier of the Activity that can be played. Use it to look up the DestinyActivityDefinition.
    /// </summary>
    [JsonPropertyName("activityHash")]
    public uint ActivityHash { get; set; }

    /// <summary>
    ///     If this playlist entry had an activity mode directly defined on it, this will be the hash of that mode.
    /// </summary>
    [JsonPropertyName("directActivityModeHash")]
    public uint? DirectActivityModeHash { get; set; }

    /// <summary>
    ///     If the playlist entry had an activity mode directly defined on it, this will be the enum value of that mode.
    /// </summary>
    [JsonPropertyName("directActivityModeType")]
    public int? DirectActivityModeType { get; set; }

    /// <summary>
    ///     The hash identifiers for Activity Modes relevant to this entry.
    /// </summary>
    [JsonPropertyName("activityModeHashes")]
    public List<uint> ActivityModeHashes { get; set; }

    /// <summary>
    ///     The activity modes - if any - in enum form. Because we can't seem to escape the enums.
    /// </summary>
    [JsonPropertyName("activityModeTypes")]
    public List<Destiny.HistoricalStats.Definitions.DestinyActivityModeType> ActivityModeTypes { get; set; }

    public bool DeepEquals(DestinyActivityPlaylistItemDefinition? other)
    {
        return other is not null &&
               ActivityHash == other.ActivityHash &&
               DirectActivityModeHash == other.DirectActivityModeHash &&
               DirectActivityModeType == other.DirectActivityModeType &&
               ActivityModeHashes.DeepEqualsListNaive(other.ActivityModeHashes) &&
               ActivityModeTypes.DeepEqualsListNaive(other.ActivityModeTypes);
    }
}