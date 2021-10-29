using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Defaults;
using DotNetBungieAPI.Models.GroupsV2;

namespace DotNetBungieAPI.Models.User
{
    public sealed record UserSearchResponseDetail
    {
        [JsonPropertyName("destinyMemberships")]
        public ReadOnlyCollection<UserInfoCard> DestinyMemberships { get; init; } =
            ReadOnlyCollections<UserInfoCard>.Empty;

        [JsonPropertyName("bungieGlobalDisplayName")]
        public string BungieGlobalDisplayName { get; init; }

        [JsonPropertyName("bungieGlobalDisplayNameCode")]
        public short BungieGlobalDisplayNameCode { get; init; }

        [JsonPropertyName("bungieNetMembershipId")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public long BungieNetMembershipId { get; init; }
    }
}