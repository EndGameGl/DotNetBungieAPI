using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.GroupsV2;

namespace NetBungieAPI.Models.User
{
    public sealed record UserPrefixSearchResultEntry
    {
        [JsonPropertyName("destinyMemberships")]
        public ReadOnlyCollection<GroupUserInfoCard> DestinyMemberships { get; init; } =
            Defaults.EmptyReadOnlyCollection<GroupUserInfoCard>();

        [JsonPropertyName("bungieGlobalDisplayName")]
        public string BungieGlobalDisplayName { get; init; }

        [JsonPropertyName("bungieGlobalDisplayNameCode")]
        public short BungieGlobalDisplayNameCode { get; init; }

        [JsonPropertyName("bungieNetMembershipId")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public long BungieNetMembershipId { get; init; }
    }
}