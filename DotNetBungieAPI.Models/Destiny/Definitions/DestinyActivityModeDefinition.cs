namespace DotNetBungieAPI.Models.Destiny.Definitions;

/// <summary>
///     This definition represents an "Activity Mode" as it exists in the Historical Stats endpoints. An individual Activity Mode represents a collection of activities that are played in a certain way. For example, Nightfall Strikes are part of a "Nightfall" activity mode, and any activities played as the PVP mode "Clash" are part of the "Clash activity mode.
/// <para />
///     Activity modes are nested under each other in a hierarchy, so that if you ask for - for example - "AllPvP", you will get any PVP activities that the user has played, regardless of what specific PVP mode was being played.
/// </summary>
[DestinyDefinition(DefinitionsEnum.DestinyActivityModeDefinition)]
public sealed class DestinyActivityModeDefinition : IDestinyDefinition, IDisplayProperties
{
    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyActivityModeDefinition;

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; init; }

    /// <summary>
    ///     If this activity mode has a related PGCR image, this will be the path to said image.
    /// </summary>
    [JsonPropertyName("pgcrImage")]
    public string PgcrImage { get; init; }

    /// <summary>
    ///     The Enumeration value for this Activity Mode. Pass this identifier into Stats endpoints to get aggregate stats for this mode.
    /// </summary>
    [JsonPropertyName("modeType")]
    public Destiny.HistoricalStats.Definitions.DestinyActivityModeType ModeType { get; init; }

    /// <summary>
    ///     The type of play being performed in broad terms (PVP, PVE)
    /// </summary>
    [JsonPropertyName("activityModeCategory")]
    public Destiny.DestinyActivityModeCategory ActivityModeCategory { get; init; }

    /// <summary>
    ///     If True, this mode has oppositional teams fighting against each other rather than "Free-For-All" or Co-operative modes of play.
    /// <para />
    ///     Note that Aggregate modes are never marked as team based, even if they happen to be team based at the moment. At any time, an aggregate whose subordinates are only team based could be changed so that one or more aren't team based, and then this boolean won't make much sense (the aggregation would become "sometimes team based"). Let's not deal with that right now.
    /// </summary>
    [JsonPropertyName("isTeamBased")]
    public bool IsTeamBased { get; init; }

    /// <summary>
    ///     If true, this mode is an aggregation of other, more specific modes rather than being a mode in itself. This includes modes that group Features/Events rather than Gameplay, such as Trials of The Nine: Trials of the Nine being an Event that is interesting to see aggregate data for, but when you play the activities within Trials of the Nine they are more specific activity modes such as Clash.
    /// </summary>
    [JsonPropertyName("isAggregateMode")]
    public bool IsAggregateMode { get; init; }

    /// <summary>
    ///     The hash identifiers of the DestinyActivityModeDefinitions that represent all of the "parent" modes for this mode. For instance, the Nightfall Mode is also a member of AllStrikes and AllPvE.
    /// </summary>
    [JsonPropertyName("parentHashes")]
    public uint[]? ParentHashes { get; init; }

    /// <summary>
    ///     A Friendly identifier you can use for referring to this Activity Mode. We really only used this in our URLs, so... you know, take that for whatever it's worth.
    /// </summary>
    [JsonPropertyName("friendlyName")]
    public string FriendlyName { get; init; }

    /// <summary>
    ///     If this exists, the mode has specific Activities (referred to by the Key) that should instead map to other Activity Modes when they are played. This was useful in D1 for Private Matches, where we wanted to have Private Matches as an activity mode while still referring to the specific mode being played.
    /// </summary>
    [JsonPropertyName("activityModeMappings")]
    public Dictionary<uint, Destiny.HistoricalStats.Definitions.DestinyActivityModeType>? ActivityModeMappings { get; init; }

    /// <summary>
    ///     If FALSE, we want to ignore this type when we're showing activity modes in BNet UI. It will still be returned in case 3rd parties want to use it for any purpose.
    /// </summary>
    [JsonPropertyName("display")]
    public bool Display { get; init; }

    /// <summary>
    ///     The relative ordering of activity modes.
    /// </summary>
    [JsonPropertyName("order")]
    public int Order { get; init; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; init; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
