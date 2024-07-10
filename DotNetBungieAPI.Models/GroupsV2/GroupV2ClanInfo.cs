namespace DotNetBungieAPI.Models.GroupsV2;

/// <summary>
///     This contract contains clan-specific group information. It does not include any investment data.
/// </summary>
public record GroupV2ClanInfo
{
    [JsonPropertyName("clanCallsign")]
    public string ClanCallSign { get; init; }

    [JsonPropertyName("clanBannerData")]
    public ClanBanner ClanBannerData { get; init; }
}
