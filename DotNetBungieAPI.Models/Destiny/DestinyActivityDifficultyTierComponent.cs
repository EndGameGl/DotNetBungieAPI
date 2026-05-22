namespace DotNetBungieAPI.Models.Destiny;

public sealed class DestinyActivityDifficultyTierComponent
{
    [JsonPropertyName("difficultyTierIndex")]
    public int DifficultyTierIndex { get; init; }

    [JsonPropertyName("fixedActivitySkulls")]
    public Destiny.DestinyActivitySkullComponent[]? FixedActivitySkulls { get; init; }
}
