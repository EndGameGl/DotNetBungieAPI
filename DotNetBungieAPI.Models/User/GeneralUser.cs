namespace DotNetBungieAPI.Models.User;

public sealed record GeneralUser
{
    [JsonPropertyName("membershipId")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long MembershipId { get; init; }

    [JsonPropertyName("uniqueName")] public string UniqueName { get; init; }

    [JsonPropertyName("normalizedName")] public string NormalizedName { get; init; }

    [JsonPropertyName("displayName")] public string DisplayName { get; init; }

    [JsonPropertyName("profilePicture")] public int ProfilePicture { get; init; }

    [JsonPropertyName("profileTheme")] public int ProfileTheme { get; init; }

    [JsonPropertyName("userTitle")] public int UserTitle { get; init; }

    [JsonPropertyName("successMessageFlags")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public long SuccessMessageFlags { get; init; }

    [JsonPropertyName("isDeleted")] public bool IsDeleted { get; init; }

    [JsonPropertyName("about")] public string About { get; init; }

    [JsonPropertyName("firstAccess")] public DateTime? FirstAccess { get; init; }

    [JsonPropertyName("lastUpdate")] public DateTime? LastUpdate { get; init; }

    [JsonPropertyName("legacyPortalUID")] public long? LegacyPortalUID { get; init; }

    [JsonPropertyName("context")] public UserToUserContext Context { get; init; }

    [JsonPropertyName("psnDisplayName")] public string PsnDisplayName { get; init; }

    [JsonPropertyName("xboxDisplayName")] public string XboxDisplayName { get; init; }

    [JsonPropertyName("fbDisplayName")] public string FbDisplayName { get; init; }

    [JsonPropertyName("showActivity")] public bool? ShowActivity { get; init; }

    [JsonPropertyName("locale")] public string Locale { get; init; }

    [JsonPropertyName("localeInheritDefault")]
    public bool LocaleInheritDefault { get; init; }

    [JsonPropertyName("lastBanReportId")] public long? LastBanReportId { get; init; }

    [JsonPropertyName("showGroupMessaging")]
    public bool ShowGroupMessaging { get; init; }

    [JsonPropertyName("profilePicturePath")]
    public string ProfilePicturePath { get; init; }

    [JsonPropertyName("profilePictureWidePath")]
    public string ProfilePictureWidePath { get; init; }

    [JsonPropertyName("profileThemeName")] public string ProfileThemeName { get; init; }

    [JsonPropertyName("userTitleDisplay")] public string UserTitleDisplay { get; init; }

    [JsonPropertyName("statusText")] public string StatusText { get; init; }

    [JsonPropertyName("statusDate")] public DateTime StatusDate { get; init; }

    [JsonPropertyName("profileBanExpire")] public DateTime? ProfileBanExpire { get; init; }

    [JsonPropertyName("blizzardDisplayName")]
    public string BlizzardDisplayName { get; init; }

    [JsonPropertyName("steamDisplayName")] public string SteamDisplayName { get; init; }

    [JsonPropertyName("stadiaDisplayName")]
    public string StadiaDisplayName { get; init; }

    [JsonPropertyName("twitchDisplayName")]
    public string TwitchDisplayName { get; init; }

    [JsonPropertyName("cachedBungieGlobalDisplayName")]
    public string CachedBungieGlobalDisplayName { get; init; }

    [JsonPropertyName("cachedBungieGlobalDisplayNameCode")]
    public short? CachedBungieGlobalDisplayNameCode { get; init; }
    
    [JsonPropertyName("egsDisplayName")]
    public string? EgsDisplayName { get; init; }
}