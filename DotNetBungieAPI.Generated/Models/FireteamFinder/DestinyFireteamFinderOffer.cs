namespace DotNetBungieAPI.Generated.Models.FireteamFinder;

public class DestinyFireteamFinderOffer
{
    [JsonPropertyName("offerId")]
    public long? OfferId { get; set; }

    [JsonPropertyName("lobbyId")]
    public long? LobbyId { get; set; }

    [JsonPropertyName("revision")]
    public int? Revision { get; set; }

    [JsonPropertyName("state")]
    public FireteamFinder.DestinyFireteamFinderOfferState? State { get; set; }

    [JsonPropertyName("targetId")]
    public FireteamFinder.DestinyFireteamFinderPlayerId? TargetId { get; set; }

    [JsonPropertyName("applicationId")]
    public long? ApplicationId { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }
}
