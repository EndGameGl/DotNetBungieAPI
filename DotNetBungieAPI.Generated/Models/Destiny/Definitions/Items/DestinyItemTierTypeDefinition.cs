namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Items;

/// <summary>
///     Defines the tier type of an item. Mostly this provides human readable properties for types like Common, Rare, etc...
/// <para />
///     It also provides some base data for infusion that could be useful.
/// </summary>
public class DestinyItemTierTypeDefinition : IDeepEquatable<DestinyItemTierTypeDefinition>
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

    /// <summary>
    ///     If this tier defines infusion properties, they will be contained here.
    /// </summary>
    [JsonPropertyName("infusionProcess")]
    public Destiny.Definitions.Items.DestinyItemTierTypeInfusionBlock InfusionProcess { get; set; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; set; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; set; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool Redacted { get; set; }

    public bool DeepEquals(DestinyItemTierTypeDefinition? other)
    {
        return other is not null &&
               (DisplayProperties is not null ? DisplayProperties.DeepEquals(other.DisplayProperties) : other.DisplayProperties is null) &&
               (InfusionProcess is not null ? InfusionProcess.DeepEquals(other.InfusionProcess) : other.InfusionProcess is null) &&
               Hash == other.Hash &&
               Index == other.Index &&
               Redacted == other.Redacted;
    }
}