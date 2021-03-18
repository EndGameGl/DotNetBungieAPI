using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.User
{
    public class UserInfoCard
    {
        public string SupplementalDisplayName { get; }
        public string IconPath { get; }
        public BungieMembershipType CrossSaveOverride { get; }
        public ReadOnlyCollection<BungieMembershipType> ApplicableMembershipTypes { get; }
        public bool IsPublic { get; }
        public BungieMembershipType MembershipType { get; }
        public long MembershipId { get; }
        public string DisplayName { get; }

        [JsonConstructor]
        internal UserInfoCard(string supplementalDisplayName, string iconPath, BungieMembershipType crossSaveOverride, BungieMembershipType[] applicableMembershipTypes, 
            bool isPublic, BungieMembershipType membershipType, long membershipId, string displayName)
        {
            SupplementalDisplayName = supplementalDisplayName;
            IconPath = iconPath;
            CrossSaveOverride = crossSaveOverride;
            ApplicableMembershipTypes = applicableMembershipTypes.AsReadOnlyOrEmpty();
            IsPublic = isPublic;
            MembershipType = membershipType;
            MembershipId = membershipId;
            DisplayName = displayName;
        }
    }
}
