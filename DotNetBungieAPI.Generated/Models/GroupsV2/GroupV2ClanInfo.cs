namespace DotNetBungieAPI.Generated.Models.GroupsV2;

/// <summary>
///     This contract contains clan-specific group information. It does not include any investment data.
/// </summary>
public class GroupV2ClanInfo
{
    [JsonPropertyName("clanCallsign")]
    public string ClanCallsign { get; set; }

    [JsonPropertyName("clanBannerData")]
    public GroupsV2.ClanBanner? ClanBannerData { get; set; }
}
