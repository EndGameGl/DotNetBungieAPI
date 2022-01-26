namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupUserInfoCard : IDeepEquatable<GroupUserInfoCard>
{
    /// <summary>
    ///     This will be the display name the clan server last saw the user as. If the account is an active cross save override, this will be the display name to use. Otherwise, this will match the displayName property.
    /// </summary>
    [JsonPropertyName("LastSeenDisplayName")]
    public string LastSeenDisplayName { get; set; }

    /// <summary>
    ///     The platform of the LastSeenDisplayName
    /// </summary>
    [JsonPropertyName("LastSeenDisplayNameType")]
    public BungieMembershipType LastSeenDisplayNameType { get; set; }

    /// <summary>
    ///     A platform specific additional display name - ex: psn Real Name, bnet Unique Name, etc.
    /// </summary>
    [JsonPropertyName("supplementalDisplayName")]
    public string SupplementalDisplayName { get; set; }

    /// <summary>
    ///     URL the Icon if available.
    /// </summary>
    [JsonPropertyName("iconPath")]
    public string IconPath { get; set; }

    /// <summary>
    ///     If there is a cross save override in effect, this value will tell you the type that is overridding this one.
    /// </summary>
    [JsonPropertyName("crossSaveOverride")]
    public BungieMembershipType CrossSaveOverride { get; set; }

    /// <summary>
    ///     The list of Membership Types indicating the platforms on which this Membership can be used.
    /// <para />
    ///      Not in Cross Save = its original membership type. Cross Save Primary = Any membership types it is overridding, and its original membership type Cross Save Overridden = Empty list
    /// </summary>
    [JsonPropertyName("applicableMembershipTypes")]
    public List<BungieMembershipType> ApplicableMembershipTypes { get; set; }

    /// <summary>
    ///     If True, this is a public user membership.
    /// </summary>
    [JsonPropertyName("isPublic")]
    public bool IsPublic { get; set; }

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

    public bool DeepEquals(GroupUserInfoCard? other)
    {
        return other is not null &&
               LastSeenDisplayName == other.LastSeenDisplayName &&
               LastSeenDisplayNameType == other.LastSeenDisplayNameType &&
               SupplementalDisplayName == other.SupplementalDisplayName &&
               IconPath == other.IconPath &&
               CrossSaveOverride == other.CrossSaveOverride &&
               ApplicableMembershipTypes.DeepEqualsListNaive(other.ApplicableMembershipTypes) &&
               IsPublic == other.IsPublic &&
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

    public void Update(GroupUserInfoCard? other)
    {
        if (other is null) return;
        if (LastSeenDisplayName != other.LastSeenDisplayName)
        {
            LastSeenDisplayName = other.LastSeenDisplayName;
            OnPropertyChanged(nameof(LastSeenDisplayName));
        }
        if (LastSeenDisplayNameType != other.LastSeenDisplayNameType)
        {
            LastSeenDisplayNameType = other.LastSeenDisplayNameType;
            OnPropertyChanged(nameof(LastSeenDisplayNameType));
        }
        if (SupplementalDisplayName != other.SupplementalDisplayName)
        {
            SupplementalDisplayName = other.SupplementalDisplayName;
            OnPropertyChanged(nameof(SupplementalDisplayName));
        }
        if (IconPath != other.IconPath)
        {
            IconPath = other.IconPath;
            OnPropertyChanged(nameof(IconPath));
        }
        if (CrossSaveOverride != other.CrossSaveOverride)
        {
            CrossSaveOverride = other.CrossSaveOverride;
            OnPropertyChanged(nameof(CrossSaveOverride));
        }
        if (!ApplicableMembershipTypes.DeepEqualsListNaive(other.ApplicableMembershipTypes))
        {
            ApplicableMembershipTypes = other.ApplicableMembershipTypes;
            OnPropertyChanged(nameof(ApplicableMembershipTypes));
        }
        if (IsPublic != other.IsPublic)
        {
            IsPublic = other.IsPublic;
            OnPropertyChanged(nameof(IsPublic));
        }
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