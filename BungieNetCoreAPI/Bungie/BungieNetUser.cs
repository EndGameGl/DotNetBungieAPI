using Newtonsoft.Json;
using System;

namespace BungieNetCoreAPI.Bungie
{
    public class BungieNetUser
    {
        public string MembershipId { get; }
        public string UniqueName { get; }
        public string DisplayName { get; }
        public int ProfilePicture { get; }
        public int ProfileTheme { get; }
        public int UserTitle { get; }
        public string SuccessMessageFlags { get; }
        public bool IsDeleted { get; }
        public string About { get; }
        public DateTime FirstAccess { get; }
        public DateTime LastUpdate { get; }
        public BungieNetUserContext Context { get; }
        public bool ShowActivity { get; }
        public string Locale { get; }
        public bool LocaleInheritDefault { get; }
        public bool ShowGroupMessaging { get; }
        public string ProfilePicturePath { get; }
        public string ProfileThemeName { get; }
        public string UserTitleDisplay { get; }
        public string StatusText { get; }
        public DateTime StatusDate { get; }
        public string BlizzardDisplayName { get; }
        public string SteamDisplayName { get; }

        [JsonConstructor]
        private BungieNetUser(string membershipId, string uniqueName, string displayName, int profilePicture, int profileTheme, int userTitle, string successMessageFlags,
            bool isDeleted, string about, DateTime firstAccess, DateTime lastUpdate, BungieNetUserContext context,  bool showActivity, string locale, bool localeInheritDefault, 
            bool showGroupMessaging, string profilePicturePath, string profileThemeName, string userTitleDisplay, string statusText, DateTime statusDate, 
            string blizzardDisplayName, string steamDisplayName)
        {
            MembershipId = membershipId;
            UniqueName = uniqueName;
            DisplayName = displayName;
            ProfilePicture = profilePicture;
            ProfileTheme = profileTheme;
            UserTitle = userTitle;
            SuccessMessageFlags = successMessageFlags;
            IsDeleted = isDeleted;
            About = about;
            FirstAccess = firstAccess;
            LastUpdate = lastUpdate;
            Context = context;
            ShowActivity = showActivity;
            Locale = locale;
            LocaleInheritDefault = localeInheritDefault;
            ShowGroupMessaging = showGroupMessaging;
            ProfilePicturePath = profilePicturePath;
            ProfileThemeName = profileThemeName;
            UserTitleDisplay = userTitleDisplay;
            StatusText = statusText;
            StatusDate = statusDate;
            BlizzardDisplayName = blizzardDisplayName;
            SteamDisplayName = steamDisplayName;
        }
        public override string ToString()
        {
            return $"{DisplayName} ({MembershipId})";
        }
    }
}
