namespace DotNetBungieAPI.Models.FireteamFinder;

public sealed record DestinyFireteamFinderActivityGraphState
{
    /// <summary>
    ///     Indicates if this fireteam finder activity graph node is visible for this character.
    /// </summary>
    [JsonPropertyName("isVisible")]
    public bool IsVisible { get; init; }

    /// <summary>
    ///     Indicates if this fireteam finder activity graph node is available to select for this character.
    /// </summary>
    [JsonPropertyName("isAvailable")]
    public bool IsAvailable { get; init; }
}
