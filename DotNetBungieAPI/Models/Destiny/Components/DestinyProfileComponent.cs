using System;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Models.Destiny.Definitions.Seasons;
using DotNetBungieAPI.Models.User;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    /// <summary>
    ///     The most essential summary information about a Profile (in Destiny 1, we called these "Accounts").
    /// </summary>
    public sealed record DestinyProfileComponent
    {
        /// <summary>
        ///     If you need to render the Profile (their platform name, icon, etc...) somewhere, this property contains that
        ///     information.
        /// </summary>
        [JsonPropertyName("userInfo")]
        public UserInfoCard UserInfo { get; init; }

        /// <summary>
        ///     The last time the user played with any character on this Profile.
        /// </summary>
        [JsonPropertyName("dateLastPlayed")]
        public DateTime DateLastPlayed { get; init; }

        /// <summary>
        ///     If you want to know what expansions they own, this will contain that data.
        ///     <para />
        ///     IMPORTANT: This field may not return the data you're interested in for Cross-Saved users. It returns the last
        ///     ownership data we saw for this account - which is to say, what they've purchased on the platform on which they last
        ///     played, which now could be a different platform.
        ///     <para />
        ///     If you don't care about per-platform ownership and only care about whatever platform it seems they are playing on
        ///     most recently, then this should be "good enough." Otherwise, this should be considered deprecated. We do not have a
        ///     good alternative to provide at this time with platform specific ownership data for DLC.
        /// </summary>
        [JsonPropertyName("versionsOwned")]
        public DestinyGameVersions VersionsOwned { get; init; }

        /// <summary>
        ///     A list of the character IDs, for further querying on your part.
        /// </summary>
        [JsonPropertyName("characterIds")]
        public ReadOnlyCollection<long> CharacterIds { get; init; } = Defaults.EmptyReadOnlyCollection<long>();

        /// <summary>
        ///     A list of seasons that this profile owns. Unlike versionsOwned, these stay with the profile across Platforms, and
        ///     thus will be valid.
        ///     <para />
        ///     It turns out that Stadia Pro subscriptions will give access to seasons but only while playing on Stadia and with an
        ///     active subscription. So some users (users who have Stadia Pro but choose to play on some other platform) won't see
        ///     these as available: it will be whatever seasons are available for the platform on which they last played.
        /// </summary>
        [JsonPropertyName("seasonHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinySeasonDefinition>> Seasons { get; init; } =
            Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinySeasonDefinition>>();

        /// <summary>
        ///     If populated, this is a reference to the season that is currently active.
        /// </summary>
        [JsonPropertyName("currentSeasonHash")]
        public DefinitionHashPointer<DestinySeasonDefinition> CurrentSeason { get; init; } =
            DefinitionHashPointer<DestinySeasonDefinition>.Empty;

        /// <summary>
        ///     If populated, this is the reward power cap for the current season
        /// </summary>
        [JsonPropertyName("currentSeasonRewardPowerCap")]
        public int? CurrentSeasonRewardPowerCap { get; init; }
    }
}