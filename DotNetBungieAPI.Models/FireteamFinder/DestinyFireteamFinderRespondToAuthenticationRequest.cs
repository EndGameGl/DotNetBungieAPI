namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderRespondToAuthenticationRequest
{
    [JsonPropertyName("confirmed")]
    public bool Confirmed { get; init; }
}
