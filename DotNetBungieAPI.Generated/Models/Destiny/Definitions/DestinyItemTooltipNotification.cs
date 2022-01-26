namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinyItemTooltipNotification : IDeepEquatable<DestinyItemTooltipNotification>
{
    [JsonPropertyName("displayString")]
    public string DisplayString { get; set; }

    [JsonPropertyName("displayStyle")]
    public string DisplayStyle { get; set; }

    public bool DeepEquals(DestinyItemTooltipNotification? other)
    {
        return other is not null &&
               DisplayString == other.DisplayString &&
               DisplayStyle == other.DisplayStyle;
    }
}