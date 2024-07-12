namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Profiles;

/// <summary>
///     The most essential summary information about a Profile (in Destiny 1, we called these "Accounts").
/// </summary>
public class DestinyProfileComponent
{
    /// <summary>
    ///     If you need to render the Profile (their platform name, icon, etc...) somewhere, this property contains that information.
    /// </summary>
    [JsonPropertyName("userInfo")]
    public User.UserInfoCard? UserInfo { get; set; }

    /// <summary>
    ///     The last time the user played with any character on this Profile.
    /// </summary>
    [JsonPropertyName("dateLastPlayed")]
    public DateTime? DateLastPlayed { get; set; }

    /// <summary>
    ///     If you want to know what expansions they own, this will contain that data.
    /// <para />
    ///      IMPORTANT: This field may not return the data you're interested in for Cross-Saved users. It returns the last ownership data we saw for this account - which is to say, what they've purchased on the platform on which they last played, which now could be a different platform.
    /// <para />
    ///      If you don't care about per-platform ownership and only care about whatever platform it seems they are playing on most recently, then this should be "good enough." Otherwise, this should be considered deprecated. We do not have a good alternative to provide at this time with platform specific ownership data for DLC.
    /// </summary>
    [JsonPropertyName("versionsOwned")]
    public Destiny.DestinyGameVersions? VersionsOwned { get; set; }

    /// <summary>
    ///     A list of the character IDs, for further querying on your part.
    /// </summary>
    [JsonPropertyName("characterIds")]
    public List<long> CharacterIds { get; set; }

    /// <summary>
    ///     A list of seasons that this profile owns. Unlike versionsOwned, these stay with the profile across Platforms, and thus will be valid.
    /// <para />
    ///      It turns out that Stadia Pro subscriptions will give access to seasons but only while playing on Stadia and with an active subscription. So some users (users who have Stadia Pro but choose to play on some other platform) won't see these as available: it will be whatever seasons are available for the platform on which they last played.
    /// </summary>
    [Destiny2DefinitionList<Destiny.Definitions.Seasons.DestinySeasonDefinition>("Destiny.Definitions.Seasons.DestinySeasonDefinition")]
    [JsonPropertyName("seasonHashes")]
    public List<uint> SeasonHashes { get; set; }

    /// <summary>
    ///     A list of hashes for event cards that a profile owns. Unlike most values in versionsOwned, these stay with the profile across all platforms.
    /// </summary>
    [Destiny2DefinitionList<Destiny.Definitions.Seasons.DestinyEventCardDefinition>("Destiny.Definitions.Seasons.DestinyEventCardDefinition")]
    [JsonPropertyName("eventCardHashesOwned")]
    public List<uint> EventCardHashesOwned { get; set; }

    /// <summary>
    ///     If populated, this is a reference to the season that is currently active.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.Seasons.DestinySeasonDefinition>("Destiny.Definitions.Seasons.DestinySeasonDefinition")]
    [JsonPropertyName("currentSeasonHash")]
    public uint? CurrentSeasonHash { get; set; }

    /// <summary>
    ///     If populated, this is the reward power cap for the current season.
    /// </summary>
    [JsonPropertyName("currentSeasonRewardPowerCap")]
    public int? CurrentSeasonRewardPowerCap { get; set; }

    /// <summary>
    ///     If populated, this is a reference to the event card that is currently active.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.Seasons.DestinyEventCardDefinition>("Destiny.Definitions.Seasons.DestinyEventCardDefinition")]
    [JsonPropertyName("activeEventCardHash")]
    public uint? ActiveEventCardHash { get; set; }

    /// <summary>
    ///     The 'current' Guardian Rank value, which starts at rank 1. This rank value will drop at the start of a new season to your 'renewed' rank from the previous season.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.GuardianRanks.DestinyGuardianRankDefinition>("Destiny.Definitions.GuardianRanks.DestinyGuardianRankDefinition")]
    [JsonPropertyName("currentGuardianRank")]
    public int? CurrentGuardianRank { get; set; }

    /// <summary>
    ///     The 'lifetime highest' Guardian Rank value, which starts at rank 1. This rank value should never go down.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.GuardianRanks.DestinyGuardianRankDefinition>("Destiny.Definitions.GuardianRanks.DestinyGuardianRankDefinition")]
    [JsonPropertyName("lifetimeHighestGuardianRank")]
    public int? LifetimeHighestGuardianRank { get; set; }

    /// <summary>
    ///     The seasonal 'renewed' Guardian Rank value. This rank value resets at the start of each new season to the highest-earned non-advanced rank.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.GuardianRanks.DestinyGuardianRankDefinition>("Destiny.Definitions.GuardianRanks.DestinyGuardianRankDefinition")]
    [JsonPropertyName("renewedGuardianRank")]
    public int? RenewedGuardianRank { get; set; }
}
