using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public sealed class GroupV2ClanInfo
{

    [JsonPropertyName("clanCallsign")]
    public string ClanCallsign { get; init; }

    [JsonPropertyName("clanBannerData")]
    public GroupsV2.ClanBanner ClanBannerData { get; init; }
}
