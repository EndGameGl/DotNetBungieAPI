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
}