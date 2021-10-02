using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Social
{
    public sealed record BungieFriendListResponse
    {
        [JsonPropertyName("friends")]
        public ReadOnlyCollection<BungieFriend> Friends { get; init; } =
            Defaults.EmptyReadOnlyCollection<BungieFriend>();
    }
}