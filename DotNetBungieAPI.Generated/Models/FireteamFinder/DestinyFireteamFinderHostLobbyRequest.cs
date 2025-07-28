namespace DotNetBungieAPI.Generated.Models.FireteamFinder;

public class DestinyFireteamFinderHostLobbyRequest
{
    [JsonPropertyName("maxPlayerCount")]
    public int MaxPlayerCount { get; set; }

    [JsonPropertyName("onlinePlayersOnly")]
    public bool OnlinePlayersOnly { get; set; }

    [JsonPropertyName("privacyScope")]
    public FireteamFinder.DestinyFireteamFinderLobbyPrivacyScope PrivacyScope { get; set; }

    [JsonPropertyName("scheduledDateTime")]
    public DateTime ScheduledDateTime { get; set; }

    [JsonPropertyName("clanId")]
    public long ClanId { get; set; }

    [JsonPropertyName("listingValues")]
    public FireteamFinder.DestinyFireteamFinderListingValue[]? ListingValues { get; set; }

    [Destiny2Definition<Destiny.Definitions.FireteamFinder.DestinyFireteamFinderActivityGraphDefinition>("Destiny.Definitions.FireteamFinder.DestinyFireteamFinderActivityGraphDefinition")]
    [JsonPropertyName("activityGraphHash")]
    public uint ActivityGraphHash { get; set; }

    [Destiny2Definition<Destiny.Definitions.DestinyActivityDefinition>("Destiny.Definitions.DestinyActivityDefinition")]
    [JsonPropertyName("activityHash")]
    public uint ActivityHash { get; set; }
}
