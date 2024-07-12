namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Social;

public class DestinySocialCommendationDefinition
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; set; }

    [JsonPropertyName("cardImagePath")]
    public string? CardImagePath { get; set; }

    [JsonPropertyName("color")]
    public Destiny.Misc.DestinyColor? Color { get; set; }

    [JsonPropertyName("displayPriority")]
    public int? DisplayPriority { get; set; }

    [JsonPropertyName("activityGivingLimit")]
    public int? ActivityGivingLimit { get; set; }

    [Destiny2Definition<Destiny.Definitions.Social.DestinySocialCommendationNodeDefinition>("Destiny.Definitions.Social.DestinySocialCommendationNodeDefinition")]
    [JsonPropertyName("parentCommendationNodeHash")]
    public uint? ParentCommendationNodeHash { get; set; }

    /// <summary>
    ///     The display properties for the the activities that this commendation is available in.
    /// </summary>
    [JsonPropertyName("displayActivities")]
    public List<Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition> DisplayActivities { get; set; }

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
