namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     If the activity is a playlist, this is the definition for a specific entry in the playlist: a single possible combination of Activity and Activity Mode that can be chosen.
/// </summary>
public class DestinyActivityPlaylistItemDefinition
{
    /// <summary>
    ///     The hash identifier of the Activity that can be played. Use it to look up the DestinyActivityDefinition.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyActivityDefinition>("Destiny.Definitions.DestinyActivityDefinition")]
    [JsonPropertyName("activityHash")]
    public uint? ActivityHash { get; set; }

    /// <summary>
    ///     If this playlist entry had an activity mode directly defined on it, this will be the hash of that mode.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyActivityModeDefinition>("Destiny.Definitions.DestinyActivityModeDefinition")]
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
    [Destiny2DefinitionList<Destiny.Definitions.DestinyActivityModeDefinition>("Destiny.Definitions.DestinyActivityModeDefinition")]
    [JsonPropertyName("activityModeHashes")]
    public List<uint> ActivityModeHashes { get; set; }

    /// <summary>
    ///     The activity modes - if any - in enum form. Because we can't seem to escape the enums.
    /// </summary>
    [JsonPropertyName("activityModeTypes")]
    public List<Destiny.HistoricalStats.Definitions.DestinyActivityModeType> ActivityModeTypes { get; set; }
}
