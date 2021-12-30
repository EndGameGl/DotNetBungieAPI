using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public sealed class DestinyLeaderboardResults
{

    /// <summary>
    ///     Indicate the membership ID of the account that is the focal point of the provided leaderboards.
    /// </summary>
    [JsonPropertyName("focusMembershipId")]
    public long? FocusMembershipId { get; init; }

    /// <summary>
    ///     Indicate the character ID of the character that is the focal point of the provided leaderboards. May be null, in which case any character from the focus membership can appear in the provided leaderboards.
    /// </summary>
    [JsonPropertyName("focusCharacterId")]
    public long? FocusCharacterId { get; init; }
}
