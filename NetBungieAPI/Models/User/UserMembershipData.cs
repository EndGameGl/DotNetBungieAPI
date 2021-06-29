using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.GroupsV2;

namespace NetBungieAPI.Models.User
{
    public sealed record UserMembershipData
    {
        /// <summary>
        ///     this allows you to see destiny memberships that are visible and linked to this account (regardless of whether or
        ///     not they have characters on the world server)
        /// </summary>
        [JsonPropertyName("destinyMemberships")]
        public ReadOnlyCollection<GroupUserInfoCard> DestinyMemberships { get; init; } =
            Defaults.EmptyReadOnlyCollection<GroupUserInfoCard>();

        /// <summary>
        ///     If this property is populated, it will have the membership ID of the account considered to be "primary" in this
        ///     user's cross save relationship.
        ///     <para />
        ///     If null, this user has no cross save relationship, nor primary account.
        /// </summary>
        [JsonPropertyName("primaryMembershipId")]
        public long? PrimaryMembershipId { get; init; }

        /// <summary>
        /// </summary>
        [JsonPropertyName("bungieNetUser")]
        public GeneralUser BungieNetUser { get; init; }

        /// <summary>
        ///     Gets primary membership for this account.
        /// </summary>
        /// <returns></returns>
        public GroupUserInfoCard GetDestinyPrimaryMembership()
        {
            return PrimaryMembershipId.HasValue
                ? DestinyMemberships.Single(x => x.MembershipId == PrimaryMembershipId.Value)
                : DestinyMemberships.Single();
        }
    }
}