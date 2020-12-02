using Newtonsoft.Json;

namespace BungieNetCoreAPI.Bungie.Applications
{
    public class BungieNetUserInfo
    {
        public string SupplementalDisplayName { get; }
        public string IconPath { get; }
        public BungieMembershipType CrossSaveOverride { get; }
        public bool IsPublic { get; }
        public BungieMembershipType MembershipType { get; }
        public string MembershipId { get; }
        public string DisplayName { get; }

        [JsonConstructor]
        private BungieNetUserInfo(string supplementalDisplayName, string iconPath, BungieMembershipType crossSaveOverride, bool isPublic, BungieMembershipType membershipType,
            string membershipId, string displayName)
        {
            SupplementalDisplayName = supplementalDisplayName;
            IconPath = iconPath;
            CrossSaveOverride = crossSaveOverride;
            IsPublic = isPublic;
            MembershipType = membershipType;
            MembershipId = membershipId;
            DisplayName = displayName;
        }
    }
}
