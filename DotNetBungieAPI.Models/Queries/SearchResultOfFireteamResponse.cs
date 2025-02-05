namespace DotNetBungieAPI.Models.Queries;

public sealed record SearchResultOfFireteamResponse
{
    [JsonPropertyName("results")]
    public ReadOnlyCollection<FireteamResponse> Results { get; init; } =
        ReadOnlyCollection<FireteamResponse>.Empty;
}
