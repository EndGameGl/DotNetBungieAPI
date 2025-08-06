namespace DotNetBungieAPI.Models.Destiny.Definitions.Social;

[DestinyDefinition(DefinitionsEnum.DestinySocialCommendationDefinition)]
public sealed class DestinySocialCommendationDefinition : IDestinyDefinition, IDisplayProperties
{
    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinySocialCommendationDefinition;

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; init; }

    [JsonPropertyName("cardImagePath")]
    public string CardImagePath { get; init; }

    [JsonPropertyName("color")]
    public Destiny.Misc.DestinyColor? Color { get; init; }

    [JsonPropertyName("displayPriority")]
    public int DisplayPriority { get; init; }

    [JsonPropertyName("activityGivingLimit")]
    public int ActivityGivingLimit { get; init; }

    [JsonPropertyName("parentCommendationNodeHash")]
    public DefinitionHashPointer<Destiny.Definitions.Social.DestinySocialCommendationNodeDefinition> ParentCommendationNodeHash { get; init; }

    /// <summary>
    ///     The display properties for the the activities that this commendation is available in.
    /// </summary>
    [JsonPropertyName("displayActivities")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition[]? DisplayActivities { get; init; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; init; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
