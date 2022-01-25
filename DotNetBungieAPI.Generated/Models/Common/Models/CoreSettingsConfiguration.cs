namespace DotNetBungieAPI.Generated.Models.Common.Models;

public class CoreSettingsConfiguration
{
    [JsonPropertyName("environment")]
    public string Environment { get; set; }

    [JsonPropertyName("systems")]
    public Dictionary<string, Common.Models.CoreSystem> Systems { get; set; }

    [JsonPropertyName("ignoreReasons")]
    public List<Common.Models.CoreSetting> IgnoreReasons { get; set; }

    [JsonPropertyName("forumCategories")]
    public List<Common.Models.CoreSetting> ForumCategories { get; set; }

    [JsonPropertyName("groupAvatars")]
    public List<Common.Models.CoreSetting> GroupAvatars { get; set; }

    [JsonPropertyName("destinyMembershipTypes")]
    public List<Common.Models.CoreSetting> DestinyMembershipTypes { get; set; }

    [JsonPropertyName("recruitmentPlatformTags")]
    public List<Common.Models.CoreSetting> RecruitmentPlatformTags { get; set; }

    [JsonPropertyName("recruitmentMiscTags")]
    public List<Common.Models.CoreSetting> RecruitmentMiscTags { get; set; }

    [JsonPropertyName("recruitmentActivities")]
    public List<Common.Models.CoreSetting> RecruitmentActivities { get; set; }

    [JsonPropertyName("userContentLocales")]
    public List<Common.Models.CoreSetting> UserContentLocales { get; set; }

    [JsonPropertyName("systemContentLocales")]
    public List<Common.Models.CoreSetting> SystemContentLocales { get; set; }

    [JsonPropertyName("clanBannerDecals")]
    public List<Common.Models.CoreSetting> ClanBannerDecals { get; set; }

    [JsonPropertyName("clanBannerDecalColors")]
    public List<Common.Models.CoreSetting> ClanBannerDecalColors { get; set; }

    [JsonPropertyName("clanBannerGonfalons")]
    public List<Common.Models.CoreSetting> ClanBannerGonfalons { get; set; }

    [JsonPropertyName("clanBannerGonfalonColors")]
    public List<Common.Models.CoreSetting> ClanBannerGonfalonColors { get; set; }

    [JsonPropertyName("clanBannerGonfalonDetails")]
    public List<Common.Models.CoreSetting> ClanBannerGonfalonDetails { get; set; }

    [JsonPropertyName("clanBannerGonfalonDetailColors")]
    public List<Common.Models.CoreSetting> ClanBannerGonfalonDetailColors { get; set; }

    [JsonPropertyName("clanBannerStandards")]
    public List<Common.Models.CoreSetting> ClanBannerStandards { get; set; }

    [JsonPropertyName("destiny2CoreSettings")]
    public Common.Models.Destiny2CoreSettings Destiny2CoreSettings { get; set; }

    [JsonPropertyName("emailSettings")]
    public User.EmailSettings EmailSettings { get; set; }

    [JsonPropertyName("fireteamActivities")]
    public List<Common.Models.CoreSetting> FireteamActivities { get; set; }
}
