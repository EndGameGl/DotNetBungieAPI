namespace DotNetBungieAPI.Models.Destiny;

public sealed class DestinyActivityDifficultyTierCollectionComponent
{
    [JsonPropertyName("difficultyTierCollectionHash")]
    public DefinitionHashPointer<Destiny.Definitions.Activities.DestinyActivityDifficultyTierCollectionDefinition> DifficultyTierCollectionHash { get; init; }

    [JsonPropertyName("difficultyTiers")]
    public Destiny.DestinyActivityDifficultyTierComponent[]? DifficultyTiers { get; init; }
}
