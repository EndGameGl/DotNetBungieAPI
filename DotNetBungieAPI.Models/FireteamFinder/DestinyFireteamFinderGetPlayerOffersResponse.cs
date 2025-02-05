namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderGetPlayerOffersResponse
{
    /// <summary>
    ///     All offers that this player has recieved.
    /// </summary>
    [JsonPropertyName("offers")]
    public ReadOnlyCollection<DestinyFireteamFinderOffer> Offers { get; init; } =
        ReadOnlyCollection<DestinyFireteamFinderOffer>.Empty;
}
