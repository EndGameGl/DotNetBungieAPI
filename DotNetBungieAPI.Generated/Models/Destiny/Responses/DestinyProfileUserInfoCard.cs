namespace DotNetBungieAPI.Generated.Models.Destiny.Responses;

public class DestinyProfileUserInfoCard : IDeepEquatable<DestinyProfileUserInfoCard>
{
    [JsonPropertyName("dateLastPlayed")]
    public DateTime DateLastPlayed { get; set; }

    /// <summary>
    ///     If this profile is being overridden/obscured by Cross Save, this will be set to true. We will still return the profile for display purposes where users need to know the info: it is up to any given area of the app/site to determine if this profile should still be shown.
    /// </summary>
    [JsonPropertyName("isOverridden")]
    public bool IsOverridden { get; set; }

    /// <summary>
    ///     If true, this account is hooked up as the "Primary" cross save account for one or more platforms.
    /// </summary>
    [JsonPropertyName("isCrossSavePrimary")]
    public bool IsCrossSavePrimary { get; set; }

    /// <summary>
    ///     This is the silver available on this Profile across any platforms on which they have purchased silver.
    /// <para />
    ///      This is only available if you are requesting yourself.
    /// </summary>
    [JsonPropertyName("platformSilver")]
    public Destiny.Components.Inventory.DestinyPlatformSilverComponent PlatformSilver { get; set; }

    /// <summary>
    ///     If this profile is not in a cross save pairing, this will return the game versions that we believe this profile has access to.
    /// <para />
    ///      For the time being, we will not return this information for any membership that is in a cross save pairing. The gist is that, once the pairing occurs, we do not currently have a consistent way to get that information for the profile's original Platform, and thus gameVersions would be too inconsistent (based on the last platform they happened to play on) for the info to be useful.
    /// <para />
    ///      If we ever can get this data, this field will be deprecated and replaced with data on the DestinyLinkedProfileResponse itself, with game versions per linked Platform. But since we can't get that, we have this as a stop-gap measure for getting the data in the only situation that we currently need it.
    /// </summary>
    [JsonPropertyName("unpairedGameVersions")]
    public int? UnpairedGameVersions { get; set; }

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

    public bool DeepEquals(DestinyProfileUserInfoCard? other)
    {
        return other is not null &&
               DateLastPlayed == other.DateLastPlayed &&
               IsOverridden == other.IsOverridden &&
               IsCrossSavePrimary == other.IsCrossSavePrimary &&
               (PlatformSilver is not null ? PlatformSilver.DeepEquals(other.PlatformSilver) : other.PlatformSilver is null) &&
               UnpairedGameVersions == other.UnpairedGameVersions &&
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

    public void Update(DestinyProfileUserInfoCard? other)
    {
        if (other is null) return;
        if (DateLastPlayed != other.DateLastPlayed)
        {
            DateLastPlayed = other.DateLastPlayed;
            OnPropertyChanged(nameof(DateLastPlayed));
        }
        if (IsOverridden != other.IsOverridden)
        {
            IsOverridden = other.IsOverridden;
            OnPropertyChanged(nameof(IsOverridden));
        }
        if (IsCrossSavePrimary != other.IsCrossSavePrimary)
        {
            IsCrossSavePrimary = other.IsCrossSavePrimary;
            OnPropertyChanged(nameof(IsCrossSavePrimary));
        }
        if (!PlatformSilver.DeepEquals(other.PlatformSilver))
        {
            PlatformSilver.Update(other.PlatformSilver);
            OnPropertyChanged(nameof(PlatformSilver));
        }
        if (UnpairedGameVersions != other.UnpairedGameVersions)
        {
            UnpairedGameVersions = other.UnpairedGameVersions;
            OnPropertyChanged(nameof(UnpairedGameVersions));
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