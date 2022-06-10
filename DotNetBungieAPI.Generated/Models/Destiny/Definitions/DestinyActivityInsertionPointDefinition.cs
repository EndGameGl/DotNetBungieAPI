namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     A point of entry into an activity, gated by an unlock flag and with some more-or-less useless (for our purposes) phase information. I'm including it in case we end up being able to bolt more useful information onto it in the future.
/// <para />
///     UPDATE: Turns out this information isn't actually useless, and is in fact actually useful for people. Who would have thought? We still don't have localized info for it, but at least this will help people when they're looking at phase indexes in stats data, or when they want to know what phases have been completed on a weekly achievement.
/// </summary>
public class DestinyActivityInsertionPointDefinition
{
    /// <summary>
    ///     A unique hash value representing the phase. This can be useful for, for example, comparing how different instances of Raids have phases in different orders!
    /// </summary>
    [JsonPropertyName("phaseHash")]
    public uint? PhaseHash { get; set; }
}
