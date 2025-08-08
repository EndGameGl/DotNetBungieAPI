namespace DotNetBungieAPI.Models.Destiny.Definitions.Activities;

public sealed class DestinyActivityDifficultyTierDefinition : IDisplayProperties
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; init; }

    [JsonPropertyName("recommendedActivityLevelOffset")]
    public int RecommendedActivityLevelOffset { get; init; }

    [JsonPropertyName("fixedActivitySkulls")]
    public Destiny.Definitions.Activities.DestinyActivitySkull[]? FixedActivitySkulls { get; init; }

    [JsonPropertyName("tierEnabledUnlockExpression")]
    public Destiny.Definitions.DestinyUnlockExpressionDefinition? TierEnabledUnlockExpression { get; init; }

    [JsonPropertyName("tierType")]
    public Destiny.DestinyActivityDifficultyTierType TierType { get; init; }

    [JsonPropertyName("optionalRequiredTrait")]
    public DefinitionHashPointer<Destiny.Definitions.Traits.DestinyTraitDefinition> OptionalRequiredTrait { get; init; }

    [JsonPropertyName("activityLevel")]
    public int ActivityLevel { get; init; }

    [JsonPropertyName("tierRank")]
    public int TierRank { get; init; }

    [JsonPropertyName("minimumFireteamLeaderPower")]
    public int MinimumFireteamLeaderPower { get; init; }

    [JsonPropertyName("maximumFireteamLeaderPower")]
    public int MaximumFireteamLeaderPower { get; init; }

    [JsonPropertyName("scoreTimeLimitMultiplier")]
    public int ScoreTimeLimitMultiplier { get; init; }

    [JsonPropertyName("selectableSkullCollectionHashes")]
    public DefinitionHashPointer<Destiny.Definitions.Activities.DestinyActivitySelectableSkullCollectionDefinition>[]? SelectableSkullCollectionHashes { get; init; }

    [JsonPropertyName("skullSubcategoryOverrides")]
    public Destiny.Definitions.Activities.DestinyActivityDifficultyTierSubcategoryOverride[]? SkullSubcategoryOverrides { get; init; }
}
