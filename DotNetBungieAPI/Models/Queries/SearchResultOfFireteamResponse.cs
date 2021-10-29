using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Defaults;

namespace DotNetBungieAPI.Models.Queries
{
    public sealed record SearchResultOfFireteamResponse
    {
        [JsonPropertyName("results")]
        public ReadOnlyCollection<FireteamResponse> Results { get; init; } =
            ReadOnlyCollections<FireteamResponse>.Empty;
    }
}