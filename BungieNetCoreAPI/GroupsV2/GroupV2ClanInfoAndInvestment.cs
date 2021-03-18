using NetBungieAPI.Destiny.Profile.Components.Contracts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.GroupsV2
{
    public class GroupV2ClanInfoAndInvestment : GroupV2ClanInfo
    {
        public ReadOnlyDictionary<uint, DestinyProgression> D2ClanProgressions { get; }

        [JsonConstructor]
        internal GroupV2ClanInfoAndInvestment(Dictionary<uint, DestinyProgression> d2ClanProgressions, string clanCallsign, ClanBanner clanBannerData)
            : base (clanCallsign, clanBannerData)
        {
            D2ClanProgressions = d2ClanProgressions.AsReadOnlyDictionaryOrEmpty();
        }
    }
}
