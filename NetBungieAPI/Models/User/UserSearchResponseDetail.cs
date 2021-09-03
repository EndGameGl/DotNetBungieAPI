using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.GroupsV2;

namespace NetBungieAPI.Models.User
{
    public sealed record UserSearchResponseDetail
    {
        [JsonPropertyName("destinyMemberships")]
        public ReadOnlyCollection<UserInfoCard> DestinyMemberships { get; init; } =
            Defaults.EmptyReadOnlyCollection<UserInfoCard>();

        [JsonPropertyName("bungieGlobalDisplayName")]
        public string BungieGlobalDisplayName { get; init; }

        [JsonPropertyName("bungieGlobalDisplayNameCode")]
        public short BungieGlobalDisplayNameCode { get; init; }

        [JsonPropertyName("bungieNetMembershipId")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public long BungieNetMembershipId { get; init; }
    }
}