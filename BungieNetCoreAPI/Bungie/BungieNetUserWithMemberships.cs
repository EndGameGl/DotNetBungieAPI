using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Bungie
{
    public class BungieNetUserWithMemberships
    {
        public List<DestinyUserMembership> DestinyMemberships { get; }
        public BungieNetUser BungieNetUser { get; }

        [JsonConstructor]
        private BungieNetUserWithMemberships(List<DestinyUserMembership> destinyMemberships, BungieNetUser bungieNetUser)
        {
            DestinyMemberships = destinyMemberships;
            BungieNetUser = bungieNetUser;
        }
    }
}
