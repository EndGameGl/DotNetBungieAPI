namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     A reference to an Activity Modifier from another entity, such as an Activity (for now, just Activities).
/// <para />
///     This defines some
/// </summary>
public class DestinyActivityModifierReferenceDefinition : IDeepEquatable<DestinyActivityModifierReferenceDefinition>
{
    /// <summary>
    ///     The hash identifier for the DestinyActivityModifierDefinition referenced by this activity.
    /// </summary>
    [JsonPropertyName("activityModifierHash")]
    public uint ActivityModifierHash { get; set; }

    public bool DeepEquals(DestinyActivityModifierReferenceDefinition? other)
    {
        return other is not null &&
               ActivityModifierHash == other.ActivityModifierHash;
    }
}