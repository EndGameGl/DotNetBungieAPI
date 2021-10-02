using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Social
{
    public sealed record BungieFriendRequestListResponse
    {
        [JsonPropertyName("incomingRequests")]
        public ReadOnlyCollection<BungieFriend> IncomingRequests { get; init; } =
            Defaults.EmptyReadOnlyCollection<BungieFriend>();

        [JsonPropertyName("outgoingRequests")]
        public ReadOnlyCollection<BungieFriend> OutgoingRequests { get; init; } =
            Defaults.EmptyReadOnlyCollection<BungieFriend>();
    }
}