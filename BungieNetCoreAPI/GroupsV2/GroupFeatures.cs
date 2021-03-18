using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.GroupsV2
{
    public class GroupFeatures
    {
        public int MaximumMembers { get; }
        public int MaximumMembershipsOfGroupType { get; }
        public Capabilities Capabilities { get; }
        public ReadOnlyCollection<BungieMembershipType> MembershipTypes { get; }
        public bool InvitePermissionOverride { get; }
        public bool UpdateCulturePermissionOverride { get; }
        public HostGuidedGamesPermissionLevel HostGuidedGamePermissionOverride { get; }
        public bool UpdateBannerPermissionOverride { get; }
        public int JoinLevel { get; }

        [JsonConstructor]
        internal GroupFeatures(int maximumMembers, int maximumMembershipsOfGroupType, Capabilities capabilities, BungieMembershipType[] membershipTypes,
            bool invitePermissionOverride, bool updateCulturePermissionOverride, HostGuidedGamesPermissionLevel hostGuidedGamePermissionOverride,
            bool updateBannerPermissionOverride, int joinLevel)
        {
            MaximumMembers = maximumMembers;
            MaximumMembershipsOfGroupType = maximumMembershipsOfGroupType;
            Capabilities = capabilities;
            MembershipTypes = membershipTypes.AsReadOnlyOrEmpty();
            InvitePermissionOverride = invitePermissionOverride;
            UpdateCulturePermissionOverride = updateCulturePermissionOverride;
            HostGuidedGamePermissionOverride = hostGuidedGamePermissionOverride;
            UpdateBannerPermissionOverride = updateBannerPermissionOverride;
            JoinLevel = joinLevel;
        }
    }
}
