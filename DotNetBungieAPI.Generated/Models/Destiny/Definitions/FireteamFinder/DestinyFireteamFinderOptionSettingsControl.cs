namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.FireteamFinder;

public class DestinyFireteamFinderOptionSettingsControl
{
    [JsonPropertyName("type")]
    public Destiny.FireteamFinderOptionControlType? Type { get; set; }

    [JsonPropertyName("minSelectedItems")]
    public int? MinSelectedItems { get; set; }

    [JsonPropertyName("maxSelectedItems")]
    public int? MaxSelectedItems { get; set; }
}
