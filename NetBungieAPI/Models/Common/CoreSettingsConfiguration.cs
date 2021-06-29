using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.User;

namespace NetBungieAPI.Models.Common
{
    public sealed record CoreSettingsConfiguration
    {
        [JsonPropertyName("environment")] public string Environment { get; init; }

        [JsonPropertyName("systems")]
        public ReadOnlyDictionary<string, CoreSystem> Systems { get; init; } =
            Defaults.EmptyReadOnlyDictionary<string, CoreSystem>();

        [JsonPropertyName("ignoreReasons")]
        public ReadOnlyCollection<CoreSetting> IgnoreReasons { get; init; } =
            Defaults.EmptyReadOnlyCollection<CoreSetting>();

        [JsonPropertyName("forumCategories")]
        public ReadOnlyCollection<CoreSetting> ForumCategories { get; init; } =
            Defaults.EmptyReadOnlyCollection<CoreSetting>();

        [JsonPropertyName("groupAvatars")]
        public ReadOnlyCollection<CoreSetting> GroupAvatars { get; init; } =
            Defaults.EmptyReadOnlyCollection<CoreSetting>();

        [JsonPropertyName("destinyMembershipTypes")]
        public ReadOnlyCollection<CoreSetting> DestinyMembershipTypes { get; init; } =
            Defaults.EmptyReadOnlyCollection<CoreSetting>();

        [JsonPropertyName("recruitmentPlatformTags")]
        public ReadOnlyCollection<CoreSetting> RecruitmentPlatformTags { get; init; } =
            Defaults.EmptyReadOnlyCollection<CoreSetting>();

        [JsonPropertyName("recruitmentMiscTags")]
        public ReadOnlyCollection<CoreSetting> RecruitmentMiscTags { get; init; } =
            Defaults.EmptyReadOnlyCollection<CoreSetting>();

        [JsonPropertyName("recruitmentActivities")]
        public ReadOnlyCollection<CoreSetting> RecruitmentActivities { get; init; } =
            Defaults.EmptyReadOnlyCollection<CoreSetting>();

        [JsonPropertyName("userContentLocales")]
        public ReadOnlyCollection<CoreSetting> UserContentLocales { get; init; } =
            Defaults.EmptyReadOnlyCollection<CoreSetting>();

        [JsonPropertyName("systemContentLocales")]
        public ReadOnlyCollection<CoreSetting> SystemContentLocales { get; init; } =
            Defaults.EmptyReadOnlyCollection<CoreSetting>();

        [JsonPropertyName("clanBannerDecals")]
        public ReadOnlyCollection<CoreSetting> ClanBannerDecals { get; init; } =
            Defaults.EmptyReadOnlyCollection<CoreSetting>();

        [JsonPropertyName("clanBannerDecalColors")]
        public ReadOnlyCollection<CoreSetting> ClanBannerDecalColors { get; init; } =
            Defaults.EmptyReadOnlyCollection<CoreSetting>();

        [JsonPropertyName("clanBannerGonfalons")]
        public ReadOnlyCollection<CoreSetting> ClanBannerGonfalons { get; init; } =
            Defaults.EmptyReadOnlyCollection<CoreSetting>();

        [JsonPropertyName("clanBannerGonfalonColors")]
        public ReadOnlyCollection<CoreSetting> ClanBannerGonfalonColors { get; init; } =
            Defaults.EmptyReadOnlyCollection<CoreSetting>();

        [JsonPropertyName("clanBannerGonfalonDetails")]
        public ReadOnlyCollection<CoreSetting> ClanBannerGonfalonDetails { get; init; } =
            Defaults.EmptyReadOnlyCollection<CoreSetting>();

        [JsonPropertyName("clanBannerGonfalonDetailColors")]
        public ReadOnlyCollection<CoreSetting> ClanBannerGonfalonDetailColors { get; init; } =
            Defaults.EmptyReadOnlyCollection<CoreSetting>();

        [JsonPropertyName("clanBannerStandards")]
        public ReadOnlyCollection<CoreSetting> ClanBannerStandards { get; init; } =
            Defaults.EmptyReadOnlyCollection<CoreSetting>();

        [JsonPropertyName("destiny2CoreSettings")]
        public Destiny2CoreSettings Destiny2CoreSettings { get; init; }

        [JsonPropertyName("emailSettings")] public EmailSettings EmailSettings { get; init; }

        [JsonPropertyName("fireteamActivities")]
        public ReadOnlyCollection<CoreSetting> FireteamActivities { get; init; } =
            Defaults.EmptyReadOnlyCollection<CoreSetting>();
    }
}