using DotNetBungieAPI.Models.Fireteam;

namespace DotNetBungieAPI.Models.Queries;

public sealed record SearchResultOfFireteamSummary : SearchResultBase
{
    [JsonPropertyName("results")]
    public ReadOnlyCollection<FireteamSummary> Results { get; init; } =
        ReadOnlyCollections<FireteamSummary>.Empty;
}