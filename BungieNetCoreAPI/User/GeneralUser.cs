using Newtonsoft.Json;
using System;

namespace NetBungieAPI.User
{
    public class GeneralUser
    {
        public long MembershipId { get; }
        public string UniqueName { get; }
        public string NormalizedName { get; }
        public string DisplayName { get; }
        public int ProfilePicture { get; }
        public int ProfileTheme { get; }
        public int UserTitle { get; }
        public long SuccessMessageFlags { get; }
        public bool IsDeleted { get; }
        public string About { get; }
        public DateTime? FirstAccess { get; }
        public DateTime? LastUpdate { get; }
        public long? LegacyPortalUID { get; }
        public UserToUserContext Context { get; }
        public string PsnDisplayName { get; }
        public string XboxDisplayName { get; }
        public string FbDisplayName { get; }
        public bool? ShowActivity { get; }
        public string Locale { get; }
        public bool LocaleInheritDefault { get; }
        public long? LastBanReportId { get; }
        public bool ShowGroupMessaging { get; }
        public string ProfilePicturePath { get; }
        public string ProfilePictureWidePath { get; }
        public string ProfileThemeName { get; }
        public string UserTitleDisplay { get; }
        public string StatusText { get; }
        public DateTime StatusDate { get; }
        public DateTime? ProfileBanExpire { get; }
        public string BlizzardDisplayName { get; }
        public string SteamDisplayName { get; }
        public string StadiaDisplayName { get; }
        public string TwitchDisplayName { get; }

        [JsonConstructor]
        internal GeneralUser(long membershipId, string uniqueName, string normalizedName, string displayName, int profilePicture, int profileTheme,
            int userTitle, long successMessageFlags, bool isDeleted, string about, DateTime? firstAccess, DateTime? lastUpdate, long? legacyPortalUID,
            UserToUserContext context, string psnDisplayName, string xboxDisplayName, string fbDisplayName, bool? showActivity, string locale,
            bool localeInheritDefault, long? lastBanReportId, bool showGroupMessaging, string profilePicturePath, string profilePictureWidePath,
            string profileThemeName, string userTitleDisplay, string statusText, DateTime statusDate, DateTime? profileBanExpire, string blizzardDisplayName,
            string steamDisplayName, string stadiaDisplayName, string twitchDisplayName)
        {
            MembershipId = membershipId;
            UniqueName = uniqueName;
            NormalizedName = normalizedName;
            DisplayName = displayName;
            ProfilePicture = profilePicture;
            ProfileTheme = profileTheme;
            UserTitle = userTitle;
            SuccessMessageFlags = successMessageFlags;
            IsDeleted = isDeleted;
            About = about;
            FirstAccess = firstAccess;
            LastUpdate = lastUpdate;
            LegacyPortalUID = legacyPortalUID;
            Context = context;
            PsnDisplayName = psnDisplayName;
            XboxDisplayName = xboxDisplayName;
            FbDisplayName = fbDisplayName;
            ShowActivity = showActivity;
            Locale = locale;
            LocaleInheritDefault = localeInheritDefault;
            LastBanReportId = lastBanReportId;
            ShowGroupMessaging = showGroupMessaging;
            ProfilePicturePath = profilePicturePath;
            ProfilePictureWidePath = profilePictureWidePath;
            ProfileThemeName = profileThemeName;
            UserTitleDisplay = userTitleDisplay;
            StatusText = statusText;
            StatusDate = statusDate;
            ProfileBanExpire = profileBanExpire;
            BlizzardDisplayName = blizzardDisplayName;
            SteamDisplayName = steamDisplayName;
            StadiaDisplayName = stadiaDisplayName;
            TwitchDisplayName = twitchDisplayName;
        }
    }
}
