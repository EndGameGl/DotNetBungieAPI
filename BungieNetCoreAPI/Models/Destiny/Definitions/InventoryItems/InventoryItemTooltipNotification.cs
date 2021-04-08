using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemTooltipNotification : IDeepEquatable<InventoryItemTooltipNotification>
    {
        public string DisplayString { get; init; }
        public string DisplayStyle { get; init; }

        [JsonConstructor]
        internal InventoryItemTooltipNotification(string displayString, string displayStyle)
        {
            DisplayString = displayString;
            DisplayStyle = displayStyle;
        }

        public bool DeepEquals(InventoryItemTooltipNotification other)
        {
            return 
                other != null && 
                DisplayString == other.DisplayString && 
                DisplayStyle == other.DisplayStyle;
        }
    }
}
