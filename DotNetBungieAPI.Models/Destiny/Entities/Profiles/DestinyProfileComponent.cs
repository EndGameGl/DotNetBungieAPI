namespace DotNetBungieAPI.Models.Destiny.Entities.Profiles;

/// <summary>
///     The most essential summary information about a Profile (in Destiny 1, we called these "Accounts").
/// </summary>
public sealed class DestinyProfileComponent
{
    /// <summary>
    ///     If you need to render the Profile (their platform name, icon, etc...) somewhere, this property contains that information.
    /// </summary>
    [JsonPropertyName("userInfo")]
    public User.UserInfoCard? UserInfo { get; init; }

    /// <summary>
    ///     The last time the user played with any character on this Profile.
    /// </summary>
    [JsonPropertyName("dateLastPlayed")]
    public DateTime DateLastPlayed { get; init; }

    /// <summary>
    ///     If you want to know what expansions they own, this will contain that data.
    /// <para />
    ///      IMPORTANT: This field may not return the data you're interested in for Cross-Saved users. It returns the last ownership data we saw for this account - which is to say, what they've purchased on the platform on which they last played, which now could be a different platform.
    /// <para />
    ///      If you don't care about per-platform ownership and only care about whatever platform it seems they are playing on most recently, then this should be "good enough." Otherwise, this should be considered deprecated. We do not have a good alternative to provide at this time with platform specific ownership data for DLC.
    /// </summary>
    [JsonPropertyName("versionsOwned")]
    public Destiny.DestinyGameVersions VersionsOwned { get; init; }

    /// <summary>
    ///     A list of the character IDs, for further querying on your part.
    /// </summary>
    [JsonPropertyName("characterIds")]
    public long[]? CharacterIds { get; init; }

    /// <summary>
    ///     A list of seasons that this profile owns. Unlike versionsOwned, these stay with the profile across Platforms, and thus will be valid.
    /// <para />
    ///      It turns out that Stadia Pro subscriptions will give access to seasons but only while playing on Stadia and with an active subscription. So some users (users who have Stadia Pro but choose to play on some other platform) won't see these as available: it will be whatever seasons are available for the platform on which they last played.
    /// </summary>
    [JsonPropertyName("seasonHashes")]
    public DefinitionHashPointer<Destiny.Definitions.Seasons.DestinySeasonDefinition>[]? SeasonHashes { get; init; }

    /// <summary>
    ///     A list of season passes aka reward passes that this profile owns. Unlike versionsOwned, these stay with the profile across Platforms, and thus will be valid.
    /// </summary>
    [JsonPropertyName("seasonPassHashes")]
    public DefinitionHashPointer<Destiny.Definitions.Seasons.DestinySeasonPassDefinition>[]? SeasonPassHashes { get; init; }

    /// <summary>
    ///     A list of hashes for event cards that a profile owns. Unlike most values in versionsOwned, these stay with the profile across all platforms.
    /// </summary>
    [JsonPropertyName("eventCardHashesOwned")]
    public DefinitionHashPointer<Destiny.Definitions.Seasons.DestinyEventCardDefinition>[]? EventCardHashesOwned { get; init; }

    /// <summary>
    ///     If populated, this is a reference to the season that is currently active.
    /// </summary>
    [JsonPropertyName("currentSeasonHash")]
    public DefinitionHashPointer<Destiny.Definitions.Seasons.DestinySeasonDefinition>? CurrentSeasonHash { get; init; }

    /// <summary>
    ///     If populated, this is the reward power cap for the current season.
    /// </summary>
    [JsonPropertyName("currentSeasonRewardPowerCap")]
    public int? CurrentSeasonRewardPowerCap { get; init; }

    /// <summary>
    ///     If populated, this is a reference to the event card that is currently active.
    /// </summary>
    [JsonPropertyName("activeEventCardHash")]
    public DefinitionHashPointer<Destiny.Definitions.Seasons.DestinyEventCardDefinition>? ActiveEventCardHash { get; init; }

    /// <summary>
    ///     The 'current' Guardian Rank value, which starts at rank 1. This rank value will drop at the start of a new season to your 'renewed' rank from the previous season.
    /// </summary>
    [JsonPropertyName("currentGuardianRank")]
    public DefinitionHashPointer<Destiny.Definitions.GuardianRanks.DestinyGuardianRankDefinition> CurrentGuardianRank { get; init; }

    /// <summary>
    ///     The 'lifetime highest' Guardian Rank value, which starts at rank 1. This rank value should never go down.
    /// </summary>
    [JsonPropertyName("lifetimeHighestGuardianRank")]
    public DefinitionHashPointer<Destiny.Definitions.GuardianRanks.DestinyGuardianRankDefinition> LifetimeHighestGuardianRank { get; init; }

    /// <summary>
    ///     The seasonal 'renewed' Guardian Rank value. This rank value resets at the start of each new season to the highest-earned non-advanced rank.
    /// </summary>
    [JsonPropertyName("renewedGuardianRank")]
    public DefinitionHashPointer<Destiny.Definitions.GuardianRanks.DestinyGuardianRankDefinition> RenewedGuardianRank { get; init; }
}
