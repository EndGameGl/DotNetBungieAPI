using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.Fireteam;

namespace NetBungieAPI.Models.Queries
{
    public sealed record SearchResultOfFireteamSummary : SearchResultBase
    {
        [JsonPropertyName("results")]
        public ReadOnlyCollection<FireteamSummary> Results { get; init; } =
            Defaults.EmptyReadOnlyCollection<FireteamSummary>();
    }
}