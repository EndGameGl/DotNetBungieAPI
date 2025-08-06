namespace DotNetBungieAPI.Models.GroupsV2;

/// <summary>
///     This contract contains clan-specific group information. It does not include any investment data.
/// </summary>
public sealed class GroupV2ClanInfo
{
    [JsonPropertyName("clanCallsign")]
    public string ClanCallsign { get; init; }

    [JsonPropertyName("clanBannerData")]
    public GroupsV2.ClanBanner? ClanBannerData { get; init; }
}
