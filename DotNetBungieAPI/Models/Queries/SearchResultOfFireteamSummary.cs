using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Models.Fireteam;

namespace DotNetBungieAPI.Models.Queries
{
    public sealed record SearchResultOfFireteamSummary : SearchResultBase
    {
        [JsonPropertyName("results")]
        public ReadOnlyCollection<FireteamSummary> Results { get; init; } =
            Defaults.EmptyReadOnlyCollection<FireteamSummary>();
    }
}