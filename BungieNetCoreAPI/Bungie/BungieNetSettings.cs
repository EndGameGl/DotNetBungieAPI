using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Bungie
{
    public class BungieNetSettings
    {
        public string Environment { get; }
        public Dictionary<string, BungieSystemSetting> Systems { get; }
        public BungieSetting[] IgnoreReasons { get; }
        public BungieSetting[] ForumCategories { get; }
        public BungieSetting[] GroupAvatars { get; }
        public BungieSetting[] DestinyMembershipTypes { get; }
        public BungieSetting[] RecruitmentPlatformTags { get; }
        public BungieSetting[] RecruitmentMiscTags { get; }
        public BungieSetting[] RecruitmentActivities { get; }
        public BungieSetting[] UserContentLocales { get; }
        public BungieSetting[] SystemContentLocales { get; }
        public BungieSetting[] ClanBannerDecals { get; }
        public BungieSetting[] ClanBannerDecalColors { get; }
        public BungieSetting[] ClanBannerGonfalons { get; }
        public BungieSetting[] ClanBannerGonfalonColors { get; }
        public BungieSetting[] ClanBannerGonfalonDetails { get; }
        public BungieSetting[] ClanBannerGonfalonDetailColors { get; }
        public BungieSetting[] ClanBannerStandards { get; }
        public BungieNetDestiny2CoreSettings Destiny2CoreSettings { get; }
        public BungieNetEmailSettings EmailSettings { get; }
        public BungieSetting[] FireteamActivities { get; }

        [JsonConstructor]
        internal BungieNetSettings(string environment, Dictionary<string, BungieSystemSetting> systems, BungieSetting[] ignoreReasons, BungieSetting[] forumCategories,
            BungieSetting[] groupAvatars, BungieSetting[] destinyMembershipTypes, BungieSetting[] recruitmentPlatformTags, BungieSetting[] recruitmentMiscTags,
            BungieSetting[] recruitmentActivities, BungieSetting[] userContentLocales, BungieSetting[] systemContentLocales, BungieSetting[] clanBannerDecals,
            BungieSetting[] clanBannerDecalColors, BungieSetting[] clanBannerGonfalons, BungieSetting[] clanBannerGonfalonColors, BungieSetting[] clanBannerGonfalonDetails,
            BungieSetting[] clanBannerGonfalonDetailColors, BungieSetting[] clanBannerStandards, BungieNetDestiny2CoreSettings destiny2CoreSettings, BungieNetEmailSettings emailSettings,
            BungieSetting[] fireteamActivities)
        {
            Environment = environment;
            Systems = systems;
            IgnoreReasons = ignoreReasons;
            ForumCategories = forumCategories;
            GroupAvatars = groupAvatars;
            DestinyMembershipTypes = destinyMembershipTypes;
            RecruitmentPlatformTags = recruitmentPlatformTags;
            RecruitmentMiscTags = recruitmentMiscTags;
            RecruitmentActivities = recruitmentActivities;
            UserContentLocales = userContentLocales;
            SystemContentLocales = systemContentLocales;
            ClanBannerDecals = clanBannerDecals;
            ClanBannerDecalColors = clanBannerDecalColors;
            ClanBannerGonfalons = clanBannerGonfalons;
            ClanBannerGonfalonColors = clanBannerGonfalonColors;
            ClanBannerGonfalonDetails = clanBannerGonfalonDetails;
            ClanBannerGonfalonDetailColors = clanBannerGonfalonDetailColors;
            ClanBannerStandards = clanBannerStandards;
            Destiny2CoreSettings = destiny2CoreSettings;
            EmailSettings = emailSettings;
            FireteamActivities = fireteamActivities;
        }
    }
}
