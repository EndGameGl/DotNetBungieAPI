namespace DotNetBungieAPI.Generated.Models.FireteamFinder;

public class DestinyFireteamFinderGetLobbyOffersResponse
{
    [JsonPropertyName("offers")]
    public List<FireteamFinder.DestinyFireteamFinderOffer> Offers { get; set; }

    [JsonPropertyName("pageToken")]
    public string? PageToken { get; set; }
}
