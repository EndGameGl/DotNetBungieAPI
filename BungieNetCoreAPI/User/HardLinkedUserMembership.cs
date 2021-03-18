using Newtonsoft.Json;

namespace NetBungieAPI.User
{
    public class HardLinkedUserMembership
    {
        public BungieMembershipType MembershipType { get; }
        public long MembershipId { get; }
        public BungieMembershipType CrossSaveOverriddenType { get; }
        public long? CrossSaveOverriddenMembershipId { get; }

        [JsonConstructor]
        internal HardLinkedUserMembership(BungieMembershipType membershipType, long membershipId, BungieMembershipType CrossSaveOverriddenType,
            long? CrossSaveOverriddenMembershipId)
        {
            MembershipType = membershipType;
            MembershipId = membershipId;
            this.CrossSaveOverriddenType = CrossSaveOverriddenType;
            this.CrossSaveOverriddenMembershipId = CrossSaveOverriddenMembershipId;
        }
    }
}
