using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Defaults;
using DotNetBungieAPI.Models.Fireteam;

namespace DotNetBungieAPI.Models.Queries
{
    public sealed record SearchResultOfFireteamSummary : SearchResultBase
    {
        [JsonPropertyName("results")]
        public ReadOnlyCollection<FireteamSummary> Results { get; init; } =
            ReadOnlyCollections<FireteamSummary>.Empty;
    }
}