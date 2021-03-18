using NetBungieAPI.User;
using Newtonsoft.Json;

namespace NetBungieAPI.GroupsV2
{
    public class GroupUserInfoCard : UserInfoCard
    {
        public string LastSeenDisplayName { get; }
        public int LastSeenDisplayNameType { get; }

        [JsonConstructor]
        internal GroupUserInfoCard(string LastSeenDisplayName, int LastSeenDisplayNameType, string supplementalDisplayName, 
            string iconPath, BungieMembershipType crossSaveOverride, BungieMembershipType[] applicableMembershipTypes,
            bool isPublic, BungieMembershipType membershipType, long membershipId, string displayName)
            : base(supplementalDisplayName, iconPath, crossSaveOverride, applicableMembershipTypes, isPublic, membershipType, membershipId, displayName)
        {
            this.LastSeenDisplayName = LastSeenDisplayName;
            this.LastSeenDisplayNameType = LastSeenDisplayNameType;
        }
    }
}
