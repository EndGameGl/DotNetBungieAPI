namespace DotNetBungieAPI.Generated.Models.User;

/// <summary>
///     Very basic info about a user as returned by the Account server.
/// </summary>
public class UserMembership : IDeepEquatable<UserMembership>
{
    /// <summary>
    ///     Type of the membership. Not necessarily the native type.
    /// </summary>
    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; set; }

    /// <summary>
    ///     Membership ID as they user is known in the Accounts service
    /// </summary>
    [JsonPropertyName("membershipId")]
    public long MembershipId { get; set; }

    /// <summary>
    ///     Display Name the player has chosen for themselves. The display name is optional when the data type is used as input to a platform API.
    /// </summary>
    [JsonPropertyName("displayName")]
    public string DisplayName { get; set; }

    /// <summary>
    ///     The bungie global display name, if set.
    /// </summary>
    [JsonPropertyName("bungieGlobalDisplayName")]
    public string BungieGlobalDisplayName { get; set; }

    /// <summary>
    ///     The bungie global display name code, if set.
    /// </summary>
    [JsonPropertyName("bungieGlobalDisplayNameCode")]
    public short? BungieGlobalDisplayNameCode { get; set; }

    public bool DeepEquals(UserMembership? other)
    {
        return other is not null &&
               MembershipType == other.MembershipType &&
               MembershipId == other.MembershipId &&
               DisplayName == other.DisplayName &&
               BungieGlobalDisplayName == other.BungieGlobalDisplayName &&
               BungieGlobalDisplayNameCode == other.BungieGlobalDisplayNameCode;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(UserMembership? other)
    {
        if (other is null) return;
        if (MembershipType != other.MembershipType)
        {
            MembershipType = other.MembershipType;
            OnPropertyChanged(nameof(MembershipType));
        }
        if (MembershipId != other.MembershipId)
        {
            MembershipId = other.MembershipId;
            OnPropertyChanged(nameof(MembershipId));
        }
        if (DisplayName != other.DisplayName)
        {
            DisplayName = other.DisplayName;
            OnPropertyChanged(nameof(DisplayName));
        }
        if (BungieGlobalDisplayName != other.BungieGlobalDisplayName)
        {
            BungieGlobalDisplayName = other.BungieGlobalDisplayName;
            OnPropertyChanged(nameof(BungieGlobalDisplayName));
        }
        if (BungieGlobalDisplayNameCode != other.BungieGlobalDisplayNameCode)
        {
            BungieGlobalDisplayNameCode = other.BungieGlobalDisplayNameCode;
            OnPropertyChanged(nameof(BungieGlobalDisplayNameCode));
        }
    }
}