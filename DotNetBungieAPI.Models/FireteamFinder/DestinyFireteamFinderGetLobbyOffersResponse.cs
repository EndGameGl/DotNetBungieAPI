﻿namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderGetLobbyOffersResponse
{
    [JsonPropertyName("offers")]
    public ReadOnlyCollection<DestinyFireteamFinderOffer> Offers { get; init; } =
        ReadOnlyCollections<DestinyFireteamFinderOffer>.Empty;

    [JsonPropertyName("pageToken")]
    public string PageToken { get; init; }
}
