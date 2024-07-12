namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderRespondToApplicationRequest
{
    [JsonPropertyName("accepted")]
    public bool Accepted { get; init; }
}
