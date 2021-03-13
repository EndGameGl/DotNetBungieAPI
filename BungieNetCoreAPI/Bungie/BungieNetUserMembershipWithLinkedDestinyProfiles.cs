using NetBungieApi.Bungie.Applications;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieApi.Bungie
{
    public class BungieNetUserMembershipWithLinkedDestinyProfiles
    {
        public ReadOnlyCollection<DestinyUserMembership> Profiles { get; }
        public BungieNetUserInfo BungieNetMembership { get; }

        [JsonConstructor]
        internal BungieNetUserMembershipWithLinkedDestinyProfiles(DestinyUserMembership[] profiles, BungieNetUserInfo bnetMembership)
        {
            Profiles = profiles.AsReadOnlyOrEmpty();
            BungieNetMembership = bnetMembership;
        }
    }
}
