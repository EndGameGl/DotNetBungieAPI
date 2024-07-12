namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderGetListingApplicationsResponse
{
    [JsonPropertyName("applications")]
    public ReadOnlyCollection<DestinyFireteamFinderApplication> Applications { get; init; } =
        ReadOnlyCollections<DestinyFireteamFinderApplication>.Empty;

    [JsonPropertyName("pageSize")]
    public int PageSize { get; init; }

    [JsonPropertyName("nextPageToken")]
    public string NextPageToken { get; init; }
}
