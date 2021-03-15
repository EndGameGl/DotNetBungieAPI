using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Bungie
{
    public class BungieNetSettings
    {
        public string Environment { get; }
        public Dictionary<string, BungieSystemSetting> Systems { get; }
        public ReadOnlyCollection<BungieSetting> IgnoreReasons { get; }
        public ReadOnlyCollection<BungieSetting> ForumCategories { get; }
        public ReadOnlyCollection<BungieSetting> GroupAvatars { get; }
        public ReadOnlyCollection<BungieSetting> DestinyMembershipTypes { get; }
        public ReadOnlyCollection<BungieSetting> RecruitmentPlatformTags { get; }
        public ReadOnlyCollection<BungieSetting> RecruitmentMiscTags { get; }
        public ReadOnlyCollection<BungieSetting> RecruitmentActivities { get; }
        public ReadOnlyCollection<BungieSetting> UserContentLocales { get; }
        public ReadOnlyCollection<BungieSetting> SystemContentLocales { get; }
        public ReadOnlyCollection<BungieSetting> ClanBannerDecals { get; }
        public ReadOnlyCollection<BungieSetting> ClanBannerDecalColors { get; }
        public ReadOnlyCollection<BungieSetting> ClanBannerGonfalons { get; }
        public ReadOnlyCollection<BungieSetting> ClanBannerGonfalonColors { get; }
        public ReadOnlyCollection<BungieSetting> ClanBannerGonfalonDetails { get; }
        public ReadOnlyCollection<BungieSetting> ClanBannerGonfalonDetailColors { get; }
        public ReadOnlyCollection<BungieSetting> ClanBannerStandards { get; }
        public BungieNetDestiny2CoreSettings Destiny2CoreSettings { get; }
        public BungieNetEmailSettings EmailSettings { get; }
        public ReadOnlyCollection<BungieSetting> FireteamActivities { get; }

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
            IgnoreReasons = ignoreReasons.AsReadOnlyOrEmpty();
            ForumCategories = forumCategories.AsReadOnlyOrEmpty();
            GroupAvatars = groupAvatars.AsReadOnlyOrEmpty();
            DestinyMembershipTypes = destinyMembershipTypes.AsReadOnlyOrEmpty();
            RecruitmentPlatformTags = recruitmentPlatformTags.AsReadOnlyOrEmpty();
            RecruitmentMiscTags = recruitmentMiscTags.AsReadOnlyOrEmpty();
            RecruitmentActivities = recruitmentActivities.AsReadOnlyOrEmpty();
            UserContentLocales = userContentLocales.AsReadOnlyOrEmpty();
            SystemContentLocales = systemContentLocales.AsReadOnlyOrEmpty();
            ClanBannerDecals = clanBannerDecals.AsReadOnlyOrEmpty();
            ClanBannerDecalColors = clanBannerDecalColors.AsReadOnlyOrEmpty();
            ClanBannerGonfalons = clanBannerGonfalons.AsReadOnlyOrEmpty();
            ClanBannerGonfalonColors = clanBannerGonfalonColors.AsReadOnlyOrEmpty();
            ClanBannerGonfalonDetails = clanBannerGonfalonDetails.AsReadOnlyOrEmpty();
            ClanBannerGonfalonDetailColors = clanBannerGonfalonDetailColors.AsReadOnlyOrEmpty();
            ClanBannerStandards = clanBannerStandards.AsReadOnlyOrEmpty();
            Destiny2CoreSettings = destiny2CoreSettings;
            EmailSettings = emailSettings;
            FireteamActivities = fireteamActivities.AsReadOnlyOrEmpty();
        }
    }
}
