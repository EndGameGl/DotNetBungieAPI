using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.GroupsV2
{
    public record GroupV2ClanInfo
    {
        [JsonPropertyName("clanCallsign")]
        public string ClanCallSign { get; init; }

        [JsonPropertyName("clanBannerData")]
        public ClanBanner ClanBannerData { get; init; }
    }
}
