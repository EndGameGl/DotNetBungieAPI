namespace DotNetBungieAPI.Models.Destiny.Challenges;

/// <summary>
///     Represents the status and other related information for a challenge that is - or was - available to a player. 
/// <para />
///     A challenge is a bonus objective, generally tacked onto Quests or Activities, that provide additional variations on play.
/// </summary>
public sealed class DestinyChallengeStatus
{
    /// <summary>
    ///     The progress - including completion status - of the active challenge.
    /// </summary>
    [JsonPropertyName("objective")]
    public Destiny.Quests.DestinyObjectiveProgress? Objective { get; init; }
}
