namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     A reference to an Activity Modifier from another entity, such as an Activity (for now, just Activities).
/// <para />
///     This defines some
/// </summary>
public class DestinyActivityModifierReferenceDefinition
{
    /// <summary>
    ///     The hash identifier for the DestinyActivityModifierDefinition referenced by this activity.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.ActivityModifiers.DestinyActivityModifierDefinition>("Destiny.Definitions.ActivityModifiers.DestinyActivityModifierDefinition")]
    [JsonPropertyName("activityModifierHash")]
    public uint ActivityModifierHash { get; set; }
}
