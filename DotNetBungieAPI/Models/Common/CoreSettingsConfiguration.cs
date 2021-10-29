using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Defaults;
using DotNetBungieAPI.Models.User;

namespace DotNetBungieAPI.Models.Common
{
    public sealed record CoreSettingsConfiguration
    {
        [JsonPropertyName("environment")] public string Environment { get; init; }

        [JsonPropertyName("systems")]
        public ReadOnlyDictionary<string, CoreSystem> Systems { get; init; } =
            ReadOnlyDictionaries<string, CoreSystem>.Empty;

        [JsonPropertyName("ignoreReasons")]
        public ReadOnlyCollection<CoreSetting> IgnoreReasons { get; init; } = ReadOnlyCollections<CoreSetting>.Empty;

        [JsonPropertyName("forumCategories")]
        public ReadOnlyCollection<CoreSetting> ForumCategories { get; init; } = ReadOnlyCollections<CoreSetting>.Empty;

        [JsonPropertyName("groupAvatars")]
        public ReadOnlyCollection<CoreSetting> GroupAvatars { get; init; } = ReadOnlyCollections<CoreSetting>.Empty;

        [JsonPropertyName("destinyMembershipTypes")]
        public ReadOnlyCollection<CoreSetting> DestinyMembershipTypes { get; init; } =
            ReadOnlyCollections<CoreSetting>.Empty;

        [JsonPropertyName("recruitmentPlatformTags")]
        public ReadOnlyCollection<CoreSetting> RecruitmentPlatformTags { get; init; } =
            ReadOnlyCollections<CoreSetting>.Empty;

        [JsonPropertyName("recruitmentMiscTags")]
        public ReadOnlyCollection<CoreSetting> RecruitmentMiscTags { get; init; } =
            ReadOnlyCollections<CoreSetting>.Empty;

        [JsonPropertyName("recruitmentActivities")]
        public ReadOnlyCollection<CoreSetting> RecruitmentActivities { get; init; } =
            ReadOnlyCollections<CoreSetting>.Empty;

        [JsonPropertyName("userContentLocales")]
        public ReadOnlyCollection<CoreSetting> UserContentLocales { get; init; } =
            ReadOnlyCollections<CoreSetting>.Empty;

        [JsonPropertyName("systemContentLocales")]
        public ReadOnlyCollection<CoreSetting> SystemContentLocales { get; init; } =
            ReadOnlyCollections<CoreSetting>.Empty;

        [JsonPropertyName("clanBannerDecals")]
        public ReadOnlyCollection<CoreSetting> ClanBannerDecals { get; init; } = ReadOnlyCollections<CoreSetting>.Empty;

        [JsonPropertyName("clanBannerDecalColors")]
        public ReadOnlyCollection<CoreSetting> ClanBannerDecalColors { get; init; } =
            ReadOnlyCollections<CoreSetting>.Empty;

        [JsonPropertyName("clanBannerGonfalons")]
        public ReadOnlyCollection<CoreSetting> ClanBannerGonfalons { get; init; } =
            ReadOnlyCollections<CoreSetting>.Empty;

        [JsonPropertyName("clanBannerGonfalonColors")]
        public ReadOnlyCollection<CoreSetting> ClanBannerGonfalonColors { get; init; } =
            ReadOnlyCollections<CoreSetting>.Empty;

        [JsonPropertyName("clanBannerGonfalonDetails")]
        public ReadOnlyCollection<CoreSetting> ClanBannerGonfalonDetails { get; init; } =
            ReadOnlyCollections<CoreSetting>.Empty;

        [JsonPropertyName("clanBannerGonfalonDetailColors")]
        public ReadOnlyCollection<CoreSetting> ClanBannerGonfalonDetailColors { get; init; } =
            ReadOnlyCollections<CoreSetting>.Empty;

        [JsonPropertyName("clanBannerStandards")]
        public ReadOnlyCollection<CoreSetting> ClanBannerStandards { get; init; } =
            ReadOnlyCollections<CoreSetting>.Empty;

        [JsonPropertyName("destiny2CoreSettings")]
        public Destiny2CoreSettings Destiny2CoreSettings { get; init; }

        [JsonPropertyName("emailSettings")] public EmailSettings EmailSettings { get; init; }

        [JsonPropertyName("fireteamActivities")]
        public ReadOnlyCollection<CoreSetting> FireteamActivities { get; init; } =
            ReadOnlyCollections<CoreSetting>.Empty;
    }
}