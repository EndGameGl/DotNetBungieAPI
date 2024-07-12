namespace DotNetBungieAPI.Models.Destiny.Definitions.FireteamFinder;

public sealed record DestinyFireteamFinderOptionSettingsControl
{
    [JsonPropertyName("type")]
    public FireteamFinderOptionControlType Type { get; init; }

    [JsonPropertyName("minSelectedItems")]
    public int MinSelectedItems { get; init; }

    [JsonPropertyName("maxSelectedItems")]
    public int MaxSelectedItems { get; init; }
}
