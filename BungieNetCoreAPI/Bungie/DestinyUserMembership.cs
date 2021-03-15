using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Bungie
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
        public ReadOnlyCollection<BungieMembershipType> ApplicableMembershipTypes { get; }
        public bool IsPublic { get; }
        public BungieMembershipType MembershipType { get; }
        public long MembershipId { get; }
        public string DisplayName { get; }

        [JsonConstructor]
        internal DestinyUserMembership(string LastSeenDisplayName, int LastSeenDisplayNameType, string iconPath, BungieMembershipType crossSaveOverride, BungieMembershipType[] applicableMembershipTypes,
            bool isPublic, BungieMembershipType membershipType, long membershipId, string displayName)
        {
            this.LastSeenDisplayName = LastSeenDisplayName;
            this.LastSeenDisplayNameType = LastSeenDisplayNameType;
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
