namespace DotNetBungieAPI.Generated.Models.GroupsV2;

/// <summary>
///     This contract contains clan-specific group information. It does not include any investment data.
/// </summary>
public class GroupV2ClanInfo : IDeepEquatable<GroupV2ClanInfo>
{
    [JsonPropertyName("clanCallsign")]
    public string ClanCallsign { get; set; }

    [JsonPropertyName("clanBannerData")]
    public GroupsV2.ClanBanner ClanBannerData { get; set; }

    public bool DeepEquals(GroupV2ClanInfo? other)
    {
        return other is not null &&
               ClanCallsign == other.ClanCallsign &&
               (ClanBannerData is not null ? ClanBannerData.DeepEquals(other.ClanBannerData) : other.ClanBannerData is null);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(GroupV2ClanInfo? other)
    {
        if (other is null) return;
        if (ClanCallsign != other.ClanCallsign)
        {
            ClanCallsign = other.ClanCallsign;
            OnPropertyChanged(nameof(ClanCallsign));
        }
        if (!ClanBannerData.DeepEquals(other.ClanBannerData))
        {
            ClanBannerData.Update(other.ClanBannerData);
            OnPropertyChanged(nameof(ClanBannerData));
        }
    }
}