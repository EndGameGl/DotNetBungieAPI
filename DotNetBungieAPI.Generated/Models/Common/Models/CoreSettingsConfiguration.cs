namespace DotNetBungieAPI.Generated.Models.Common.Models;

public class CoreSettingsConfiguration : IDeepEquatable<CoreSettingsConfiguration>
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

    public bool DeepEquals(CoreSettingsConfiguration? other)
    {
        return other is not null &&
               Environment == other.Environment &&
               Systems.DeepEqualsDictionary(other.Systems) &&
               IgnoreReasons.DeepEqualsList(other.IgnoreReasons) &&
               ForumCategories.DeepEqualsList(other.ForumCategories) &&
               GroupAvatars.DeepEqualsList(other.GroupAvatars) &&
               DestinyMembershipTypes.DeepEqualsList(other.DestinyMembershipTypes) &&
               RecruitmentPlatformTags.DeepEqualsList(other.RecruitmentPlatformTags) &&
               RecruitmentMiscTags.DeepEqualsList(other.RecruitmentMiscTags) &&
               RecruitmentActivities.DeepEqualsList(other.RecruitmentActivities) &&
               UserContentLocales.DeepEqualsList(other.UserContentLocales) &&
               SystemContentLocales.DeepEqualsList(other.SystemContentLocales) &&
               ClanBannerDecals.DeepEqualsList(other.ClanBannerDecals) &&
               ClanBannerDecalColors.DeepEqualsList(other.ClanBannerDecalColors) &&
               ClanBannerGonfalons.DeepEqualsList(other.ClanBannerGonfalons) &&
               ClanBannerGonfalonColors.DeepEqualsList(other.ClanBannerGonfalonColors) &&
               ClanBannerGonfalonDetails.DeepEqualsList(other.ClanBannerGonfalonDetails) &&
               ClanBannerGonfalonDetailColors.DeepEqualsList(other.ClanBannerGonfalonDetailColors) &&
               ClanBannerStandards.DeepEqualsList(other.ClanBannerStandards) &&
               (Destiny2CoreSettings is not null ? Destiny2CoreSettings.DeepEquals(other.Destiny2CoreSettings) : other.Destiny2CoreSettings is null) &&
               (EmailSettings is not null ? EmailSettings.DeepEquals(other.EmailSettings) : other.EmailSettings is null) &&
               FireteamActivities.DeepEqualsList(other.FireteamActivities);
    }
}