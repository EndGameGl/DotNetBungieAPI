using NetBungieAPI.Models.User;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Bungie
{
    public class DestinyLinkedProfilesResponse
    {
        public ReadOnlyCollection<UserInfoCard> Profiles { get; }
        public UserInfoCard BungieNetMembership { get; }

        [JsonConstructor]
        internal DestinyLinkedProfilesResponse(UserInfoCard[] profiles, UserInfoCard bnetMembership)
        {
            Profiles = profiles.AsReadOnlyOrEmpty();
            BungieNetMembership = bnetMembership;
        }
    }
}
