namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderApplyToListingResponse
{
    [JsonPropertyName("isApplied")]
    public bool IsApplied { get; init; }

    [JsonPropertyName("application")]
    public DestinyFireteamFinderApplication Application { get; init; }

    [JsonPropertyName("listing")]
    public DestinyFireteamFinderListing Listing { get; init; }
}
