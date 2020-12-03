using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemTooltipNotification
    {
        public string DisplayString { get; }
        public string DisplayStyle { get; }

        [JsonConstructor]
        private InventoryItemTooltipNotification(string displayString, string displayStyle)
        {
            DisplayString = displayString;
            DisplayStyle = displayStyle;
        }
    }
}
