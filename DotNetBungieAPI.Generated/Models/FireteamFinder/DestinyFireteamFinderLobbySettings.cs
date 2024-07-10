namespace DotNetBungieAPI.Generated.Models.FireteamFinder;

public class DestinyFireteamFinderLobbySettings
{
    [JsonPropertyName("maxPlayerCount")]
    public int? MaxPlayerCount { get; set; }

    [JsonPropertyName("onlinePlayersOnly")]
    public bool? OnlinePlayersOnly { get; set; }

    [JsonPropertyName("privacyScope")]
    public FireteamFinder.DestinyFireteamFinderLobbyPrivacyScope? PrivacyScope { get; set; }

    [JsonPropertyName("scheduledDateTime")]
    public DateTime? ScheduledDateTime { get; set; }

    [JsonPropertyName("clanId")]
    public long? ClanId { get; set; }

    [JsonPropertyName("listingValues")]
    public List<FireteamFinder.DestinyFireteamFinderListingValue> ListingValues { get; set; }

    [JsonPropertyName("activityGraphHash")]
    public uint? ActivityGraphHash { get; set; }

    [JsonPropertyName("activityHash")]
    public uint? ActivityHash { get; set; }
}
