namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderRespondToOfferRequest
{
    [JsonPropertyName("accepted")]
    public bool Accepted { get; init; }
}
