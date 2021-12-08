namespace DotNetBungieAPI.Models.Destiny.Definitions.Activities;

/// <summary>
///     A point of entry into an activity, gated by an unlock flag and with some more-or-less useless (for our purposes)
///     phase information..
/// </summary>
public sealed record DestinyActivityInsertionPointDefinition
    : IDeepEquatable<DestinyActivityInsertionPointDefinition>
{
    /// <summary>
    ///     A unique hash value representing the phase. This can be useful for, for example, comparing how different instances
    ///     of Raids have phases in different orders!
    /// </summary>
    [JsonPropertyName("phaseHash")]
    public uint PhaseHash { get; init; }

    [JsonPropertyName("unlockHash")] public uint UnlockHash { get; init; }

    public bool DeepEquals(DestinyActivityInsertionPointDefinition other)
    {
        return other != null &&
               PhaseHash == other.PhaseHash &&
               UnlockHash == other.UnlockHash;
    }
}