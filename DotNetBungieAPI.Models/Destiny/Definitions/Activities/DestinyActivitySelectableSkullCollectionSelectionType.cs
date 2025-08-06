namespace DotNetBungieAPI.Models.Destiny.Definitions.Activities;

public sealed class DestinyActivitySelectableSkullCollectionSelectionType
{
    [JsonPropertyName("selectionCount")]
    public int SelectionCount { get; init; }

    [JsonPropertyName("refreshTimeMinutes")]
    public int RefreshTimeMinutes { get; init; }

    [JsonPropertyName("refreshTimeOffsetMinutes")]
    public int RefreshTimeOffsetMinutes { get; init; }
}
