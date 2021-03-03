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
        public long MembershipId { get; }
        public string DisplayName { get; }

        [JsonConstructor]
        internal BungieNetUserInfo(string supplementalDisplayName, string iconPath, BungieMembershipType crossSaveOverride, bool isPublic, 
            BungieMembershipType membershipType, long membershipId, string displayName)
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
