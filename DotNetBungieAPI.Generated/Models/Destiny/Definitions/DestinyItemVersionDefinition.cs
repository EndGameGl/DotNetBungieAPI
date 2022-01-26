namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     The version definition currently just holds a reference to the power cap.
/// </summary>
public class DestinyItemVersionDefinition : IDeepEquatable<DestinyItemVersionDefinition>
{
    /// <summary>
    ///     A reference to the power cap for this item version.
    /// </summary>
    [JsonPropertyName("powerCapHash")]
    public uint PowerCapHash { get; set; }

    public bool DeepEquals(DestinyItemVersionDefinition? other)
    {
        return other is not null &&
               PowerCapHash == other.PowerCapHash;
    }
}