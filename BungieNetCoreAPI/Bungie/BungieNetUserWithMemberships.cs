using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Bungie
{
    public class BungieNetUserWithMemberships
    {
        public ReadOnlyCollection<DestinyUserMembership> DestinyMemberships { get; }
        public BungieNetUser BungieNetUser { get; }
        public long? PrimaryMembershipId { get; }

        [JsonConstructor]
        internal BungieNetUserWithMemberships(DestinyUserMembership[] destinyMemberships, BungieNetUser bungieNetUser, long? primaryMembershipId)
        {
            DestinyMemberships = destinyMemberships.AsReadOnlyOrEmpty();
            BungieNetUser = bungieNetUser;
            PrimaryMembershipId = primaryMembershipId;
        }
    }
}
