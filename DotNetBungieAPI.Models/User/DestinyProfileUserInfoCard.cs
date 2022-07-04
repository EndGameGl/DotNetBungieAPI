using DotNetBungieAPI.Models.Destiny;
using DotNetBungieAPI.Models.Destiny.Components;

namespace DotNetBungieAPI.Models.User;

public sealed record DestinyProfileUserInfoCard : UserInfoCard
{
    [JsonPropertyName("dateLastPlayed")] public DateTime DateLastPlayed { get; init; }

    /// <summary>
    ///     If this profile is being overridden/obscured by Cross Save, this will be set to true. We will still return the
    ///     profile for display purposes where users need to know the info: it is up to any given area of the app/site to
    ///     determine if this profile should still be shown.
    /// </summary>
    [JsonPropertyName("isOverridden")]
    public bool IsOverridden { get; init; }

    /// <summary>
    ///     If true, this account is hooked up as the "Primary" cross save account for one or more platforms.
    /// </summary>
    [JsonPropertyName("isCrossSavePrimary")]
    public bool IsCrossSavePrimary { get; init; }

    /// <summary>
    ///     This is the silver available on this Profile across any platforms on which they have purchased silver.
    ///     <para />
    ///     This is only available if you are requesting yourself.
    /// </summary>
    [JsonPropertyName("platformSilver")]
    public DestinyPlatformSilverComponent PlatformSilver { get; init; }

    /// <summary>
    ///     If this profile is not in a cross save pairing, this will return the game versions that we believe this profile has
    ///     access to.
    ///     <para />
    ///     For the time being, we will not return this information for any membership that is in a cross save pairing. The
    ///     gist is that, once the pairing occurs, we do not currently have a consistent way to get that information for the
    ///     profile's original Platform, and thus gameVersions would be too inconsistent (based on the last platform they
    ///     happened to play on) for the info to be useful.
    ///     <para />
    ///     If we ever can get this data, this field will be deprecated and replaced with data on the
    ///     DestinyLinkedProfileResponse itself, with game versions per linked Platform. But since we can't get that, we have
    ///     this as a stop-gap measure for getting the data in the only situation that we currently need it.
    /// </summary>
    [JsonPropertyName("unpairedGameVersions")]
    public DestinyGameVersions? UnpairedGameVersions { get; init; }
}