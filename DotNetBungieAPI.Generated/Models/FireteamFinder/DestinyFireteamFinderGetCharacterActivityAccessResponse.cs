namespace DotNetBungieAPI.Generated.Models.FireteamFinder;

public class DestinyFireteamFinderGetCharacterActivityAccessResponse
{
    /// <summary>
    ///     A map of fireteam finder activity graph hashes to visibility and availability states.
    /// </summary>
    [JsonPropertyName("fireteamFinderActivityGraphStates")]
    public Dictionary<uint, FireteamFinder.DestinyFireteamFinderActivityGraphState> FireteamFinderActivityGraphStates { get; set; }
}
