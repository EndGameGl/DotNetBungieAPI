using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Queries
{
    public sealed record SearchResultOfFireteamResponse
    {
        [JsonPropertyName("results")]
        public ReadOnlyCollection<FireteamResponse> Results { get; init; } = Defaults.EmptyReadOnlyCollection<FireteamResponse>();
    }
}
