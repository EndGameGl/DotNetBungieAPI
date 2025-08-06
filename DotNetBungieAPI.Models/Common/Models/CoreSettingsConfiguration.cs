namespace DotNetBungieAPI.Models.Common.Models;

public sealed class CoreSettingsConfiguration
{
    [JsonPropertyName("environment")]
    public string Environment { get; init; }

    [JsonPropertyName("systems")]
    public Dictionary<string, Common.Models.CoreSystem>? Systems { get; init; }

    [JsonPropertyName("ignoreReasons")]
    public Common.Models.CoreSetting[]? IgnoreReasons { get; init; }

    [JsonPropertyName("forumCategories")]
    public Common.Models.CoreSetting[]? ForumCategories { get; init; }

    [JsonPropertyName("groupAvatars")]
    public Common.Models.CoreSetting[]? GroupAvatars { get; init; }

    [JsonPropertyName("defaultGroupTheme")]
    public Common.Models.CoreSetting? DefaultGroupTheme { get; init; }

    [JsonPropertyName("destinyMembershipTypes")]
    public Common.Models.CoreSetting[]? DestinyMembershipTypes { get; init; }

    [JsonPropertyName("recruitmentPlatformTags")]
    public Common.Models.CoreSetting[]? RecruitmentPlatformTags { get; init; }

    [JsonPropertyName("recruitmentMiscTags")]
    public Common.Models.CoreSetting[]? RecruitmentMiscTags { get; init; }

    [JsonPropertyName("recruitmentActivities")]
    public Common.Models.CoreSetting[]? RecruitmentActivities { get; init; }

    [JsonPropertyName("userContentLocales")]
    public Common.Models.CoreSetting[]? UserContentLocales { get; init; }

    [JsonPropertyName("systemContentLocales")]
    public Common.Models.CoreSetting[]? SystemContentLocales { get; init; }

    [JsonPropertyName("clanBannerDecals")]
    public Common.Models.CoreSetting[]? ClanBannerDecals { get; init; }

    [JsonPropertyName("clanBannerDecalColors")]
    public Common.Models.CoreSetting[]? ClanBannerDecalColors { get; init; }

    [JsonPropertyName("clanBannerGonfalons")]
    public Common.Models.CoreSetting[]? ClanBannerGonfalons { get; init; }

    [JsonPropertyName("clanBannerGonfalonColors")]
    public Common.Models.CoreSetting[]? ClanBannerGonfalonColors { get; init; }

    [JsonPropertyName("clanBannerGonfalonDetails")]
    public Common.Models.CoreSetting[]? ClanBannerGonfalonDetails { get; init; }

    [JsonPropertyName("clanBannerGonfalonDetailColors")]
    public Common.Models.CoreSetting[]? ClanBannerGonfalonDetailColors { get; init; }

    [JsonPropertyName("clanBannerStandards")]
    public Common.Models.CoreSetting[]? ClanBannerStandards { get; init; }

    [JsonPropertyName("destiny2CoreSettings")]
    public Common.Models.Destiny2CoreSettings? Destiny2CoreSettings { get; init; }

    [JsonPropertyName("emailSettings")]
    public User.EmailSettings? EmailSettings { get; init; }

    [JsonPropertyName("fireteamActivities")]
    public Common.Models.CoreSetting[]? FireteamActivities { get; init; }
}
