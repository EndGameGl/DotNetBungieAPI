using DotNetBungieAPI.Models.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;

namespace DotNetBungieAPI.Models.Destiny.Definitions.SocialCommendations;

[DestinyDefinition(DefinitionsEnum.DestinySocialCommendationDefinition)]
public sealed record DestinySocialCommendationDefinition
    : IDestinyDefinition,
        IDisplayProperties,
        IDeepEquatable<DestinySocialCommendationDefinition>
{
    public DefinitionsEnum DefinitionEnumValue =>
        DefinitionsEnum.DestinySocialCommendationDefinition;

    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("cardImagePath")]
    public string CardImagePath { get; init; }

    [JsonPropertyName("color")]
    public DestinyColor Color { get; init; }

    [JsonPropertyName("displayPriority")]
    public int DisplayPriority { get; init; }

    [JsonPropertyName("activityGivingLimit")]
    public int ActivityGivingLimit { get; init; }

    [JsonPropertyName("parentCommendationNodeHash")]
    public DefinitionHashPointer<DestinySocialCommendationNodeDefinition> ParentCommendationNode { get; init; } =
        DefinitionHashPointer<DestinySocialCommendationNodeDefinition>.Empty;

    [JsonPropertyName("displayActivities")]
    public ReadOnlyCollection<DestinyDisplayPropertiesDefinition> DisplayActivities { get; init; } =
        ReadOnlyCollection<DestinyDisplayPropertiesDefinition>.Empty;

    [JsonPropertyName("blacklisted")]
    public bool Blacklisted { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }

    public bool DeepEquals(DestinySocialCommendationDefinition other)
    {
        return other is not null
            && DisplayProperties.DeepEquals(other.DisplayProperties)
            && CardImagePath == other.CardImagePath
            && Color.DeepEquals(other.Color)
            && DisplayPriority == other.DisplayPriority
            && ActivityGivingLimit == other.ActivityGivingLimit
            && ParentCommendationNode.DeepEquals(other.ParentCommendationNode)
            && DisplayActivities.DeepEqualsReadOnlyCollection(other.DisplayActivities)
            && Blacklisted == other.Blacklisted
            && Hash == other.Hash
            && Index == other.Index
            && Redacted == other.Redacted;
    }
}
