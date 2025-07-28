namespace DotNetBungieAPI.Generated.Models.Common.Models;

public class CoreSettingsConfiguration
{
    [JsonPropertyName("environment")]
    public string Environment { get; set; }

    [JsonPropertyName("systems")]
    public Dictionary<string, Common.Models.CoreSystem>? Systems { get; set; }

    [JsonPropertyName("ignoreReasons")]
    public Common.Models.CoreSetting[]? IgnoreReasons { get; set; }

    [JsonPropertyName("forumCategories")]
    public Common.Models.CoreSetting[]? ForumCategories { get; set; }

    [JsonPropertyName("groupAvatars")]
    public Common.Models.CoreSetting[]? GroupAvatars { get; set; }

    [JsonPropertyName("defaultGroupTheme")]
    public Common.Models.CoreSetting? DefaultGroupTheme { get; set; }

    [JsonPropertyName("destinyMembershipTypes")]
    public Common.Models.CoreSetting[]? DestinyMembershipTypes { get; set; }

    [JsonPropertyName("recruitmentPlatformTags")]
    public Common.Models.CoreSetting[]? RecruitmentPlatformTags { get; set; }

    [JsonPropertyName("recruitmentMiscTags")]
    public Common.Models.CoreSetting[]? RecruitmentMiscTags { get; set; }

    [JsonPropertyName("recruitmentActivities")]
    public Common.Models.CoreSetting[]? RecruitmentActivities { get; set; }

    [JsonPropertyName("userContentLocales")]
    public Common.Models.CoreSetting[]? UserContentLocales { get; set; }

    [JsonPropertyName("systemContentLocales")]
    public Common.Models.CoreSetting[]? SystemContentLocales { get; set; }

    [JsonPropertyName("clanBannerDecals")]
    public Common.Models.CoreSetting[]? ClanBannerDecals { get; set; }

    [JsonPropertyName("clanBannerDecalColors")]
    public Common.Models.CoreSetting[]? ClanBannerDecalColors { get; set; }

    [JsonPropertyName("clanBannerGonfalons")]
    public Common.Models.CoreSetting[]? ClanBannerGonfalons { get; set; }

    [JsonPropertyName("clanBannerGonfalonColors")]
    public Common.Models.CoreSetting[]? ClanBannerGonfalonColors { get; set; }

    [JsonPropertyName("clanBannerGonfalonDetails")]
    public Common.Models.CoreSetting[]? ClanBannerGonfalonDetails { get; set; }

    [JsonPropertyName("clanBannerGonfalonDetailColors")]
    public Common.Models.CoreSetting[]? ClanBannerGonfalonDetailColors { get; set; }

    [JsonPropertyName("clanBannerStandards")]
    public Common.Models.CoreSetting[]? ClanBannerStandards { get; set; }

    [JsonPropertyName("destiny2CoreSettings")]
    public Common.Models.Destiny2CoreSettings? Destiny2CoreSettings { get; set; }

    [JsonPropertyName("emailSettings")]
    public User.EmailSettings? EmailSettings { get; set; }

    [JsonPropertyName("fireteamActivities")]
    public Common.Models.CoreSetting[]? FireteamActivities { get; set; }
}
