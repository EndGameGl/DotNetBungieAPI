namespace DotNetBungieAPI.Models.Destiny.Responses;

/// <summary>
///     I know what you seek. You seek linked accounts. Found them, you have.
/// <para />
///     This contract returns a minimal amount of data about Destiny Accounts that are linked through your Bungie.Net account. We will not return accounts in this response whose
/// </summary>
public sealed class DestinyLinkedProfilesResponse
{
    /// <summary>
    ///     Any Destiny account for whom we could successfully pull characters will be returned here, as the Platform-level summary of user data. (no character data, no Destiny account data other than the Membership ID and Type so you can make further queries)
    /// </summary>
    [JsonPropertyName("profiles")]
    public Destiny.Responses.DestinyProfileUserInfoCard[]? Profiles { get; init; }

    /// <summary>
    ///     If the requested membership had a linked Bungie.Net membership ID, this is the basic information about that BNet account.
    /// <para />
    ///     I know, Tetron; I know this is mixing UserServices concerns with DestinyServices concerns. But it's so damn convenient! https://www.youtube.com/watch?v=X5R-bB-gKVI
    /// </summary>
    [JsonPropertyName("bnetMembership")]
    public User.UserInfoCard? BnetMembership { get; init; }

    /// <summary>
    ///     This is brief summary info for profiles that we believe have valid Destiny info, but who failed to return data for some other reason and thus we know that subsequent calls for their info will also fail.
    /// </summary>
    [JsonPropertyName("profilesWithErrors")]
    public Destiny.Responses.DestinyErrorProfile[]? ProfilesWithErrors { get; init; }
}
