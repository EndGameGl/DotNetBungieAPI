namespace DotNetBungieAPI.Generated.Models.GroupsV2;

/// <summary>
///     The same as GroupV2ClanInfo, but includes any investment data.
/// </summary>
public class GroupV2ClanInfoAndInvestment : IDeepEquatable<GroupV2ClanInfoAndInvestment>
{
    [JsonPropertyName("d2ClanProgressions")]
    public Dictionary<uint, Destiny.DestinyProgression> D2ClanProgressions { get; set; }

    [JsonPropertyName("clanCallsign")]
    public string ClanCallsign { get; set; }

    [JsonPropertyName("clanBannerData")]
    public GroupsV2.ClanBanner ClanBannerData { get; set; }

    public bool DeepEquals(GroupV2ClanInfoAndInvestment? other)
    {
        return other is not null &&
               D2ClanProgressions.DeepEqualsDictionary(other.D2ClanProgressions) &&
               ClanCallsign == other.ClanCallsign &&
               (ClanBannerData is not null ? ClanBannerData.DeepEquals(other.ClanBannerData) : other.ClanBannerData is null);
    }
}