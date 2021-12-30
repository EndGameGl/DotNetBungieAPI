using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Common.Models;

public sealed class CoreSettingsConfiguration
{

    [JsonPropertyName("environment")]
    public string Environment { get; init; }

    [JsonPropertyName("systems")]
    public Dictionary<string, Common.Models.CoreSystem> Systems { get; init; }

    [JsonPropertyName("ignoreReasons")]
    public List<Common.Models.CoreSetting> IgnoreReasons { get; init; }

    [JsonPropertyName("forumCategories")]
    public List<Common.Models.CoreSetting> ForumCategories { get; init; }

    [JsonPropertyName("groupAvatars")]
    public List<Common.Models.CoreSetting> GroupAvatars { get; init; }

    [JsonPropertyName("destinyMembershipTypes")]
    public List<Common.Models.CoreSetting> DestinyMembershipTypes { get; init; }

    [JsonPropertyName("recruitmentPlatformTags")]
    public List<Common.Models.CoreSetting> RecruitmentPlatformTags { get; init; }

    [JsonPropertyName("recruitmentMiscTags")]
    public List<Common.Models.CoreSetting> RecruitmentMiscTags { get; init; }

    [JsonPropertyName("recruitmentActivities")]
    public List<Common.Models.CoreSetting> RecruitmentActivities { get; init; }

    [JsonPropertyName("userContentLocales")]
    public List<Common.Models.CoreSetting> UserContentLocales { get; init; }

    [JsonPropertyName("systemContentLocales")]
    public List<Common.Models.CoreSetting> SystemContentLocales { get; init; }

    [JsonPropertyName("clanBannerDecals")]
    public List<Common.Models.CoreSetting> ClanBannerDecals { get; init; }

    [JsonPropertyName("clanBannerDecalColors")]
    public List<Common.Models.CoreSetting> ClanBannerDecalColors { get; init; }

    [JsonPropertyName("clanBannerGonfalons")]
    public List<Common.Models.CoreSetting> ClanBannerGonfalons { get; init; }

    [JsonPropertyName("clanBannerGonfalonColors")]
    public List<Common.Models.CoreSetting> ClanBannerGonfalonColors { get; init; }

    [JsonPropertyName("clanBannerGonfalonDetails")]
    public List<Common.Models.CoreSetting> ClanBannerGonfalonDetails { get; init; }

    [JsonPropertyName("clanBannerGonfalonDetailColors")]
    public List<Common.Models.CoreSetting> ClanBannerGonfalonDetailColors { get; init; }

    [JsonPropertyName("clanBannerStandards")]
    public List<Common.Models.CoreSetting> ClanBannerStandards { get; init; }

    [JsonPropertyName("destiny2CoreSettings")]
    public Common.Models.Destiny2CoreSettings Destiny2CoreSettings { get; init; }

    [JsonPropertyName("emailSettings")]
    public User.EmailSettings EmailSettings { get; init; }

    [JsonPropertyName("fireteamActivities")]
    public List<Common.Models.CoreSetting> FireteamActivities { get; init; }
}
