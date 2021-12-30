using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     A reference to an Activity Modifier from another entity, such as an Activity (for now, just Activities).
/// <para />
///     This defines some
/// </summary>
public sealed class DestinyActivityModifierReferenceDefinition
{

    /// <summary>
    ///     The hash identifier for the DestinyActivityModifierDefinition referenced by this activity.
    /// </summary>
    [JsonPropertyName("activityModifierHash")]
    public uint ActivityModifierHash { get; init; }
}
