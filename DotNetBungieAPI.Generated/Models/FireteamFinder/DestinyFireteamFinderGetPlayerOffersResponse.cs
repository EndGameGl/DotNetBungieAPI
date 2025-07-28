namespace DotNetBungieAPI.Generated.Models.FireteamFinder;

public class DestinyFireteamFinderGetPlayerOffersResponse
{
    /// <summary>
    ///     All offers that this player has recieved.
    /// </summary>
    [JsonPropertyName("offers")]
    public FireteamFinder.DestinyFireteamFinderOffer[]? Offers { get; set; }
}
