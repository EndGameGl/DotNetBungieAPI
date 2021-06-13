using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.InventoryItems
{
    public sealed record DestinyItemTooltipNotification : IDeepEquatable<DestinyItemTooltipNotification>
    {
        [JsonPropertyName("displayString")]
        public string DisplayString { get; init; }
        [JsonPropertyName("displayStyle")]
        public string DisplayStyle { get; init; }

        public bool DeepEquals(DestinyItemTooltipNotification other)
        {
            return 
                other != null && 
                DisplayString == other.DisplayString && 
                DisplayStyle == other.DisplayStyle;
        }
    }
}
