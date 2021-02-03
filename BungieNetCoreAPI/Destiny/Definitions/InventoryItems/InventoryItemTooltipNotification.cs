using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemTooltipNotification : IDeepEquatable<InventoryItemTooltipNotification>
    {
        public string DisplayString { get; }
        public string DisplayStyle { get; }

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
