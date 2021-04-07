using NetBungieAPI.Models.User;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Queries
{
    public sealed record DestinyLinkedProfilesResponse
    {
        [JsonPropertyName("profiles")]
        public ReadOnlyCollection<UserInfoCard> Profiles { get; init; } = Defaults.EmptyReadOnlyCollection<UserInfoCard>();

        [JsonPropertyName("bnetMembership")]
        public UserInfoCard BungieNetMembership { get; init; }
    }
}
