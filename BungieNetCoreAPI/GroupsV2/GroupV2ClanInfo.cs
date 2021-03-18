using Newtonsoft.Json;

namespace NetBungieAPI.GroupsV2
{
    public class GroupV2ClanInfo
    {
        public string ClanCallSign { get; }
        public ClanBanner ClanBannerData { get; }

        [JsonConstructor]
        internal GroupV2ClanInfo(string clanCallsign, ClanBanner clanBannerData)
        {
            ClanCallSign = clanCallsign;
            ClanBannerData = clanBannerData;
        }
    }
}
