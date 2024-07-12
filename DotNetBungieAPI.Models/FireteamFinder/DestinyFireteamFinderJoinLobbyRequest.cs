namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderJoinLobbyRequest
{
    [JsonPropertyName("lobbyId")]
    public long LobbyId { get; init; }

    [JsonPropertyName("offerId")]
    public long OfferId { get; init; }
}
