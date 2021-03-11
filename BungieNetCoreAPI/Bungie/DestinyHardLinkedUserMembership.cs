using Newtonsoft.Json;

namespace BungieNetCoreAPI.Bungie
{
    public class DestinyHardLinkedUserMembership
    {
        public BungieMembershipType MembershipType { get; }
        public string MembershipId { get; }
        public BungieMembershipType CrossSaveOverriddenType { get; }

        [JsonConstructor]
        internal DestinyHardLinkedUserMembership(BungieMembershipType membershipType, string membershipId, BungieMembershipType CrossSaveOverriddenType)
        {
            MembershipType = membershipType;
            MembershipId = membershipId;
            this.CrossSaveOverriddenType = CrossSaveOverriddenType;
        }
    }
}
