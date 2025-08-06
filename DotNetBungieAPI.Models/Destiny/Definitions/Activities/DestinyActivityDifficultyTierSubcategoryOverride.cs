namespace DotNetBungieAPI.Models.Destiny.Definitions.Activities;

public sealed class DestinyActivityDifficultyTierSubcategoryOverride
{
    [JsonPropertyName("skullSubcategoryHash")]
    public uint SkullSubcategoryHash { get; init; }

    [JsonPropertyName("refreshTimeMinutes")]
    public int RefreshTimeMinutes { get; init; }

    [JsonPropertyName("refreshTimeOffsetMinutes")]
    public int RefreshTimeOffsetMinutes { get; init; }
}
