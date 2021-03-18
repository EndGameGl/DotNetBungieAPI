using NetBungieAPI.Bungie.Applications;
using NetBungieAPI.User;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Bungie
{
    public class DestinyLinkedProfilesResponse
    {
        public ReadOnlyCollection<UserInfoCard> Profiles { get; }
        public BungieNetUserInfo BungieNetMembership { get; }

        [JsonConstructor]
        internal DestinyLinkedProfilesResponse(UserInfoCard[] profiles, BungieNetUserInfo bnetMembership)
        {
            Profiles = profiles.AsReadOnlyOrEmpty();
            BungieNetMembership = bnetMembership;
        }
    }
}
