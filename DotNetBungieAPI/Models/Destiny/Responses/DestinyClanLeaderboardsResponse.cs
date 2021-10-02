using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Responses
{
    public sealed record DestinyClanLeaderboardsResponse
    {
        [JsonPropertyName("statId")] public string StatId { get; init; }

        [JsonPropertyName("entries")]
        public ReadOnlyCollection<DestinyClanLeaderboardsResponseEntry> Entries { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyClanLeaderboardsResponseEntry>();
    }
}