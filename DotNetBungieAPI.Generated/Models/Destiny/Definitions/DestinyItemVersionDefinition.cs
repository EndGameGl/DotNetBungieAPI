namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     The version definition currently just holds a reference to the power cap.
/// </summary>
public sealed class DestinyItemVersionDefinition
{

    /// <summary>
    ///     A reference to the power cap for this item version.
    /// </summary>
    [JsonPropertyName("powerCapHash")]
    public uint PowerCapHash { get; init; } // DestinyPowerCapDefinition
}
