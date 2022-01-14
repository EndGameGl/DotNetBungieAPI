namespace DotNetBungieAPI.Generated.Models.GroupsV2;

/// <summary>
///     The same as GroupV2ClanInfo, but includes any investment data.
/// </summary>
public sealed class GroupV2ClanInfoAndInvestment
{

    [JsonPropertyName("d2ClanProgressions")]
    public Dictionary<uint, Destiny.DestinyProgression> D2ClanProgressions { get; init; }

    [JsonPropertyName("clanCallsign")]
    public string ClanCallsign { get; init; }

    [JsonPropertyName("clanBannerData")]
    public GroupsV2.ClanBanner ClanBannerData { get; init; }
}
