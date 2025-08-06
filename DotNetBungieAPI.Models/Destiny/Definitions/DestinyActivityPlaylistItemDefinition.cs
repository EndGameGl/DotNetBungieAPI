namespace DotNetBungieAPI.Models.Destiny.Definitions;

/// <summary>
///     If the activity is a playlist, this is the definition for a specific entry in the playlist: a single possible combination of Activity and Activity Mode that can be chosen.
/// </summary>
public sealed class DestinyActivityPlaylistItemDefinition
{
    /// <summary>
    ///     The hash identifier of the Activity that can be played. Use it to look up the DestinyActivityDefinition.
    /// </summary>
    [JsonPropertyName("activityHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyActivityDefinition> ActivityHash { get; init; }

    /// <summary>
    ///     If this playlist entry had an activity mode directly defined on it, this will be the hash of that mode.
    /// </summary>
    [JsonPropertyName("directActivityModeHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyActivityModeDefinition>? DirectActivityModeHash { get; init; }

    /// <summary>
    ///     If the playlist entry had an activity mode directly defined on it, this will be the enum value of that mode.
    /// </summary>
    [JsonPropertyName("directActivityModeType")]
    public Destiny.HistoricalStats.Definitions.DestinyActivityModeType? DirectActivityModeType { get; init; }

    /// <summary>
    ///     The hash identifiers for Activity Modes relevant to this entry.
    /// </summary>
    [JsonPropertyName("activityModeHashes")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyActivityModeDefinition>[]? ActivityModeHashes { get; init; }

    /// <summary>
    ///     The activity modes - if any - in enum form. Because we can't seem to escape the enums.
    /// </summary>
    [JsonPropertyName("activityModeTypes")]
    public Destiny.HistoricalStats.Definitions.DestinyActivityModeType[]? ActivityModeTypes { get; init; }
}
