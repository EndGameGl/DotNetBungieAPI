using DotNetBungieAPI.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Activities;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;

namespace DotNetBungieAPI.Models.Destiny.Definitions.ActivityModes;

/// <summary>
///     This definition represents an "Activity Mode" as it exists in the Historical Stats endpoints. An individual
///     Activity Mode represents a collection of activities that are played in a certain way. For example, Nightfall
///     Strikes are part of a "Nightfall" activity mode, and any activities played as the PVP mode "Clash" are part of the
///     "Clash activity mode.
///     <para />
///     Activity modes are nested under each other in a hierarchy, so that if you ask for - for example - "AllPvP", you
///     will get any PVP activities that the user has played, regardless of what specific PVP mode was being played.
/// </summary>
[DestinyDefinition(DefinitionsEnum.DestinyActivityModeDefinition)]
public sealed record DestinyActivityModeDefinition : IDestinyDefinition,
    IDeepEquatable<DestinyActivityModeDefinition>
{
    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    /// <summary>
    ///     If this activity mode has a related PGCR image, this will be the path to said image.
    /// </summary>
    [JsonPropertyName("pgcrImage")]
    public BungieNetResource PgcrImage { get; init; }

    /// <summary>
    ///     The Enumeration value for this Activity Mode. Pass this identifier into Stats endpoints to get aggregate stats for
    ///     this mode.
    /// </summary>
    [JsonPropertyName("modeType")]
    public DestinyActivityModeType ModeType { get; init; }

    /// <summary>
    ///     The type of play being performed in broad terms (PVP, PVE)
    /// </summary>
    [JsonPropertyName("activityModeCategory")]
    public DestinyActivityModeCategory ActivityModeCategory { get; init; }

    /// <summary>
    ///     If True, this mode has oppositional teams fighting against each other rather than "Free-For-All" or Co-operative
    ///     modes of play.
    ///     <para />
    ///     Note that Aggregate modes are never marked as team based, even if they happen to be team based at the moment.At any
    ///     time, an aggregate whose subordinates are only team based could be changed so that one or more aren't team based,
    ///     and then this boolean won't make much sense(the aggregation would become "sometimes team based"). Let's not deal
    ///     with that right now.
    /// </summary>
    [JsonPropertyName("isTeamBased")]
    public bool IsTeamBased { get; init; }

    /// <summary>
    ///     If true, this mode is an aggregation of other, more specific modes rather than being a mode in itself. This
    ///     includes modes that group Features/Events rather than Gameplay, such as Trials of The Nine: Trials of the Nine
    ///     being an Event that is interesting to see aggregate data for, but when you play the activities within Trials of the
    ///     Nine they are more specific activity modes such as Clash.
    /// </summary>
    [JsonPropertyName("isAggregateMode")]
    public bool IsAggregateMode { get; init; }

    /// <summary>
    ///     DestinyActivityModeDefinitions that represent all of the "parent" modes for this mode. For instance, the Nightfall
    ///     Mode is also a member of AllStrikes and AllPvE.
    /// </summary>
    [JsonPropertyName("parentHashes")]
    public ReadOnlyCollection<DefinitionHashPointer<DestinyActivityModeDefinition>> ParentModes { get; init; } =
        ReadOnlyCollections<DefinitionHashPointer<DestinyActivityModeDefinition>>.Empty;

    /// <summary>
    ///     A Friendly identifier you can use for referring to this Activity Mode. We really only used this in our URLs, so...
    ///     you know, take that for whatever it's worth.
    /// </summary>
    [JsonPropertyName("friendlyName")]
    public string FriendlyName { get; init; }

    /// <summary>
    ///     If this exists, the mode has specific Activities (referred to by the Key) that should instead map to other Activity
    ///     Modes when they are played.
    /// </summary>
    [JsonPropertyName("activityModeMappings")]
    public ReadOnlyDictionary<DefinitionHashPointer<DestinyActivityDefinition>, DestinyActivityModeType>
        ActivityModeMappings { get; init; } =
        ReadOnlyDictionaries<DefinitionHashPointer<DestinyActivityDefinition>, DestinyActivityModeType>.Empty;

    /// <summary>
    ///     If FALSE, we want to ignore this type when we're showing activity modes in BNet UI. It will still be returned in
    ///     case 3rd parties want to use it for any purpose.
    /// </summary>
    [JsonPropertyName("display")]
    public bool Display { get; init; }

    /// <summary>
    ///     The relative ordering of activity modes.
    /// </summary>
    [JsonPropertyName("order")]
    public int Order { get; init; }

    [JsonPropertyName("supportsFeedFiltering")]
    public bool SupportsFeedFiltering { get; init; }

    [JsonPropertyName("tier")] public int Tier { get; init; }

    public bool DeepEquals(DestinyActivityModeDefinition other)
    {
        return other != null &&
               ActivityModeCategory == other.ActivityModeCategory &&
               ActivityModeMappings.DeepEqualsReadOnlyDictionaryWithDefinitionKeyAndSimpleValue(
                   other.ActivityModeMappings) &&
               Display == other.Display &&
               DisplayProperties.DeepEquals(other.DisplayProperties) &&
               FriendlyName == other.FriendlyName &&
               IsAggregateMode == other.IsAggregateMode &&
               IsTeamBased == other.IsTeamBased &&
               ModeType == other.ModeType &&
               Order == other.Order &&
               ParentModes.DeepEqualsReadOnlyCollections(other.ParentModes) &&
               PgcrImage == other.PgcrImage &&
               SupportsFeedFiltering == other.SupportsFeedFiltering &&
               Tier == other.Tier &&
               Blacklisted == other.Blacklisted &&
               Hash == other.Hash &&
               Index == other.Index &&
               Redacted == other.Redacted;
    }

    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyActivityModeDefinition;
    [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }

    [JsonPropertyName("hash")] public uint Hash { get; init; }

    [JsonPropertyName("index")] public int Index { get; init; }

    [JsonPropertyName("redacted")] public bool Redacted { get; init; }

    public void MapValues()
    {
        foreach (var actMode in ActivityModeMappings.Keys) actMode.TryMapValue();

        foreach (var parentMode in ParentModes) parentMode.TryMapValue();
    }

    public void SetPointerLocales(BungieLocales locale)
    {
        foreach (var actMode in ActivityModeMappings.Keys) actMode.SetLocale(locale);

        foreach (var parentMode in ParentModes) parentMode.SetLocale(locale);
    }
}