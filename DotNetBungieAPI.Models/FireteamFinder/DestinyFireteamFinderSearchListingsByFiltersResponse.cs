﻿namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderSearchListingsByFiltersResponse
{
    [JsonPropertyName("listings")]
    public ReadOnlyCollection<DestinyFireteamFinderListing> Listings { get; set; } =
        ReadOnlyCollections<DestinyFireteamFinderListing>.Empty;

    [JsonPropertyName("pageToken")]
    public string PageToken { get; set; }
}
