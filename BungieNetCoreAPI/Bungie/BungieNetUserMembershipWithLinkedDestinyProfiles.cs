using BungieNetCoreAPI.Bungie.Applications;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Bungie
{
    public class BungieNetUserMembershipWithLinkedDestinyProfiles
    {
        public List<DestinyUserMembership> Profiles { get; }
        public BungieNetUserInfo BungieNetMembership { get; }

        [JsonConstructor]
        private BungieNetUserMembershipWithLinkedDestinyProfiles(List<DestinyUserMembership> profiles, BungieNetUserInfo bnetMembership)
        {
            Profiles = profiles;
            BungieNetMembership = bnetMembership;
        }
    }
}
