namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     A "Location" is a sort of shortcut for referring to a specific combination of Activity, Destination, Place, and even Bubble or NavPoint within a space.
/// <para />
///     Most of this data isn't intrinsically useful to us, but Objectives refer to locations, and through that we can at least infer the Activity, Destination, and Place being referred to by the Objective.
/// </summary>
public class DestinyLocationDefinition
{
    /// <summary>
    ///     If the location has a Vendor on it, this is the hash identifier for that Vendor. Look them up with DestinyVendorDefinition.
    /// </summary>
    [JsonPropertyName("vendorHash")]
    public uint? VendorHash { get; set; }

    /// <summary>
    ///     A Location may refer to different specific spots in the world based on the world's current state. This is a list of those potential spots, and the data we can use at runtime to determine which one of the spots is the currently valid one.
    /// </summary>
    [JsonPropertyName("locationReleases")]
    public List<Destiny.Definitions.DestinyLocationReleaseDefinition> LocationReleases { get; set; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint? Hash { get; set; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int? Index { get; set; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool? Redacted { get; set; }
}
