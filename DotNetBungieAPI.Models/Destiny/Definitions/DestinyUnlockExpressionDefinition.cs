namespace DotNetBungieAPI.Models.Destiny.Definitions;

/// <summary>
///     Unlock Expressions are the foundation of the game's gating mechanics and investment-related restrictions. They can
///     test Unlock Flags and Unlock Values for certain states, using a sufficient amount of logical operators such that
///     unlock expressions are effectively Turing complete.
/// </summary>
public sealed record DestinyUnlockExpressionDefinition
    : IDeepEquatable<DestinyUnlockExpressionDefinition>
{
    /// <summary>
    ///     A shortcut for determining the most restrictive gating that this expression performs.
    /// </summary>
    [JsonPropertyName("scope")]
    public DestinyGatingScope Scope { get; init; }

    public bool DeepEquals(DestinyUnlockExpressionDefinition other)
    {
        return other != null && Scope == other.Scope;
    }
}
