namespace DotNetBungieAPI.Generated.Models.FireteamFinder;

public class DestinyFireteamFinderActivityGraphState
{
    /// <summary>
    ///     Indicates if this fireteam finder activity graph node is visible for this character.
    /// </summary>
    [JsonPropertyName("isVisible")]
    public bool IsVisible { get; set; }

    /// <summary>
    ///     Indicates if this fireteam finder activity graph node is available to select for this character.
    /// </summary>
    [JsonPropertyName("isAvailable")]
    public bool IsAvailable { get; set; }
}
