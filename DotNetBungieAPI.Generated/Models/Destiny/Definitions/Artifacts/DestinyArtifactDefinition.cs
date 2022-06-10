namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Artifacts;

/// <summary>
///     Represents known info about a Destiny Artifact.
/// <para />
///     We cannot guarantee that artifact definitions will be immutable between seasons - in fact, we've been told that they will be replaced between seasons. But this definition is built both to minimize the amount of lookups for related data that have to occur, and is built in hope that, if this plan changes, we will be able to accommodate it more easily.
/// </summary>
public class DestinyArtifactDefinition
{
    /// <summary>
    ///     Any basic display info we know about the Artifact. Currently sourced from a related inventory item, but the source of this data is subject to change.
    /// </summary>
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; set; }

    /// <summary>
    ///     Any Geometry/3D info we know about the Artifact. Currently sourced from a related inventory item's gearset information, but the source of this data is subject to change.
    /// </summary>
    [JsonPropertyName("translationBlock")]
    public Destiny.Definitions.DestinyItemTranslationBlockDefinition? TranslationBlock { get; set; }

    /// <summary>
    ///     Any Tier/Rank data related to this artifact, listed in display order.  Currently sourced from a Vendor, but this source is subject to change.
    /// </summary>
    [JsonPropertyName("tiers")]
    public List<Destiny.Definitions.Artifacts.DestinyArtifactTierDefinition> Tiers { get; set; }

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
