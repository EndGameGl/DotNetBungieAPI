namespace DotNetBungieAPI.Generated.Models.User;

public class GeneralUser : IDeepEquatable<GeneralUser>
{
    [JsonPropertyName("membershipId")]
    public long MembershipId { get; set; }

    [JsonPropertyName("uniqueName")]
    public string UniqueName { get; set; }

    [JsonPropertyName("normalizedName")]
    public string NormalizedName { get; set; }

    [JsonPropertyName("displayName")]
    public string DisplayName { get; set; }

    [JsonPropertyName("profilePicture")]
    public int ProfilePicture { get; set; }

    [JsonPropertyName("profileTheme")]
    public int ProfileTheme { get; set; }

    [JsonPropertyName("userTitle")]
    public int UserTitle { get; set; }

    [JsonPropertyName("successMessageFlags")]
    public long SuccessMessageFlags { get; set; }

    [JsonPropertyName("isDeleted")]
    public bool IsDeleted { get; set; }

    [JsonPropertyName("about")]
    public string About { get; set; }

    [JsonPropertyName("firstAccess")]
    public DateTime? FirstAccess { get; set; }

    [JsonPropertyName("lastUpdate")]
    public DateTime? LastUpdate { get; set; }

    [JsonPropertyName("legacyPortalUID")]
    public long? LegacyPortalUID { get; set; }

    [JsonPropertyName("context")]
    public User.UserToUserContext Context { get; set; }

    [JsonPropertyName("psnDisplayName")]
    public string PsnDisplayName { get; set; }

    [JsonPropertyName("xboxDisplayName")]
    public string XboxDisplayName { get; set; }

    [JsonPropertyName("fbDisplayName")]
    public string FbDisplayName { get; set; }

    [JsonPropertyName("showActivity")]
    public bool? ShowActivity { get; set; }

    [JsonPropertyName("locale")]
    public string Locale { get; set; }

    [JsonPropertyName("localeInheritDefault")]
    public bool LocaleInheritDefault { get; set; }

    [JsonPropertyName("lastBanReportId")]
    public long? LastBanReportId { get; set; }

    [JsonPropertyName("showGroupMessaging")]
    public bool ShowGroupMessaging { get; set; }

    [JsonPropertyName("profilePicturePath")]
    public string ProfilePicturePath { get; set; }

    [JsonPropertyName("profilePictureWidePath")]
    public string ProfilePictureWidePath { get; set; }

    [JsonPropertyName("profileThemeName")]
    public string ProfileThemeName { get; set; }

    [JsonPropertyName("userTitleDisplay")]
    public string UserTitleDisplay { get; set; }

    [JsonPropertyName("statusText")]
    public string StatusText { get; set; }

    [JsonPropertyName("statusDate")]
    public DateTime StatusDate { get; set; }

    [JsonPropertyName("profileBanExpire")]
    public DateTime? ProfileBanExpire { get; set; }

    [JsonPropertyName("blizzardDisplayName")]
    public string BlizzardDisplayName { get; set; }

    [JsonPropertyName("steamDisplayName")]
    public string SteamDisplayName { get; set; }

    [JsonPropertyName("stadiaDisplayName")]
    public string StadiaDisplayName { get; set; }

    [JsonPropertyName("twitchDisplayName")]
    public string TwitchDisplayName { get; set; }

    [JsonPropertyName("cachedBungieGlobalDisplayName")]
    public string CachedBungieGlobalDisplayName { get; set; }

    [JsonPropertyName("cachedBungieGlobalDisplayNameCode")]
    public short? CachedBungieGlobalDisplayNameCode { get; set; }

    public bool DeepEquals(GeneralUser? other)
    {
        return other is not null &&
               MembershipId == other.MembershipId &&
               UniqueName == other.UniqueName &&
               NormalizedName == other.NormalizedName &&
               DisplayName == other.DisplayName &&
               ProfilePicture == other.ProfilePicture &&
               ProfileTheme == other.ProfileTheme &&
               UserTitle == other.UserTitle &&
               SuccessMessageFlags == other.SuccessMessageFlags &&
               IsDeleted == other.IsDeleted &&
               About == other.About &&
               FirstAccess == other.FirstAccess &&
               LastUpdate == other.LastUpdate &&
               LegacyPortalUID == other.LegacyPortalUID &&
               (Context is not null ? Context.DeepEquals(other.Context) : other.Context is null) &&
               PsnDisplayName == other.PsnDisplayName &&
               XboxDisplayName == other.XboxDisplayName &&
               FbDisplayName == other.FbDisplayName &&
               ShowActivity == other.ShowActivity &&
               Locale == other.Locale &&
               LocaleInheritDefault == other.LocaleInheritDefault &&
               LastBanReportId == other.LastBanReportId &&
               ShowGroupMessaging == other.ShowGroupMessaging &&
               ProfilePicturePath == other.ProfilePicturePath &&
               ProfilePictureWidePath == other.ProfilePictureWidePath &&
               ProfileThemeName == other.ProfileThemeName &&
               UserTitleDisplay == other.UserTitleDisplay &&
               StatusText == other.StatusText &&
               StatusDate == other.StatusDate &&
               ProfileBanExpire == other.ProfileBanExpire &&
               BlizzardDisplayName == other.BlizzardDisplayName &&
               SteamDisplayName == other.SteamDisplayName &&
               StadiaDisplayName == other.StadiaDisplayName &&
               TwitchDisplayName == other.TwitchDisplayName &&
               CachedBungieGlobalDisplayName == other.CachedBungieGlobalDisplayName &&
               CachedBungieGlobalDisplayNameCode == other.CachedBungieGlobalDisplayNameCode;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(GeneralUser? other)
    {
        if (other is null) return;
        if (MembershipId != other.MembershipId)
        {
            MembershipId = other.MembershipId;
            OnPropertyChanged(nameof(MembershipId));
        }
        if (UniqueName != other.UniqueName)
        {
            UniqueName = other.UniqueName;
            OnPropertyChanged(nameof(UniqueName));
        }
        if (NormalizedName != other.NormalizedName)
        {
            NormalizedName = other.NormalizedName;
            OnPropertyChanged(nameof(NormalizedName));
        }
        if (DisplayName != other.DisplayName)
        {
            DisplayName = other.DisplayName;
            OnPropertyChanged(nameof(DisplayName));
        }
        if (ProfilePicture != other.ProfilePicture)
        {
            ProfilePicture = other.ProfilePicture;
            OnPropertyChanged(nameof(ProfilePicture));
        }
        if (ProfileTheme != other.ProfileTheme)
        {
            ProfileTheme = other.ProfileTheme;
            OnPropertyChanged(nameof(ProfileTheme));
        }
        if (UserTitle != other.UserTitle)
        {
            UserTitle = other.UserTitle;
            OnPropertyChanged(nameof(UserTitle));
        }
        if (SuccessMessageFlags != other.SuccessMessageFlags)
        {
            SuccessMessageFlags = other.SuccessMessageFlags;
            OnPropertyChanged(nameof(SuccessMessageFlags));
        }
        if (IsDeleted != other.IsDeleted)
        {
            IsDeleted = other.IsDeleted;
            OnPropertyChanged(nameof(IsDeleted));
        }
        if (About != other.About)
        {
            About = other.About;
            OnPropertyChanged(nameof(About));
        }
        if (FirstAccess != other.FirstAccess)
        {
            FirstAccess = other.FirstAccess;
            OnPropertyChanged(nameof(FirstAccess));
        }
        if (LastUpdate != other.LastUpdate)
        {
            LastUpdate = other.LastUpdate;
            OnPropertyChanged(nameof(LastUpdate));
        }
        if (LegacyPortalUID != other.LegacyPortalUID)
        {
            LegacyPortalUID = other.LegacyPortalUID;
            OnPropertyChanged(nameof(LegacyPortalUID));
        }
        if (!Context.DeepEquals(other.Context))
        {
            Context.Update(other.Context);
            OnPropertyChanged(nameof(Context));
        }
        if (PsnDisplayName != other.PsnDisplayName)
        {
            PsnDisplayName = other.PsnDisplayName;
            OnPropertyChanged(nameof(PsnDisplayName));
        }
        if (XboxDisplayName != other.XboxDisplayName)
        {
            XboxDisplayName = other.XboxDisplayName;
            OnPropertyChanged(nameof(XboxDisplayName));
        }
        if (FbDisplayName != other.FbDisplayName)
        {
            FbDisplayName = other.FbDisplayName;
            OnPropertyChanged(nameof(FbDisplayName));
        }
        if (ShowActivity != other.ShowActivity)
        {
            ShowActivity = other.ShowActivity;
            OnPropertyChanged(nameof(ShowActivity));
        }
        if (Locale != other.Locale)
        {
            Locale = other.Locale;
            OnPropertyChanged(nameof(Locale));
        }
        if (LocaleInheritDefault != other.LocaleInheritDefault)
        {
            LocaleInheritDefault = other.LocaleInheritDefault;
            OnPropertyChanged(nameof(LocaleInheritDefault));
        }
        if (LastBanReportId != other.LastBanReportId)
        {
            LastBanReportId = other.LastBanReportId;
            OnPropertyChanged(nameof(LastBanReportId));
        }
        if (ShowGroupMessaging != other.ShowGroupMessaging)
        {
            ShowGroupMessaging = other.ShowGroupMessaging;
            OnPropertyChanged(nameof(ShowGroupMessaging));
        }
        if (ProfilePicturePath != other.ProfilePicturePath)
        {
            ProfilePicturePath = other.ProfilePicturePath;
            OnPropertyChanged(nameof(ProfilePicturePath));
        }
        if (ProfilePictureWidePath != other.ProfilePictureWidePath)
        {
            ProfilePictureWidePath = other.ProfilePictureWidePath;
            OnPropertyChanged(nameof(ProfilePictureWidePath));
        }
        if (ProfileThemeName != other.ProfileThemeName)
        {
            ProfileThemeName = other.ProfileThemeName;
            OnPropertyChanged(nameof(ProfileThemeName));
        }
        if (UserTitleDisplay != other.UserTitleDisplay)
        {
            UserTitleDisplay = other.UserTitleDisplay;
            OnPropertyChanged(nameof(UserTitleDisplay));
        }
        if (StatusText != other.StatusText)
        {
            StatusText = other.StatusText;
            OnPropertyChanged(nameof(StatusText));
        }
        if (StatusDate != other.StatusDate)
        {
            StatusDate = other.StatusDate;
            OnPropertyChanged(nameof(StatusDate));
        }
        if (ProfileBanExpire != other.ProfileBanExpire)
        {
            ProfileBanExpire = other.ProfileBanExpire;
            OnPropertyChanged(nameof(ProfileBanExpire));
        }
        if (BlizzardDisplayName != other.BlizzardDisplayName)
        {
            BlizzardDisplayName = other.BlizzardDisplayName;
            OnPropertyChanged(nameof(BlizzardDisplayName));
        }
        if (SteamDisplayName != other.SteamDisplayName)
        {
            SteamDisplayName = other.SteamDisplayName;
            OnPropertyChanged(nameof(SteamDisplayName));
        }
        if (StadiaDisplayName != other.StadiaDisplayName)
        {
            StadiaDisplayName = other.StadiaDisplayName;
            OnPropertyChanged(nameof(StadiaDisplayName));
        }
        if (TwitchDisplayName != other.TwitchDisplayName)
        {
            TwitchDisplayName = other.TwitchDisplayName;
            OnPropertyChanged(nameof(TwitchDisplayName));
        }
        if (CachedBungieGlobalDisplayName != other.CachedBungieGlobalDisplayName)
        {
            CachedBungieGlobalDisplayName = other.CachedBungieGlobalDisplayName;
            OnPropertyChanged(nameof(CachedBungieGlobalDisplayName));
        }
        if (CachedBungieGlobalDisplayNameCode != other.CachedBungieGlobalDisplayNameCode)
        {
            CachedBungieGlobalDisplayNameCode = other.CachedBungieGlobalDisplayNameCode;
            OnPropertyChanged(nameof(CachedBungieGlobalDisplayNameCode));
        }
    }
}