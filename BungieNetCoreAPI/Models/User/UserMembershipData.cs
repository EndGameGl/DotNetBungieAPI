using NetBungieAPI.Models.GroupsV2;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.User
{
    public sealed record UserMembershipData
    {
        [JsonPropertyName("destinyMemberships")]
        public ReadOnlyCollection<GroupUserInfoCard> DestinyMemberships { get; init; } = Defaults.EmptyReadOnlyCollection<GroupUserInfoCard>();

        [JsonPropertyName("primaryMembershipId")]
        public long? PrimaryMembershipId { get; init; }

        [JsonPropertyName("bungieNetUser")]
        public GeneralUser BungieNetUser { get; init; }
    }
}
