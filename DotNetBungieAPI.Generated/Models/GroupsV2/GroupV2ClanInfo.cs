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
}