namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderLobbySettings
{
    [JsonPropertyName("maxPlayerCount")]
    public int MaxPlayerCount { get; init; }

    [JsonPropertyName("onlinePlayersOnly")]
    public bool OnlinePlayersOnly { get; init; }

    [JsonPropertyName("privacyScope")]
    public DestinyFireteamFinderLobbyPrivacyScope PrivacyScope { get; init; }

    [JsonPropertyName("scheduledDateTime")]
    public DateTime ScheduledDateTime { get; init; }

    [JsonPropertyName("clanId")]
    public long ClanId { get; init; }

    [JsonPropertyName("listingValues")]
    public List<DestinyFireteamFinderListingValue> ListingValues { get; init; }

    [JsonPropertyName("activityGraphHash")]
    public uint ActivityGraphHash { get; init; }

    [JsonPropertyName("activityHash")]
    public uint Activity { get; init; }
}
