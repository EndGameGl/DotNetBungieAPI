namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderUpdateLobbySettingsRequest
{
    [JsonPropertyName("updatedSettings")]
    public DestinyFireteamFinderLobbySettings UpdatedSettings { get; init; }
}
