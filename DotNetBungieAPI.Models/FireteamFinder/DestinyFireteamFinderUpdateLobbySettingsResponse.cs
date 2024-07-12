namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderUpdateLobbySettingsResponse
{
    [JsonPropertyName("updatedLobby")]
    public DestinyFireteamFinderLobbyResponse UpdatedLobby { get; init; }

    [JsonPropertyName("updatedListing")]
    public DestinyFireteamFinderListing UpdatedListing { get; init; }
}
