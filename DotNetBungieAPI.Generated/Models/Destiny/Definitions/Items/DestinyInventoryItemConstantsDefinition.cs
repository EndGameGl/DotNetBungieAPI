namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Items;

public class DestinyInventoryItemConstantsDefinition
{
    /// <summary>
    ///     Gear tier overlay images
    /// </summary>
    [JsonPropertyName("gearTierOverlayImagePaths")]
    public List<string> GearTierOverlayImagePaths { get; set; }

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
