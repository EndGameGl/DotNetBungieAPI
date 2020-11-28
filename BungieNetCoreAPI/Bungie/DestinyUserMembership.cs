using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Bungie
{
    /// <summary>
    /// Bungie.net Destiny user membership data
    /// </summary>
    public class DestinyUserMembership
    {
        public string LastSeenDisplayName { get; }
        public int LastSeenDisplayNameType { get; }
        public string IconPath { get; }
        public BungieMembershipType CrossSaveOverride { get; }
        public List<BungieMembershipType> ApplicableMembershipTypes { get; }
        public bool IsPublic { get; }
        public BungieMembershipType MembershipType { get; }
        public string MembershipId { get; }
        public string DisplayName { get; }

        [JsonConstructor]
        private DestinyUserMembership(string LastSeenDisplayName, int LastSeenDisplayNameType, string iconPath, BungieMembershipType crossSaveOverride, List<BungieMembershipType> applicableMembershipTypes,
            bool isPublic, BungieMembershipType membershipType, string membershipId, string displayName)
        {
            this.LastSeenDisplayName = LastSeenDisplayName;
            this.LastSeenDisplayNameType = LastSeenDisplayNameType;
            IconPath = iconPath;
            CrossSaveOverride = crossSaveOverride;
            ApplicableMembershipTypes = applicableMembershipTypes;
            IsPublic = isPublic;
            MembershipType = membershipType;
            MembershipId = membershipId;
            DisplayName = displayName;
        }
    }
}
