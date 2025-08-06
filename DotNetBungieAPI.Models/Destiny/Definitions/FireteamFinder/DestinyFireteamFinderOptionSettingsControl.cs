namespace DotNetBungieAPI.Models.Destiny.Definitions.FireteamFinder;

public sealed class DestinyFireteamFinderOptionSettingsControl
{
    [JsonPropertyName("type")]
    public Destiny.FireteamFinderOptionControlType Type { get; init; }

    [JsonPropertyName("minSelectedItems")]
    public int MinSelectedItems { get; init; }

    [JsonPropertyName("maxSelectedItems")]
    public int MaxSelectedItems { get; init; }
}
