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

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(CoreSettingsConfiguration? other)
    {
        if (other is null) return;
        if (Environment != other.Environment)
        {
            Environment = other.Environment;
            OnPropertyChanged(nameof(Environment));
        }
        if (!Systems.DeepEqualsDictionary(other.Systems))
        {
            Systems = other.Systems;
            OnPropertyChanged(nameof(Systems));
        }
        if (!IgnoreReasons.DeepEqualsList(other.IgnoreReasons))
        {
            IgnoreReasons = other.IgnoreReasons;
            OnPropertyChanged(nameof(IgnoreReasons));
        }
        if (!ForumCategories.DeepEqualsList(other.ForumCategories))
        {
            ForumCategories = other.ForumCategories;
            OnPropertyChanged(nameof(ForumCategories));
        }
        if (!GroupAvatars.DeepEqualsList(other.GroupAvatars))
        {
            GroupAvatars = other.GroupAvatars;
            OnPropertyChanged(nameof(GroupAvatars));
        }
        if (!DestinyMembershipTypes.DeepEqualsList(other.DestinyMembershipTypes))
        {
            DestinyMembershipTypes = other.DestinyMembershipTypes;
            OnPropertyChanged(nameof(DestinyMembershipTypes));
        }
        if (!RecruitmentPlatformTags.DeepEqualsList(other.RecruitmentPlatformTags))
        {
            RecruitmentPlatformTags = other.RecruitmentPlatformTags;
            OnPropertyChanged(nameof(RecruitmentPlatformTags));
        }
        if (!RecruitmentMiscTags.DeepEqualsList(other.RecruitmentMiscTags))
        {
            RecruitmentMiscTags = other.RecruitmentMiscTags;
            OnPropertyChanged(nameof(RecruitmentMiscTags));
        }
        if (!RecruitmentActivities.DeepEqualsList(other.RecruitmentActivities))
        {
            RecruitmentActivities = other.RecruitmentActivities;
            OnPropertyChanged(nameof(RecruitmentActivities));
        }
        if (!UserContentLocales.DeepEqualsList(other.UserContentLocales))
        {
            UserContentLocales = other.UserContentLocales;
            OnPropertyChanged(nameof(UserContentLocales));
        }
        if (!SystemContentLocales.DeepEqualsList(other.SystemContentLocales))
        {
            SystemContentLocales = other.SystemContentLocales;
            OnPropertyChanged(nameof(SystemContentLocales));
        }
        if (!ClanBannerDecals.DeepEqualsList(other.ClanBannerDecals))
        {
            ClanBannerDecals = other.ClanBannerDecals;
            OnPropertyChanged(nameof(ClanBannerDecals));
        }
        if (!ClanBannerDecalColors.DeepEqualsList(other.ClanBannerDecalColors))
        {
            ClanBannerDecalColors = other.ClanBannerDecalColors;
            OnPropertyChanged(nameof(ClanBannerDecalColors));
        }
        if (!ClanBannerGonfalons.DeepEqualsList(other.ClanBannerGonfalons))
        {
            ClanBannerGonfalons = other.ClanBannerGonfalons;
            OnPropertyChanged(nameof(ClanBannerGonfalons));
        }
        if (!ClanBannerGonfalonColors.DeepEqualsList(other.ClanBannerGonfalonColors))
        {
            ClanBannerGonfalonColors = other.ClanBannerGonfalonColors;
            OnPropertyChanged(nameof(ClanBannerGonfalonColors));
        }
        if (!ClanBannerGonfalonDetails.DeepEqualsList(other.ClanBannerGonfalonDetails))
        {
            ClanBannerGonfalonDetails = other.ClanBannerGonfalonDetails;
            OnPropertyChanged(nameof(ClanBannerGonfalonDetails));
        }
        if (!ClanBannerGonfalonDetailColors.DeepEqualsList(other.ClanBannerGonfalonDetailColors))
        {
            ClanBannerGonfalonDetailColors = other.ClanBannerGonfalonDetailColors;
            OnPropertyChanged(nameof(ClanBannerGonfalonDetailColors));
        }
        if (!ClanBannerStandards.DeepEqualsList(other.ClanBannerStandards))
        {
            ClanBannerStandards = other.ClanBannerStandards;
            OnPropertyChanged(nameof(ClanBannerStandards));
        }
        if (!Destiny2CoreSettings.DeepEquals(other.Destiny2CoreSettings))
        {
            Destiny2CoreSettings.Update(other.Destiny2CoreSettings);
            OnPropertyChanged(nameof(Destiny2CoreSettings));
        }
        if (!EmailSettings.DeepEquals(other.EmailSettings))
        {
            EmailSettings.Update(other.EmailSettings);
            OnPropertyChanged(nameof(EmailSettings));
        }
        if (!FireteamActivities.DeepEqualsList(other.FireteamActivities))
        {
            FireteamActivities = other.FireteamActivities;
            OnPropertyChanged(nameof(FireteamActivities));
        }
    }
}