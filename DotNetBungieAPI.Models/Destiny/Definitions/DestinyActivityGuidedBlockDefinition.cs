namespace DotNetBungieAPI.Models.Destiny.Definitions;

/// <summary>
///     Guided Game information for this activity.
/// </summary>
public sealed class DestinyActivityGuidedBlockDefinition
{
    /// <summary>
    ///     The maximum amount of people that can be in the waiting lobby.
    /// </summary>
    [JsonPropertyName("guidedMaxLobbySize")]
    public int GuidedMaxLobbySize { get; init; }

    /// <summary>
    ///     The minimum amount of people that can be in the waiting lobby.
    /// </summary>
    [JsonPropertyName("guidedMinLobbySize")]
    public int GuidedMinLobbySize { get; init; }

    /// <summary>
    ///     If -1, the guided group cannot be disbanded. Otherwise, take the total # of players in the activity and subtract this number: that is the total # of votes needed for the guided group to disband.
    /// </summary>
    [JsonPropertyName("guidedDisbandCount")]
    public int GuidedDisbandCount { get; init; }
}
