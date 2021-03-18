using NetBungieAPI.GroupsV2;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.User
{
    public class UserMembershipData
    {
        public ReadOnlyCollection<GroupUserInfoCard> DestinyMemberships { get; }
        public long? PrimaryMembershipId { get; }
        public GeneralUser BungieNetUser { get; }

        [JsonConstructor]
        internal UserMembershipData(GroupUserInfoCard[] destinyMemberships, long? primaryMembershipId, GeneralUser bungieNetUser)
        {
            DestinyMemberships = destinyMemberships.AsReadOnlyOrEmpty();
            PrimaryMembershipId = primaryMembershipId;
            BungieNetUser = bungieNetUser;
        }
    }
}
