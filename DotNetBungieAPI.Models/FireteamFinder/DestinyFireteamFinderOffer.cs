namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderOffer
{
    [JsonPropertyName("offerId")]
    public long OfferId { get; set; }

    [JsonPropertyName("lobbyId")]
    public long LobbyId { get; set; }

    [JsonPropertyName("revision")]
    public int Revision { get; set; }

    [JsonPropertyName("state")]
    public DestinyFireteamFinderOfferState State { get; set; }

    [JsonPropertyName("targetId")]
    public DestinyFireteamFinderPlayerId TargetId { get; set; }

    [JsonPropertyName("applicationId")]
    public long ApplicationId { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime CreatedDateTime { get; set; }
}
