﻿using DotNetBungieAPI.Models.Destiny.Definitions.ActivityModes;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Activities;

/// <summary>
///     If the activity is a playlist, this is the definition for a specific entry in the playlist: a single possible
///     combination of Activity and Activity Mode that can be chosen.
/// </summary>
public sealed record DestinyActivityPlaylistItemDefinition
    : IDeepEquatable<DestinyActivityPlaylistItemDefinition>
{
    /// <summary>
    ///     DestinyActivityDefinition that can be played.
    /// </summary>
    [JsonPropertyName("activityHash")]
    public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; } =
        DefinitionHashPointer<DestinyActivityDefinition>.Empty;

    /// <summary>
    ///     If this playlist entry had an activity mode directly defined on it, this will be the that mode.
    /// </summary>
    [JsonPropertyName("directActivityModeHash")]
    public DefinitionHashPointer<DestinyActivityModeDefinition> DirectActivityMode { get; init; } =
        DefinitionHashPointer<DestinyActivityModeDefinition>.Empty;

    /// <summary>
    ///     If the playlist entry had an activity mode directly defined on it, this will be the enum value of that mode.
    /// </summary>
    [JsonPropertyName("directActivityModeType")]
    public DestinyActivityModeType? DirectActivityModeType { get; init; }

    /// <summary>
    ///     Activity Modes relevant to this entry.
    /// </summary>
    [JsonPropertyName("activityModeHashes")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinyActivityModeDefinition>
    > ActivityModes { get; init; } =
        ReadOnlyCollection<DefinitionHashPointer<DestinyActivityModeDefinition>>.Empty;

    /// <summary>
    ///     The activity modes - if any - in enum form. Because we can't seem to escape the enums.
    /// </summary>
    [JsonPropertyName("activityModeTypes")]
    public ReadOnlyCollection<DestinyActivityModeType> ActivityModeTypes { get; init; } =
        ReadOnlyCollection<DestinyActivityModeType>.Empty;

    [JsonPropertyName("weight")]
    public int Weight { get; init; }

    public bool DeepEquals(DestinyActivityPlaylistItemDefinition other)
    {
        return other != null
            && Activity.DeepEquals(other.Activity)
            && ActivityModes.DeepEqualsReadOnlyCollection(other.ActivityModes)
            && ActivityModeTypes.DeepEqualsReadOnlySimpleCollection(other.ActivityModeTypes)
            && DirectActivityMode.DeepEquals(other.DirectActivityMode)
            && DirectActivityModeType == other.DirectActivityModeType
            && Weight == other.Weight;
    }
}
