namespace DotNetBungieAPI.Models.Destiny.Definitions;

public sealed class DestinyItemTooltipNotification
{
    [JsonPropertyName("displayString")]
    public string DisplayString { get; init; }

    [JsonPropertyName("displayStyle")]
    public string DisplayStyle { get; init; }
}
