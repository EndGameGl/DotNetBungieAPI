namespace DotNetBungieAPI.Generated.Models.Destiny.Challenges;

/// <summary>
///     Represents the status and other related information for a challenge that is - or was - available to a player. 
/// <para />
///     A challenge is a bonus objective, generally tacked onto Quests or Activities, that provide additional variations on play.
/// </summary>
public class DestinyChallengeStatus : IDeepEquatable<DestinyChallengeStatus>
{
    /// <summary>
    ///     The progress - including completion status - of the active challenge.
    /// </summary>
    [JsonPropertyName("objective")]
    public Destiny.Quests.DestinyObjectiveProgress Objective { get; set; }

    public bool DeepEquals(DestinyChallengeStatus? other)
    {
        return other is not null &&
               (Objective is not null ? Objective.DeepEquals(other.Objective) : other.Objective is null);
    }
}