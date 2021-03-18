using NetBungieAPI.User;
using Newtonsoft.Json;

namespace NetBungieAPI.Fireteam
{
    public class FireteamUserInfoCard : UserInfoCard
    {
        public string FireteamDisplayName { get; }
        public int FireteamMembershipType { get; }
        public string FireteamPlatformProfileUrl { get; }
        public string FireteamPlatformUniqueIdentifier { get; }

        [JsonConstructor]
        internal FireteamUserInfoCard(string FireteamDisplayName, int FireteamMembershipType, string FireteamPlatformProfileUrl, string FireteamPlatformUniqueIdentifier,
            string supplementalDisplayName, string iconPath, BungieMembershipType crossSaveOverride, BungieMembershipType[] applicableMembershipTypes, 
            bool isPublic, BungieMembershipType membershipType, long membershipId, string displayName) : 
            base(supplementalDisplayName, iconPath, crossSaveOverride, applicableMembershipTypes, isPublic, membershipType, membershipId, displayName)
        {
            this.FireteamDisplayName = FireteamDisplayName;
            this.FireteamMembershipType = FireteamMembershipType;
            this.FireteamPlatformProfileUrl = FireteamPlatformProfileUrl;
            this.FireteamPlatformUniqueIdentifier = FireteamPlatformUniqueIdentifier;
        }
    }
}
