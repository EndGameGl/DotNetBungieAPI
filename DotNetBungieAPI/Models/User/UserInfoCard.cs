namespace DotNetBungieAPI.Models.User;

/// <summary>
///     This contract supplies basic information commonly used to display a minimal amount of information about a user.
///     Take care to not add more properties here unless the property applies in all (or at least the majority) of the
///     situations where UserInfoCard is used. Avoid adding game specific or platform specific details here. In cases where
///     UserInfoCard is a subset of the data needed in a contract, use UserInfoCard as a property of other contracts.
/// </summary>
public record UserInfoCard : CrossSaveUserMembership
{
    /// <summary>
    ///     A platform specific additional display name - ex: psn Real Name, bnet Unique Name, etc.
    /// </summary>
    [JsonPropertyName("supplementalDisplayName")]
    public string SupplementalDisplayName { get; init; }

    /// <summary>
    ///     URL the Icon if available.
    /// </summary>
    [JsonPropertyName("iconPath")]
    public string IconPath { get; init; }
}