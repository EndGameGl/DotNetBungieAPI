namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Activities;

public class DestinyActivityDifficultyTierDefinition
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; set; }

    [JsonPropertyName("recommendedActivityLevelOffset")]
    public int RecommendedActivityLevelOffset { get; set; }

    [JsonPropertyName("fixedActivitySkulls")]
    public Destiny.Definitions.Activities.DestinyActivitySkull[]? FixedActivitySkulls { get; set; }

    [JsonPropertyName("tierEnabledUnlockExpression")]
    public Destiny.Definitions.DestinyUnlockExpressionDefinition? TierEnabledUnlockExpression { get; set; }

    [JsonPropertyName("tierType")]
    public Destiny.DestinyActivityDifficultyTierType TierType { get; set; }

    [Destiny2Definition<Destiny.Definitions.Traits.DestinyTraitDefinition>("Destiny.Definitions.Traits.DestinyTraitDefinition")]
    [JsonPropertyName("optionalRequiredTrait")]
    public uint? OptionalRequiredTrait { get; set; }

    [JsonPropertyName("activityLevel")]
    public int ActivityLevel { get; set; }

    [JsonPropertyName("tierRank")]
    public int TierRank { get; set; }

    [JsonPropertyName("minimumFireteamLeaderPower")]
    public int MinimumFireteamLeaderPower { get; set; }

    [JsonPropertyName("maximumFireteamLeaderPower")]
    public int MaximumFireteamLeaderPower { get; set; }

    [JsonPropertyName("scoreTimeLimitMultiplier")]
    public int ScoreTimeLimitMultiplier { get; set; }

    [Destiny2Definition<Destiny.Definitions.Activities.DestinyActivitySelectableSkullCollectionDefinition>("Destiny.Definitions.Activities.DestinyActivitySelectableSkullCollectionDefinition")]
    [JsonPropertyName("selectableSkullCollectionHashes")]
    public uint[]? SelectableSkullCollectionHashes { get; set; }

    [JsonPropertyName("skullSubcategoryOverrides")]
    public Destiny.Definitions.Activities.DestinyActivityDifficultyTierSubcategoryOverride[]? SkullSubcategoryOverrides { get; set; }
}
